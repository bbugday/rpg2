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
        //reward?
        if(!isFinished())
            doSettings();
    }

    public bool isFinished()
    {
        return questParts.Count == 0;
    }

    QuestPart CurrentQuestPart
    {
        get {return questParts[0];}
    } 
}
