using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class QuestPart : ScriptableObject
{
    public abstract void doSettings();
    public abstract void doneQuestPart();
    public abstract void SetQuest(Quest quest);
}
