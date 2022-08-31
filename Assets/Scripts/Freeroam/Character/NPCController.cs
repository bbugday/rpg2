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

        if(npcSO.dialogueQuests != null && npcSO.dialogueQuests.Count != 0)
        {
            DialogueQuest dialogueQuest = npcSO.dialogueQuests[0];
            DialogueManager.Instance.ShowInkDialog(dialogueQuest.InkDialogue);

            npcSO.dialogueEvent.Invoke(dialogueQuest);
        }
    }
}
