using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    private List<QuestPart> questParts;

    [SerializeField] QuestSO questData;

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
        questParts[currentPart].doSettings();
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
        questData.done = true;
        QuestManager.Instance.QuestDone(this);
        //quest reward
    }

    public List<QuestSO> NextQuests
    {
        get {return questData.nextQuests;}
    } 

    public QuestPart CurrentQuestPart
    {
        get {return questParts[0];}
    } 
}
