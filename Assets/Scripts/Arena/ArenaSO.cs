using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Arena", menuName = "ScriptableObjects/ArenaScriptableObject", order = 1)]
public class ArenaSO : ScriptableObject
{
    public delegate void OnClearEvent();
 
    public OnClearEvent onClearEvent;

    void OnEnable()
    {
        GameManager.Instance.objectsDB.AddArena(arenaName, this);
    }

    [SerializeField] string arenaName;
    
}
