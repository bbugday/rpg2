using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcSO", menuName = "ScriptableObjects/NpcScriptableObject", order = 1)]
public class NpcSO : ScriptableObject
{
    public NPCController npc;

    public void AddNpc(NPCController npc)
    {
        this.npc = npc;
    }
}
