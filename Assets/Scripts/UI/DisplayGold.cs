using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayGold : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.SetText(PlayerDataManager.Instance.gold.ToString());
    }
}
