using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcSO", menuName = "ScriptableObjects/NpcScriptableObject", order = 1)]
public class NpcSO : ScriptableObject
{
    private NPCController npc;

    public delegate void DialogueEvent(DialogueQuest dialogueQuest);
    public DialogueEvent dialogueEvent;

    public List<DialogueQuest> dialogueQuests;

    private void Awake()
    {
        dialogueQuests = new List<DialogueQuest>();
    }

    public void ClearNullQuests()
    {
        dialogueQuests.RemoveAll(item => item == null);
    }

    public void AddNpc(NPCController npc)
    {
        this.npc = npc;
    }

    public void AddQuestPart(DialogueQuest dialogueQuest)
    {
        dialogueQuests.Add(dialogueQuest);
    }

    public void RemoveQuestPart(DialogueQuest dialogueQuest)
    {
        dialogueQuests.Remove(dialogueQuest);
    }

}
