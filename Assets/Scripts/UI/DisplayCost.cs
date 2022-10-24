using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCost : MonoBehaviour
{
    [SerializeField] string statName;
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(PlayerDataManager.Instance.GetStatUpgradeCost(statName).ToString());
    }
}
