using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Arena", menuName = "ScriptableObjects/ArenaScriptableObject", order = 1)]
public class ArenaSO : ScriptableObject
{    
    [SerializeField] string arenaEntryPointName;
    private ArenaEntryPoint arenaEntryPoint;
    
    public delegate void OnClearEvent();
    public OnClearEvent onClearEvent;

    public delegate void OnExitArena();
    public OnExitArena onExitArena;

    public void Init()
    {
        arenaEntryPoint = GameObject.Find(arenaEntryPointName).GetComponent<ArenaEntryPoint>();
    }
}
