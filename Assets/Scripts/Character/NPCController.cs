using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    public Action onFinishDialog;

    public Dialogue dialogue;

    public void Interact()
    {
        if(dialogue == null) return; 
        DialogueManager.Instance.showDialog(dialogue);
        onFinishDialog(); //not here, diyalog başlayınca değil bitince triggerla(diyalogmanagera aktar?)
    }
}
