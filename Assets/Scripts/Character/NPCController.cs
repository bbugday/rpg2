using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    QuestPart questPart;

    public void Interact()
    {
        //quest
        if(questPart != null)
        {
            DialogueManager.Instance.ShowQuestDialog(questPart.QuestDialogue, this);
        }
    }

    public void RemoveQuestPart()
    {
        questPart = null;
    }

    public void AddQuestPart(QuestPart questPart)
    {
        this.questPart = questPart;
    }

    public QuestPart QuestPart
    {   
        get{return questPart;}
    }

}
