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
        text.SetText(PlayerDataManager.Instance.GetStatUpgradeCost(statName).ToString());
    }
}
