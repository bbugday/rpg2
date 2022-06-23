using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use singleton??
public class DialogueManager : Singleton<DialogueManager>
{

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HandleUpdate()
    {

    }

    
    public void showDialog(Dialogue dialogue)
    {
        foreach(string line in dialogue.Lines)
        {
            Debug.Log(line);
        }
    }

}
