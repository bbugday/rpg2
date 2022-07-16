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
    }

    public void doSettings()
    {
        questParts = questData.questParts.ConvertAll(q => q.Clone());

        //questParts = questData.questParts;//deep copy instead

        if(CurrentQuestPart.QuestType == QuestType.Dialog)
        {
            QuestManager.Instance.AddQuestToNPC(CurrentQuestPart.Npc, this);
        }
    }

    //run when questpart is done
    public void questPartDone()
    {
        if(questParts[0].QuestType == QuestType.Dialog)
            questParts[0].Npc.RemoveQuest(this);

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
