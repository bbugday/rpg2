using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestScriptableObject", order = 1)]
[System.Serializable]

public class QuestSO : ScriptableObject
{
    void OnEnable()
    {
        prevQuests.Clear();
        started = false;
        done = false;
    }

    public string questTitle;

    public List<QuestPart> questParts;

    public List<QuestSO> prevQuests;
    public List<QuestSO> nextQuests;

    public bool started = false;
    public bool done = false;

    public Rect position = new Rect(0, 0, 150, 200);

}
