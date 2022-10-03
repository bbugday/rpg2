using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArenaQuest", menuName = "ScriptableObjects/ArenaQuestScriptableObject", order = 1)]

public class ArenaQuest : QuestPart
{
    [SerializeField] string entryPointName; 

    private ArenaEntryPoint entryPoint;

    public override void doSettings()
    {
        entryPoint = GameObject.Find(entryPointName).GetComponent<ArenaEntryPoint>();
        entryPoint.AddQuestPart(this);
        entryPoint.arenaSO.onClearEvent += doneQuestPart; 
    }

    public override void RemoveSettings()
    {
        entryPoint.RemoveQuestPart(this);
        entryPoint.arenaSO.onClearEvent -= doneQuestPart;
    }

	public void doneQuestPart()
    {
        RemoveSettings();
        quest.doneQuestPart();
    }
}
