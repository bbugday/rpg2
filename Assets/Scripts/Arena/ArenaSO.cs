using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Arena", menuName = "ScriptableObjects/ArenaScriptableObject", order = 1)]
public class ArenaSO : ScriptableObject
{
    private GameObject entryPoint;
    
    public string arenaSceneName;

    public delegate void OnClearEvent();
    public OnClearEvent onClearEvent;
    
    public void AddEntryPoint(GameObject entryPoint)
    {
        this.entryPoint = entryPoint;
    }

    public void EnableEntry()
    {
        entryPoint.SetActive(true);
    }

    public void DisableEntry()
    {
        entryPoint.SetActive(true);
    }
    
}
