using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;

//use singleton??
public class DialogueManager : Singleton<DialogueManager>
{

    //bool dialogueIsPlaying? to handle inputs

    [SerializeField] GameObject dialoguePanel;

    [SerializeField] GameObject choicesPanel;
    
    [SerializeField] Text dialogueText;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    Story currentStory;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
        choicesPanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) 
        {
            choice.SetActive(false);
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void HandleUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !choicesPanel.activeInHierarchy){
            if(currentStory.currentChoices.Count == 0)
                ContinueStory();
            else
                DisplayChoices();
        }
    }

    private void DisplayChoices()
    {
        choicesPanel.SetActive(true);
        
        dialogueText.text = "";
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;

        // enable and initialize the choices up to the amount of choices for this line of dialogue
        
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());

    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        choicesPanel.SetActive(false);
        //ContinueStory();
    }

    public void ShowInkDialog(TextAsset inkJSON)
    {
        GameManager.Instance.setState(GameState.Dialog);
        currentStory = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
            dialogueText.text = currentStory.Continue();
        else
            ExitDialogueMode();
    }

    private void ExitDialogueMode()
    {
        GameManager.Instance.setState(GameState.FreeRoam);
        dialoguePanel.SetActive(false);
        dialogueText.text = "";    
    }
    
    public void ShowQuestDialog(Dialogue dialogue)
    {
        dialoguePanel.SetActive(true);

        foreach(string line in dialogue.Lines)
        {
            Debug.Log(line);
        }
    }
}
