using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] QuestSO firstQuestSO;
    //[SerializeField] List<Quest> activeQuests;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        Quest firstQuest = new Quest(firstQuestSO);
        firstQuest.doSettings();
    }

    public void QuestDone(Quest quest)
    {
        List<QuestSO> nextQuests = quest.NextQuests;

        foreach(QuestSO next in nextQuests)
        {
            if(IsQuestReady(next))
            {
                Quest newQuest = new Quest(next);
                newQuest.doSettings();
            }

        }
    }

    private bool IsQuestReady(QuestSO quest)
    {
        foreach(QuestSO prev in quest.prevQuests)
        {
            if(prev.done == false)
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

    public void AddQuestToNPC(NPCController npc, Quest quest)
    {
        npc.AddQuest(quest);
    }

}
