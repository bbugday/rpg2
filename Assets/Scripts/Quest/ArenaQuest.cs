using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArenaQuest", menuName = "ScriptableObjects/ArenaQuestScriptableObject", order = 1)]

public class ArenaQuest : QuestPart
{
	[SerializeField] ArenaSO arena;

    public override void doSettings()
    {
        arena.EnableEntry();
        arena.onClearEvent += doneQuestPart;
    }

	public override void doneQuestPart()
    {
		Debug.Log("Cleared");
        quest.doneQuestPart();
    }

}
