using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueQuest", menuName = "ScriptableObjects/DialogueQuestScriptableObject", order = 1)]

public class DialogueQuest : QuestPart
{
    [SerializeField] TextAsset inkDialogue;

    [SerializeField] NpcSO npcSO;

    public DialogueQuest(string npcName, TextAsset inkDialogue)
    {
        this.inkDialogue = inkDialogue;
    }

    public override void doSettings()
    {
        npcSO.npc.AddQuestPart(this);
    }

    public override void doneQuestPart()
    {
        npcSO.npc.RemoveQuestPart(this);
        quest.doneQuestPart();
    }

    public TextAsset InkDialogue
    {
        get {return inkDialogue;}
    }
}
