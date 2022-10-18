using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void OpenCloseQuestWindow()
    {
        if(questWindowCanvas.gameObject.activeSelf)
        {
            questWindowCanvas.gameObject.SetActive(false);
            foreach (Transform child in questWindowCanvas.transform.GetChild(0).transform)
                Destroy(child.gameObject);
        }
        else
        {
            questWindowCanvas.gameObject.SetActive(true);
            foreach(Quest quest in QuestManager.Instance.activeQuests)
                InstantiateQuestText(0, quest.questData);
        } 
    }

    private void InstantiateQuestText(int pos, QuestSO questData)
    {
        GameObject obj = Instantiate(questTextPrefab);
        obj.GetComponent<Text>().text = questData.questTitle;  
        obj.transform.SetParent(questWindowCanvas.transform.GetChild(0), false);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0); //- Vector3.up * pos * 62;
    }
}
