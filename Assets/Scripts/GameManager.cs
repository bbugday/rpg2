using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialog}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerController playerController;
    [SerializeField] DialogueManager dialogueManager;

    GameState state;
    
    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        state = GameState.FreeRoam;
    }

    void Update()
    {
        if(state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if(state == GameState.Dialog)
        {
            dialogueManager.HandleUpdate();
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            SavingSystem.i.Save("saveSlot1");
        }   
    
        if(Input.GetKeyDown(KeyCode.L))
        {
            SavingSystem.i.Load("saveSlot1");
        }
    }

    public void setState(GameState newState)
    {
        state = newState;
    }
}
