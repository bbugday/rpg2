using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;


//use singleton??
public class DialogueManager : Singleton<DialogueManager>
{

    [SerializeField] GameObject dialoguePanel;
    
    [SerializeField] Text dialogueText;

    Story currentStory;

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
        if(Input.GetKeyDown(KeyCode.Z))
            ContinueStory();
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
