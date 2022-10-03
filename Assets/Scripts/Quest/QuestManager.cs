using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : Singleton<QuestManager>, ISavable
{
    [SerializeField] QuestDB questDB;
    public Dictionary<int, QuestSO> idToQuest;

    [SerializeField] QuestSO firstQuestSO;

    private List<QuestSO> startedQuests;
    private List<QuestSO> finishedQuests;

    public List<Quest> activeQuests{get; set;}//questso or quest or id?

    public override void Awake()
    {
        base.Awake();

        idToQuest = new Dictionary<int, QuestSO>();

        foreach(QuestSO questSO in questDB.quests)
        {
            if(!idToQuest.ContainsKey(questSO.questId))
                idToQuest.Add(questSO.questId, questSO);
        }

        activeQuests = new List<Quest>();

        startedQuests = new List<QuestSO>();
        finishedQuests = new List<QuestSO>();
    }

    void Start()
    {
        setPreviousForQuestData(firstQuestSO);
        Quest firstQuest = new Quest(firstQuestSO);
        firstQuest.doSettings();
    }

    void setPreviousForQuestData(QuestSO questData)
    {
        foreach(QuestSO nextquest in questData.nextQuests)
        {
            if(!nextquest.prevQuests.Contains(questData))
                nextquest.prevQuests.Add(questData);
            setPreviousForQuestData(nextquest);
        }
    }

    public void QuestDone(Quest quest)
    {
        activeQuests.Remove(quest);
        finishedQuests.Add(quest.questData);

        List<QuestSO> nextQuests = quest.NextQuests;

        foreach(QuestSO next in nextQuests)
        {
            if(IsQuestReady(next))
            {
                startedQuests.Add(next);
                Quest newQuest = new Quest(next);
                newQuest.doSettings();
            }

        }
    }

    private bool IsQuestReady(QuestSO questData)
    {
        if(startedQuests.Contains(questData))
            return false;

        foreach(QuestSO prev in questData.prevQuests)
        {
            if(!finishedQuests.Contains(prev))
                return false;
        }

        return true;
    }

    public object CaptureState()
    {
        QuestSaveData questSaveData = new QuestSaveData()
        {
            startedQuestIds = new int[startedQuests.Count],
            finishedQuestIds = new int[finishedQuests.Count],
            activeQuestIds = new int[activeQuests.Count],
            activeQuestCurrentParts = new int[activeQuests.Count]
        };

        for(int i = 0; i < startedQuests.Count; i++)
        {
            questSaveData.startedQuestIds[i] = startedQuests[i].questId;
        }

        for(int i = 0; i < finishedQuests.Count; i++)
        {
            questSaveData.finishedQuestIds[i] = finishedQuests[i].questId;
        }

        for(int i = 0; i < activeQuests.Count; i++)
        {
            questSaveData.activeQuestIds[i] = activeQuests[i].questData.questId;
            questSaveData.activeQuestCurrentParts[i] = activeQuests[i].currentPart;
        }

        return questSaveData;
    }

    public void RestoreState(object state)
    {
        activeQuests.Clear();

        foreach (QuestObject questObject in FindObjectsOfType<QuestObject>())
        {
            questObject.ClearQuestParts();

            if(questObject.TryGetComponent<NPCController>(out NPCController npc))
                npc.ResetDialogueEvents();
        }

        QuestSaveData questSaveData = (QuestSaveData)state;

        foreach(int questId in questSaveData.startedQuestIds)
        {
            var questSO = idToQuest[questId];

            if(startedQuests.Contains(questSO))
                startedQuests.Add(questSO);
        }

        foreach(int questId in questSaveData.finishedQuestIds)
        {
            var questSO = idToQuest[questId];
            
            if(!finishedQuests.Contains(questSO))
                finishedQuests.Add(questSO);
        }

        for(int i = 0; i < questSaveData.activeQuestIds.Length; i++)
        {
            Quest quest = new Quest(idToQuest[questSaveData.activeQuestIds[i]]);
            quest.currentPart = questSaveData.activeQuestCurrentParts[i];

            activeQuests.Add(quest);

            quest.doSettings();
        }
    }

    [Serializable]
    public class QuestSaveData
    {
        public int[] startedQuestIds;
        public int[] finishedQuestIds;
        public int[] activeQuestIds;
        public int[] activeQuestCurrentParts;
    }

    // List<Quest> CurrentQuests
    // {
    //     get {return activeQuests;}
    // } 

    // public bool IsAllQuestsOver()
    // {
    //     return activeQuests.Count == 0;
    // }


}
