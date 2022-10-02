using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public List<QuestPart> questParts;

    void Awake()
    {
        questParts = new List<QuestPart>();
    }

    public void AddQuestPart(QuestPart questPart)
    {
        questParts.Add(questPart);
    }

    public void RemoveQuestPart(QuestPart questPart)
    {
        questParts.Remove(questPart);
    }
}
