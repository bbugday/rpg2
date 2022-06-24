using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField] List<QuestPart> questParts;

    public void doSettings()
    {
        CurrentQuestPart.doSettings();
    }

    //run when questpart is done
    public void questPartDone()
    {
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

    QuestPart CurrentQuestPart
    {
        get {return questParts[0];}
    } 
}
