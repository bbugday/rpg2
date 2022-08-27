using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Arena", menuName = "ScriptableObjects/ArenaScriptableObject", order = 1)]
public class ArenaSO : ScriptableObject
{
    [SerializeField] string arenaName;

    private GameObject entryPoint;

    public delegate void OnClearEvent();
 
    public OnClearEvent onClearEvent;

    void OnEnable()
    {
        GameManager.Instance.objectsDB.AddArena(arenaName, this);
    }

    public void EnableEntry()
    {
        if(entryPoint == null)
            entryPoint = GameManager.Instance.objectsDB.GetArenaEntryPoint(this).gameObject;
        entryPoint.SetActive(true);
    }

    public void DisableEntry()
    {
        if(entryPoint == null)
            entryPoint = GameManager.Instance.objectsDB.GetArenaEntryPoint(this).gameObject;
        entryPoint.SetActive(true);
    }
}
