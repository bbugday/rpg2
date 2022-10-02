using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDB", menuName = "ScriptableObjects/QuestDB", order = 1)]
public class QuestDB : ScriptableObject
{
    public List<QuestSO> quests;
}
