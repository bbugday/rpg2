using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] QuestSO firstQuestSO;

    private List<QuestSO> startedQuests;
    private List<QuestSO> finishedQuests;

    public List<Quest> activeQuests{get; set;}//questso or quest or id?

    public override void Awake()
    {
        base.Awake();

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

    // List<Quest> CurrentQuests
    // {
    //     get {return activeQuests;}
    // } 

    // public bool IsAllQuestsOver()
    // {
    //     return activeQuests.Count == 0;
    // }


}
