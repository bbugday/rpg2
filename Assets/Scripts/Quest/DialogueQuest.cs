using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueQuest", menuName = "ScriptableObjects/DialogueQuestScriptableObject", order = 1)]

public class DialogueQuest : QuestPart
{

    [SerializeField] string npcName;

    [SerializeField] Dialogue dialogue;

    public DialogueQuest(string npcName, Dialogue dialogue)
    {
        this.npcName = npcName;
        this.dialogue = dialogue;
    }

    public override void doSettings(Quest quest)
    {
        QuestManager.Instance.AddQuestToNPC(Npc, quest);
    }

    public override void doneQuestPart(Quest quest)
    {
        Npc.RemoveQuest(quest);
    }

    public NPCController Npc //böyle yapmak yerine oyunun başında eşleştir. her seferinde aramasın
    {
        get {return GameObject.Find(npcName).GetComponent<NPCController>();}
    }

    public Dialogue QuestDialogue
    {
        get {return dialogue;}
    }
}
