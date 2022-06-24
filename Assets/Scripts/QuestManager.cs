using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] List<Quest> quests;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentQuest.doSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void questPartDone()
    {
        CurrentQuest.questPartDone();
    }

    public void QuestDone()
    {
        quests.RemoveAt(0);
        if(!IsAllQuestsOver())
        {
            CurrentQuest.doSettings();
        }
    }

    Quest CurrentQuest
    {
        get {return quests[0];}
    } 

    public bool IsAllQuestsOver()
    {
        return quests.Count == 0;
    }

}
