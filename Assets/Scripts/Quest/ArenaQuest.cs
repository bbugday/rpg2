using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArenaQuest", menuName = "ScriptableObjects/ArenaQuestScriptableObject", order = 1)]

public class ArenaQuest : QuestPart
{
    [SerializeField] string arenaName;

	private ArenaSO arena;

    public override void doneQuestPart()
    {
		Debug.Log("Cleared");
    }

    public override void doSettings()
    {
		arena = GameManager.Instance.objectsDB.GetArena(arenaName);
		arena.onClearEvent += doneQuestPart;
    }
}
