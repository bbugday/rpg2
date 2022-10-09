using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {MainMenu, FreeRoam, Dialog}

public class GameManager : Singleton<GameManager> //freeroam manager
{
    [SerializeField] PlayerController playerController;
    [SerializeField] DialogueManager dialogueManager;

    GameState state;

    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject loadButtons;
    [SerializeField] GameObject mainMenuCanvas;

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

        if(Input.GetKeyDown(KeyCode.U))
        {
            string [] files = System.IO.Directory.GetFiles(Application.persistentDataPath + "/savefiles");
            foreach (string file in files)
            {
                Debug.Log(file);
                Debug.Log(System.IO.Path.GetFileName(file));
            }
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("SAVE");
            SavingSystem.i.Save("savefiles/saveSlot2");
        }   
    
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadGame("savefiles/saveSlot2");
        }
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

    private void InstantiateLoadButton(string saveName, int pos)
    {
        GameObject buttonObject = Instantiate(buttonPrefab);
        var button = buttonObject.GetComponent<UnityEngine.UI.Button>();
        button.transform.parent = loadButtons.transform;
        buttonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,240,0) - Vector3.up * pos * 62;
        button.onClick.AddListener(() => SavingSystem.i.Load("savefiles/" + saveName));
        button.onClick.AddListener(() => mainMenuCanvas.SetActive(false));
        button.onClick.AddListener(() => StartFreeroam());
        button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(saveName);
    }

    public void LoadButtonsCreator()
    {
        string [] files = System.IO.Directory.GetFiles(Application.persistentDataPath + "/savefiles");
        int i = 0;
        foreach (string file in files)
        {
            InstantiateLoadButton(System.IO.Path.GetFileName(file), i);
            i++;
        }
    }
}
