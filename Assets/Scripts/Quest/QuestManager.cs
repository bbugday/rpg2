using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] QuestSO firstQuestSO;

    public QuestDB questDB;

    //[SerializeField] List<Quest> activeQuests;

    public override void Awake()
    {
        base.Awake();

        questDB = new QuestDB();
    }

    void Start()
    {
        setPreviousForQuestData(firstQuestSO);
        Quest firstQuest = new Quest(firstQuestSO, questDB);
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
        List<QuestSO> nextQuests = quest.NextQuests;

        foreach(QuestSO next in nextQuests)
        {
            if(IsQuestReady(next))
            {
                next.started = true;
                Quest newQuest = new Quest(next, questDB);
                newQuest.doSettings();
            }

        }
    }

    private bool IsQuestReady(QuestSO questData)
    {
        if(questData.started)
            return false;

        foreach(QuestSO prev in questData.prevQuests)
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


}
