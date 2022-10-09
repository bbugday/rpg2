using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {MainMenu, FreeRoam, Dialog}

public class GameManager : Singleton<GameManager> //freeroam manager
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
        state = GameState.MainMenu;
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
            Debug.Log("SAVE");
            SavingSystem.i.Save("saveSlot2");
        }   
    
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("LOAD");
            SavingSystem.i.Load("saveSlot2");
        }
    }

    public void LoadGame(string save)
    {
        SavingSystem.i.Load("saveSlot2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void setState(GameState newState)
    {
        state = newState;
    }

    public void StartFreeroam()
    {
        state = GameState.FreeRoam;
    }
}
