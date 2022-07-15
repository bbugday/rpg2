using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType{Dialog, Kill, Collect}

[System.Serializable]
public class QuestPart
{
    [SerializeField] QuestType questType;

    [SerializeField] string npcName;
    //[SerializeField] NPCController npc;//Serialize field yerine ismiyle al
    [SerializeField] Dialogue dialogue;

    public Dialogue QuestDialogue
    {
        get {return dialogue;}
    }

    public QuestType QuestType
    {
        get {return questType;}
    }

    public NPCController Npc //böyle yapmak yerine oyunun başında eşleştir. her seferinde aramasın
    {
        get {return GameObject.Find(npcName).GetComponent<NPCController>();}
    }

    public QuestPart Clone() {
        return new QuestPart {questType = this.questType, npcName = this.npcName, dialogue = this.dialogue};
    }

}
