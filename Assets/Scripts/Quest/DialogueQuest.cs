using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueQuest", menuName = "ScriptableObjects/DialogueQuestScriptableObject", order = 1)]

public class DialogueQuest : QuestPart
{
    [SerializeField] string npcName;

    [SerializeField] TextAsset inkDialogue;

    private NPCController npc;

    Quest quest;

    public DialogueQuest(string npcName, TextAsset inkDialogue)
    {
        this.npcName = npcName;
        this.inkDialogue = inkDialogue;
    }

    private void OnEnable()
    {
        this.npc = GameObject.Find(npcName).GetComponent<NPCController>();
    }

    public override void SetQuest(Quest quest)
    {
        this.quest = quest;
    }

    public override void doSettings()
    {
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
