using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestObjectSO : ScriptableObject
{
    public List<QuestPart> questParts;

    private void Awake()
    {
        questParts = new List<QuestPart>();
    }

    public void ClearNullQuests()
    {
        questParts.RemoveAll(item => item == null);
    }
    
    public void AddQuestPart(QuestPart arenaQuest)
    {
        questParts.Add(arenaQuest);
    }

    public void RemoveQuestPart(QuestPart arenaQuest)
    {
        questParts.Remove(arenaQuest);
    }
}