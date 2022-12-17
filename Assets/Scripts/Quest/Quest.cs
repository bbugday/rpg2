using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    private List<QuestPart> questParts;

    [SerializeField] public QuestSO questData{get; private set;}

    public int currentPart;

    public Quest(QuestSO data)
    {
        questData = data;
        questParts = questData.questParts;

        currentPart = 0;

        foreach(QuestPart questPart in questParts)
        {
            questPart.SetQuest(this);
        }
    }

    public void doSettings()
    {
        Debug.Log("do settings " + "quest title: " + questData.questTitle + " quest part: " + currentPart);

        if(!QuestManager.Instance.activeQuests.Contains(this))
            QuestManager.Instance.activeQuests.Add(this);

        questParts[currentPart].doSettings(); 
    }

    public void RemoveSettings()
    {
        questParts[currentPart].RemoveSettings(); 
    }

    //run when questpart is done
    public void doneQuestPart()
    {
        currentPart++;
        if(!IsAllQuestPartsOver())
            doSettings();
        else
            Finished();
    }

    public bool IsAllQuestPartsOver()
    {
        return currentPart == questParts.Count;
    }

    void Finished()
    {
        QuestManager.Instance.QuestDone(this);
        PlayerDataManager.Instance.AddGold(questData.questGold);
    }

    public List<QuestSO> NextQuests
    {
        get {return questData.nextQuests;}
    }

    public QuestPart GetCurrentPart
    {
        get {return questParts[currentPart];}
    } 
}
