using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : MonoBehaviour, Interactable
{
    [SerializeField] ArenaSO arenaSO;

    void Awake()
    {
        arenaSO.ClearNullQuests();
    }

    public void Interact()
    {
        if(arenaSO.arenaQuests != null && arenaSO.arenaQuests.Count != 0)
        {
            StartCoroutine(CustomSceneManager.Instance.SwitchToArena(arenaSO.arenaSceneName));
        }
    }
}
