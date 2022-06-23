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

    public void doSettings()
    {
        if(questType == QuestType.Dialog)
        {
            npc.dialogue = dialogue;
            npc.onFinishDialog += finished;
        }
    }

    void finished()
    {
        npc.dialogue = null;
        npc.onFinishDialog -= finished;
        QuestManager.Instance.questPartDone();
    }

    //triggeri buraya koy npcde çalıştır?

    //onfinish
}
