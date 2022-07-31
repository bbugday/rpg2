using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    TextMeshProUGUI text;

    Color defaultColor;
    
    void Start()
    {
        text = this.GetComponentInChildren<TextMeshProUGUI>();
        defaultColor = text.color;
    }

    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        text.color = Color.red;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        text.color = defaultColor;
    }

}
