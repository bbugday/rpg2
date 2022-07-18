using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class QuestPart : ScriptableObject
{

    

    public Dialogue dialogue; //bad practice

    public abstract void doSettings(Quest quest);
    public abstract void doneQuestPart(Quest quest);

    public Dialogue QuestDialogue
    {
        get {return dialogue;}
    }
}
