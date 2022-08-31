using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Arena", menuName = "ScriptableObjects/ArenaScriptableObject", order = 1)]
public class ArenaSO : ScriptableObject
{
    public string arenaSceneName;

    public List<ArenaQuest> arenaQuests;

    public delegate void OnClearEvent();
    public OnClearEvent onClearEvent;

    private void Awake()
    {
        arenaQuests = new List<ArenaQuest>();
    }

    public void ClearNullQuests()
    {
        arenaQuests.RemoveAll(item => item == null);
    }
    
    public void AddQuestPart(ArenaQuest arenaQuest)
    {
        arenaQuests.Add(arenaQuest);
    }

    public void RemoveQuestPart(ArenaQuest arenaQuest)
    {
        arenaQuests.Remove(arenaQuest);
    }

}
