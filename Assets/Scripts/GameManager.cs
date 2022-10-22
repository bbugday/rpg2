using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {MainMenu, PauseMenu, FreeRoam, Dialog, Shop}

public class GameManager : Singleton<GameManager> //freeroam manager
{
    [SerializeField] PlayerController playerController;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] ShopController shopController;

    GameState state;

    UiManager uiManager;

    public override void Awake()
    {
        base.Awake();

        uiManager = GetComponent<UiManager>();
    }

    void Start()
    {
        state = GameState.MainMenu;

        #if UNITY_EDITOR
            state = GameState.FreeRoam;
        #endif
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(state == GameState.FreeRoam || state == GameState.Dialog)
            {
                state = GameState.PauseMenu;
                uiManager.OpenPauseMenu();
            }
            // else if(state == GameState.PauseMenu)
            // {
            //     state = GameState.FreeRoam;
            //     uiManager.ClosePauseMenu();
            // }
        }

        // if(Input.GetKeyDown(KeyCode.U))
        // {
        //     string [] files = System.IO.Directory.GetFiles(Application.persistentDataPath + "/savefiles");
        //     foreach (string file in files)
        //     {
        //         Debug.Log(file);
        //         Debug.Log(System.IO.Path.GetFileName(file));
        //     }
        // }

        // if(Input.GetKeyDown(KeyCode.O))
        // {
        //     Debug.Log("SAVE");
        //     SavingSystem.i.Save("savefiles/saveSlot2");
        // }   
    
        // if(Input.GetKeyDown(KeyCode.L))
        // {
        //     LoadGame("savefiles/saveSlot2");
        // }
    }

    public void LoadGame(string save)
    {
        SavingSystem.i.Load("savefiles/saveSlot2");
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
