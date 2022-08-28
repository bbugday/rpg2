using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArenaQuest", menuName = "ScriptableObjects/ArenaQuestScriptableObject", order = 1)]

public class ArenaQuest : QuestPart
{
	[SerializeField] ArenaSO arenaSO;

    public override void doSettings()
    {
        arenaSO.EnableEntry();
        arenaSO.onClearEvent += doneQuestPart;
    }

	public void doneQuestPart()
    {
		Debug.Log("Cleared");
        quest.doneQuestPart();
    }
}
