using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    List<Quest> quests;

    public void Interact()
    {
        //multi quests being shown one by one

        if(quests != null && quests.Count != 0)
        {
            DialogueQuest dialogueQuest = quests[0].CurrentQuestPart as DialogueQuest;
            DialogueManager.Instance.ShowInkDialog(dialogueQuest.InkDialogue);
            quests[0].doneQuestPart();
        }
    }

    public void RemoveQuest(Quest quest)
    {
        quests.Remove(quest);
    }

    public void AddQuest(Quest quest)
    {
        if(quests == null)
            quests = new List<Quest>();

        quests.Add(quest);
    }

}
