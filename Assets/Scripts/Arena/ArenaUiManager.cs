using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaUiManager : MonoBehaviour
{

    [SerializeField] GameObject upgradePanel;
    [SerializeField] GameObject upgradeButtonPrefab;
    [SerializeField] GameObject upgradeButtons;

    List<WeaponUpgrader> weaponUpgraders;

    void Awake()
    {
        weaponUpgraders = FindObjectOfType<MainCharacter>().weaponUpgraders;
        Debug.Log("awake");
        LevelUp();
    }


    public void HandleUpdate()
    {

    }

    private void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
        StartCoroutine(UiManager.SelectFirstButton());
    }

    public void LevelUp()
    {
        OpenUpgradePanel();
        CreateButtons();
    }

    private List<WeaponUpgrader> GetReadyUpgrades()
    {
        List<WeaponUpgrader> readyUpgrades = new List<WeaponUpgrader>();

        foreach(WeaponUpgrader upgrader in weaponUpgraders)
        {
            if(upgrader.IsUpgradeReady())
                readyUpgrades.Add(upgrader);
        }

        return readyUpgrades;
    }

    private void CreateButtons()
    {
        List<WeaponUpgrader> upgrades = GetReadyUpgrades();

        int i = 0;

        foreach(WeaponUpgrader upgrade in upgrades)
        {
            //3'den fazla gelirse aradan rasgele seç, az gelirse gold ekle
            CreateButton(upgrade, i);
            i++;
        }
    }

    private void CreateButton(WeaponUpgrader upgrade, int pos)
    {
        GameObject buttonObject = Instantiate(upgradeButtonPrefab);

        var button = buttonObject.GetComponent<UnityEngine.UI.Button>();
        button.transform.SetParent(upgradeButtons.transform);
        buttonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(90, 110, 0) + Vector3.right * pos * 155;
        buttonObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(upgrade.weaponName);
        button.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().SetText(upgrade.ReadyUpgrade());
        button.transform.GetChild(2).GetComponent<Image>().sprite = upgrade.sprite;
        button.onClick.AddListener(() => {
            upgrade.Upgrade();

            foreach (Transform child in upgradeButtons.transform) {
                GameObject.Destroy(child.gameObject);
            }

            upgradePanel.SetActive(false);

        });

        //dynamicButtons.Add(buttonObject);
        // var button = buttonObject.GetComponent<UnityEngine.UI.Button>();
        // button.transform.SetParent(loadButtons.transform);
        // buttonObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,302,0) - Vector3.up * pos * 62;
        // button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(saveName);
        // button.onClick.AddListener(() => {
        //     SavingSystem.i.Load("savefiles/" + saveName);
        //     mainButtons.SetActive(true);
        //     loadButtons.SetActive(false);
        //     mainMenuCanvas.SetActive(false);
        //     GameManager.Instance.StartFreeroam();
        //     DestroyDynamicButtons();
        // });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
