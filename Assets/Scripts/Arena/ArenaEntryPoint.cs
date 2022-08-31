using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : MonoBehaviour, Interactable
{
    [SerializeField] ArenaSO arenaSO;

    [SerializeField] string arenaSceneName;

    void Awake()
    {
        arenaSO.ClearNullQuests();
    }

    public void Interact()
    {
        if(arenaSO.questParts != null && arenaSO.questParts.Count != 0)
        {
            StartCoroutine(CustomSceneManager.Instance.SwitchToArena(arenaSceneName));
        }
    }
}
