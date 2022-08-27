using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsDB", menuName = "ScriptableObjects/ObjectsDB", order = 1)]
public class ObjectsDB : ScriptableObject
{
    Dictionary<string, ArenaSO> arenas;
    Dictionary<ArenaSO, ArenaEntryPoint> arenaEntryPoints;

    void OnEnable()
    {
        arenas = new Dictionary<string, ArenaSO>();
        arenaEntryPoints = new Dictionary<ArenaSO, ArenaEntryPoint>();
    }

    public void AddArena(string arenaName, ArenaSO arenaData)
    {   
        if(!arenas.ContainsKey(arenaName))
            arenas.Add(arenaName, arenaData);
    }

    public ArenaSO GetArena(string arenaName)
    {
        return arenas[arenaName];
    }

    public void AddArenaEntryPoint(string arenaName, ArenaEntryPoint entryPoint)
    {   
        var arena = GetArena(arenaName);
        if(!arenaEntryPoints.ContainsKey(arena))
            arenaEntryPoints.Add(arena, entryPoint);
    }

    public ArenaEntryPoint GetArenaEntryPoint(ArenaSO arena)
    {
        return arenaEntryPoints[arena];
    }

    public ArenaEntryPoint GetArenaEntryPoint(string arenaName)
    {
        return GetArenaEntryPoint(GetArena(arenaName));
    }
}
