using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class ShopController : MonoBehaviour, Interactable
{
    [SerializeField] GameObject shopPanel;

    [SerializeField] private GameObject[] choices;

    GameObject lastselect;

    PlayerDataManager playerDataManager;

    public void Interact()
    {
        GameManager.Instance.setState(GameState.Shop);

        OpenShop();
        
    }

    void Awake()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>();
    }

    void Start()
    {
        shopPanel.SetActive(false);
        //choicesPanel.SetActive(false);
    }

    public void HandleUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            shopPanel.SetActive(false);
            GameManager.Instance.setState(GameState.FreeRoam);
        }
    }

    private void OpenShop()
    {
        shopPanel.SetActive(true);
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        lastselect = choices[0].gameObject;
    }

    public void UpgradeMoveSpeed()
    {
        if(playerDataManager.UpgradeMoveSpeed())
        {
            //gold--
        }
    }

}
