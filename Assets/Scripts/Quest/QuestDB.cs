using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDB", menuName = "ScriptableObjects/QuestDB", order = 1)]
public class QuestDB : ScriptableObject
{
    [SerializeField] List<QuestSO> quests;
    public Dictionary<int, QuestSO> idToQuest;
    
    void OnEnable()
    {
        foreach(QuestSO questData in quests)
        {
            idToQuest.Add(questData.questId, questData);
        }
    }
}
