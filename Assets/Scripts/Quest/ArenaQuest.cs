using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaQuest : QuestPart
{
    [SerializeField] string arenaName;

    public override void doneQuestPart(Quest quest)
    {

    }

    public override void doSettings(Quest quest)
    {
        //QuestManager.Instance.AddQuestToNPC(Npc, quest);
    }

}
