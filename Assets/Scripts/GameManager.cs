using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialog}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerController playerController;
    [SerializeField] DialogueManager dialogueManager;
    GameState state;

    // Start is called before the first frame update
    
    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        state = GameState.FreeRoam;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.FreeRoam)
        {
            //do it with action?
            playerController.HandleUpdate();
        }
        else if(state == GameState.Dialog)
        {
            dialogueManager.HandleUpdate();
        }
    }

    public void setState(GameState newState)
    {
        state = newState;
    }
}
