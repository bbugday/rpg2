using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField] List<QuestPart> questParts;

    public void doSettings()
    {
        questParts[0].doSettings();
    }
}
