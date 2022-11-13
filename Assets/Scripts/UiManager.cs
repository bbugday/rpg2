using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject loadButtons;
    [SerializeField] GameObject saveButtons;
    [SerializeField] GameObject mainButtons;
    [SerializeField] GameObject pauseButtons;
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject questWindowCanvas;
    [SerializeField] GameObject questTextPrefab;


    private List<GameObject> dynamicButtons;

    void Awake()
    {
        dynamicButtons = new List<GameObject>();
    }

    public void OpenPauseMenu()
    {
        pauseMenuCanvas.SetActive(true);
        StartCoroutine(SelectFirstButton());
    }

    public void ClosePauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
    }


    public void LoadButtonsCreator()
    {
        string [] files = System.IO.Directory.GetFiles(Application.persistentDataPath + "/savefiles");
        int i = 1;
        foreach (string file in files)
        {
            InstantiateLoadButton(System.IO.Path.GetFileName(file), i);
            i++;
        }
        StartCoroutine(UiManager.SelectFirstButton());
    }

    public void SaveButtonsCreator()
    {
        string [] files = System.IO.Directory.GetFiles(Application.persistentDataPath + "/savefiles");
        int i = 1;
        foreach (string file in files)
        {
            InstantiateSaveButton(System.IO.Path.GetFileName(file), i);
            i++;
        }
        if(i < 9)
        {
            InstantiateSaveButton("save" + i, i, "NEW SAVE");
        }
        StartCoroutine(UiManager.SelectFirstButton());
    }

    private void InstantiateLoadButton(string saveName, int pos)
    {
        GameObject buttonObject = Instantiate(buttonPrefab);
        dynamicButtons.Add(buttonObject);
        var button = buttonObject.GetComponent<UnityEngine.UI.Button>();
        button.transform.SetParent(loadButtons.transform);
        buttonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,302,0) - Vector3.up * pos * 62;
        button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(saveName);
        button.onClick.AddListener(() => {
            SavingSystem.i.Load("savefiles/" + saveName);
            mainButtons.SetActive(true);
            loadButtons.SetActive(false);
            mainMenuCanvas.SetActive(false);
            GameManager.Instance.StartFreeroam();
            DestroyDynamicButtons();
        });
    }

    private void InstantiateSaveButton(string saveName, int pos, string displayName = null)
    {
        if(displayName == null) {displayName = saveName;};
        GameObject buttonObject = Instantiate(buttonPrefab);
        dynamicButtons.Add(buttonObject);
        var button = buttonObject.GetComponent<UnityEngine.UI.Button>();
        button.transform.SetParent(saveButtons.transform);
        buttonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,302,0) - Vector3.up * pos * 62;
        button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(displayName);
        button.onClick.AddListener(() => {
            SavingSystem.i.Save("savefiles/" + saveName);
            saveButtons.SetActive(false);
            pauseButtons.SetActive(true);
            pauseMenuCanvas.SetActive(false);
            GameManager.Instance.StartFreeroam();
            DestroyDynamicButtons();
        });
    }

    public void DestroyDynamicButtons()
    {
        dynamicButtons.ForEach(button => Destroy(button.gameObject));
        dynamicButtons.Clear();
    }

    int i = 0;

    public void OpenCloseQuestWindow()
    {
        int questCount = QuestManager.Instance.activeQuests.Count;

        if(questCount == 0) return;

        if(!questWindowCanvas.gameObject.activeSelf)
        {
            i = 0;
            questWindowCanvas.gameObject.SetActive(true);
            InstantiateQuestText(QuestManager.Instance.activeQuests[0].questData);
        }
        else if(i + 1 < questCount)
        {
            foreach (Transform child in questWindowCanvas.transform.GetChild(0).transform)
                Destroy(child.gameObject);
            InstantiateQuestText(QuestManager.Instance.activeQuests[++i].questData);
        }
        else
        {
            questWindowCanvas.gameObject.SetActive(false);
            foreach (Transform child in questWindowCanvas.transform.GetChild(0).transform)
                Destroy(child.gameObject);
        }


        // if(questWindowCanvas.gameObject.activeSelf)
        // {
        //     questWindowCanvas.gameObject.SetActive(false);
        //     foreach (Transform child in questWindowCanvas.transform.GetChild(0).transform)
        //         Destroy(child.gameObject);
        // }
        // else
        // {
        //     questWindowCanvas.gameObject.SetActive(true);
        //     foreach(Quest quest in QuestManager.Instance.activeQuests)
        //         InstantiateQuestText(0, quest.questData);
        // } 
    }

    private void InstantiateQuestText(QuestSO questData)
    {
        GameObject obj = Instantiate(questTextPrefab);
        obj.GetComponent<Text>().text = questData.questTitle;  
        obj.transform.SetParent(questWindowCanvas.transform.GetChild(0), false);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0); //- Vector3.up * pos * 62;
    }

    public void SelectFirstButtonEvent()
    {
        StartCoroutine(UiManager.SelectFirstButton());
    } 

    public static IEnumerator SelectFirstButton() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.

        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        var button = FindObjectOfType<Button>().gameObject;
        EventSystem.current.SetSelectedGameObject(button);
    }
}
