using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    private List<QuestPart> questParts;

    [SerializeField] QuestSO questData;

    public Quest(QuestSO data)
    {
        questData = data;
        questParts = questData.questParts.ConvertAll(q => q.Clone()); //to prevent scriptable objects deleted

        foreach(QuestPart questPart in questParts)
        {
            questPart.SetQuest(this);
        }
    }

    public void doSettings()
    {
        CurrentQuestPart.doSettings();
    }

    //run when questpart is done
    public void doneQuestPart()
    {
        questParts.RemoveAt(0); //remove that quest part
        if(!IsAllQuestPartsOver())
            doSettings();
        else
            Finished();
    }

    public bool IsAllQuestPartsOver()
    {
        return questParts.Count == 0;
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
