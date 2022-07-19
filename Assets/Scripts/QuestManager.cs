using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] QuestSO firstQuestSO;
    [SerializeField] List<Quest> activeQuests;


    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        Quest firstQuest = new Quest(firstQuestSO);
        firstQuest.doSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    // Quest CurrentQuest
    // {
    //     get {return quests[0];}
    // } 

    // public bool IsAllQuestsOver()
    // {
    //     return quests.Count == 0;
    // }

    public void AddQuestToNPC(NPCController npc, Quest quest)
    {
        npc.AddQuest(quest);
    }

}
