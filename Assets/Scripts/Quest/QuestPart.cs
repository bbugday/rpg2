using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class QuestPart : ScriptableObject
{
    public abstract void doSettings(Quest quest);
    public abstract void doneQuestPart(Quest quest);
}
