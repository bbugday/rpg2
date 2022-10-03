using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueQuest", menuName = "ScriptableObjects/DialogueQuestScriptableObject", order = 1)]

public class DialogueQuest : QuestPart
{
    [SerializeField] TextAsset inkDialogue;

    [SerializeField] string npcName;

    private NPCController npc;

    public override void doSettings()
    {
        npc = GameObject.Find(npcName).GetComponent<NPCController>();
        npc.AddQuestPart(this);
        npc.dialogueEvent += doneQuestPart;
    }

    public override void RemoveSettings()
    {
        npc.RemoveQuestPart(this);
        npc.dialogueEvent -= doneQuestPart;
    }


    public void doneQuestPart(QuestPart dialogueQuest)
    {
        if(this == dialogueQuest)
        {
            RemoveSettings();
            quest.doneQuestPart();
        }
    }

    public TextAsset InkDialogue
    {
        get {return inkDialogue;}
    }
}
