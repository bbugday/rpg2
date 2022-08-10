using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestScriptableObject", order = 1)]
[System.Serializable]

public class QuestSO : ScriptableObject
{
    public string questTitle;

    public List<QuestPart> questParts;

    public List<QuestSO> prevQuests;
    public List<QuestSO> nextQuests;

    public bool started = false;
    public bool done = false;
}
