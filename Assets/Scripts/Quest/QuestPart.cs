using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum QuestType{Dialog, Kill, Collect}

[System.Serializable]
public class QuestPart
{
    [SerializeField] QuestType questType;

    [SerializeField] NPCController npc;
    [SerializeField] Dialogue dialogue;

    public void CompleteQuestPart()
    {
        if(questType == QuestType.Dialog)
            npc.RemoveQuestPart();
            
        QuestManager.Instance.questPartDone();
    }

    public void doSettings()
    {
        if(questType == QuestType.Dialog)
        {
            QuestManager.Instance.AddQuestPartToNPC(npc, this);
        }
    }

    public Dialogue QuestDialogue
    {
        get {return dialogue;}
    }

}
