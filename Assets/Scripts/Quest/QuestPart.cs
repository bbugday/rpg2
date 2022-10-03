using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class QuestPart : ScriptableObject
{
    protected Quest quest;

    public abstract void doSettings();
    public abstract void RemoveSettings();
    
    public void SetQuest(Quest quest)
    {
        this.quest = quest;
    }
}
