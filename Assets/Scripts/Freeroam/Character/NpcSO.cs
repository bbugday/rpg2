using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcSO", menuName = "ScriptableObjects/NpcScriptableObject", order = 1)]
public class NpcSO : QuestObjectSO
{
    public delegate void DialogueEvent(QuestPart dialogueQuest);
    public DialogueEvent dialogueEvent;
}
