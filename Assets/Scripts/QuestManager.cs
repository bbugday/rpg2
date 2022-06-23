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
    
    //Activequest tutmaya gerek yok, quest[0] zaten activequest.
    //2 quest birden alma?

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
        if(CurrentQuest.isFinished())
        {
            QuestDone();
        }
        //if(questparts boş değil) { questpart.ayarlamalarıyap()}
        //if(questparts boş)
        //quest.pop();
        //yeniquest.ayarlamalarıyap
    }

    void QuestDone()
    {
        quests.RemoveAt(0);
    }

    Quest CurrentQuest
    {
        get {return quests[0];}
    } 

}
