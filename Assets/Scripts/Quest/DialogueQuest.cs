using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueQuest", menuName = "ScriptableObjects/DialogueQuestScriptableObject", order = 1)]

public class DialogueQuest : QuestPart
{
    [SerializeField] string npcName;

    [SerializeField] TextAsset inkDialogue;

    private NPCController npc;

    public DialogueQuest(string npcName, TextAsset inkDialogue)
    {
        this.npcName = npcName;
        this.inkDialogue = inkDialogue;
    }

    public override void doSettings()
    {
        this.npc = GameObject.Find(npcName).GetComponent<NPCController>();
        AddQuestToNPC();
    }

    public override void doneQuestPart()
    {
        npc.RemoveQuestPart(this);
        quest.doneQuestPart();
    }
    
    private void AddQuestToNPC()
    {
        npc.AddQuestPart(this);
    }

    public TextAsset InkDialogue
    {
        get {return inkDialogue;}
    }
}
