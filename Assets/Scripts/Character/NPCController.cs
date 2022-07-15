using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    List<Quest> quests;//quest yap interactta seçtir

    public void Interact()
    {
        //quest
        if(quests != null)
        {
            DialogueManager.Instance.ShowQuestDialog(quests[0].CurrentQuestPart.QuestDialogue, quests[0]);

            //Foreach tehlikeli! döngü bitmeden görevler editleniyor bu yüzden bozulabilir. Menüyle yap.

            // foreach(Quest quest in quests)
            // {
            //     DialogueManager.Instance.ShowQuestDialog(quest.CurrentQuestPart.QuestDialogue, quest);
            // }
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

    // public Quest Quest
    // {   
    //     get{return quest;}
    // }

}
