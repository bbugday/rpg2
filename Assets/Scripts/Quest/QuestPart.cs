using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType{Dialog, Kill, Collect}

[System.Serializable]
public class QuestPart
{
    [SerializeField] QuestType questType;

    [SerializeField] NPCController npc;
    [SerializeField] Dialogue dialogue;

    public Dialogue QuestDialogue
    {
        get {return dialogue;}
    }

    public QuestType QuestType
    {
        get {return questType;}
    }

    public NPCController Npc
    {
        get {return npc;}
    }

}
