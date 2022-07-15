using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField] List<QuestPart> questParts;

    public void doSettings()
    {
        if(CurrentQuestPart.QuestType == QuestType.Dialog)
        {
            QuestManager.Instance.AddQuestToNPC(CurrentQuestPart.Npc, this);
        }
    }

    //run when questpart is done
    public void questPartDone()
    {
        if(questParts[0].QuestType == QuestType.Dialog)
            questParts[0].Npc.RemoveQuest();

        questParts.RemoveAt(0); //remove that quest part
        if(!IsAllQuestPartsOver())
            doSettings();
        else
            Finished();
    }

    public bool IsAllQuestPartsOver()
    {
        return questParts.Count == 0;
    }

    void Finished()
    {
        QuestManager.Instance.QuestDone();
        //quest reward
    }

    public QuestPart CurrentQuestPart
    {
        get {return questParts[0];}
    } 
}
