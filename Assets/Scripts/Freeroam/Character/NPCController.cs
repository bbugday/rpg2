using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] NpcSO npcSO;

    private void Awake()
    {
        npcSO.ClearNullQuests();
    }

    public void Interact()
    {
        //multi quests being shown one by one

        if(npcSO.questParts != null && npcSO.questParts.Count != 0)
        {
            DialogueQuest dialogueQuest = npcSO.questParts[0] as DialogueQuest;
            DialogueManager.Instance.ShowInkDialog(dialogueQuest.InkDialogue);

            npcSO.dialogueEvent.Invoke(dialogueQuest);
        }
    }
}
