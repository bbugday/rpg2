using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : QuestObject, Interactable
{
    public delegate void DialogueEvent(QuestPart dialogueQuest);
    public DialogueEvent dialogueEvent;

    public void Interact()
    {
        //multi quests being shown one by one

        if(questParts != null && questParts.Count != 0)
        {
            DialogueQuest dialogueQuest = questParts[0] as DialogueQuest;
            DialogueManager.Instance.ShowInkDialog(dialogueQuest.InkDialogue);

            dialogueEvent.Invoke(dialogueQuest);
        }
    }

    public void ResetDialogueEvents()
    {
        dialogueEvent = null;
    }
}
