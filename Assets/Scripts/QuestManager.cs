using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestManager : MonoBehaviour
{
    [SerializeField] List<Quest> quests;
    
    //Activequest tutmaya gerek yok, quest[0] zaten activequest.
    //2 quest birden alma?

    // Start is called before the first frame update
    void Start()
    {
        quests[0].doSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void questPartDone()
    {
        //questpart.pop();
        //if(questparts boş değil) { questpart.ayarlamalarıyap()}
        //if(questparts boş)
        //quest.pop();
        //yeniquest.ayarlamalarıyap
    }
}
