using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    Quest quest;//quest yap interactta seçtir

    public void Interact()
    {
        //quest
        if(quest != null)
        {
            DialogueManager.Instance.ShowQuestDialog(quest.CurrentQuestPart.QuestDialogue, this);
        }
    }

    public void RemoveQuest()
    {
        quest = null;
    }

    public void AddQuest(Quest quest)
    {
        this.quest = quest;
    }

    public Quest Quest
    {   
        get{return quest;}
    }

}
