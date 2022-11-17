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

    void Update()
    {
        var cost = PlayerDataManager.Instance.GetStatUpgradeCost(statName);
        text.SetText(cost == -1 ? "Full" : cost.ToString());
    }
}
