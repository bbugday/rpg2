using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    List<Quest> quests;

    List<DialogueQuest> dialogueQuests;

    private void Awake()
    {
        dialogueQuests = new List<DialogueQuest>();
    }

    public void Interact()
    {
        //multi quests being shown one by one

        if(dialogueQuests != null && dialogueQuests.Count != 0)
        {
            DialogueQuest dialogueQuest = dialogueQuests[0];
            DialogueManager.Instance.ShowInkDialog(dialogueQuest.InkDialogue);
            dialogueQuests[0].doneQuestPart();
        }
    }

    public void RemoveQuestPart(DialogueQuest questPart)
    {
        dialogueQuests.Remove(questPart);
    }

    public void AddQuestPart(DialogueQuest dialogueQuest)
    {
        dialogueQuests.Add(dialogueQuest);
    }


}
