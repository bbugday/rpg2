using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InkQuest", menuName = "ScriptableObjects/InkQuestScriptableObject", order = 1)]

public class InkQuest : QuestPart
{

    [SerializeField] string npcName;

    [SerializeField] TextAsset inkDialogue;

    public InkQuest(string npcName, TextAsset inkDialogue)
    {
        this.npcName = npcName;
        this.inkDialogue = inkDialogue;
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

    public TextAsset InkDialogue
    {
        get {return inkDialogue;}
    }
}
