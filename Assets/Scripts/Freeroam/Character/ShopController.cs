using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;

public class ShopController : MonoBehaviour, Interactable
{
    [SerializeField] GameObject shopPanel;

    [SerializeField] private GameObject[] choices;

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
        StartCoroutine(UiManager.SelectFirstButton());
    }

    public void Upgrade(string statName)
    {
        int cost = playerDataManager.GetStatUpgradeCost(statName);

        if(playerDataManager.gold >= cost && playerDataManager.IsStatUpgradeable(statName))
        {
            playerDataManager.Upgrade(statName);
        }
    }
}
