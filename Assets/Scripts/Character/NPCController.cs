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
        DialogueManager.Instance.showDialog(dialogue);
        onFinishDialog();
    }
}
