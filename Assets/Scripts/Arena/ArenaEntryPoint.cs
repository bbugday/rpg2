using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : QuestObject, Interactable
{
    [SerializeField] string arenaSceneName;

    public ArenaSO arenaSO;

    void Awake()
    {
        arenaSO.Init();
    }

    public void Interact()
    {
        if(questParts != null && questParts.Count != 0)
        {
            StartCoroutine(CustomSceneManager.Instance.SwitchToArena(arenaSceneName));
        }
    }

    public void ResetClearEvents()
    {
        arenaSO.onClearEvent = null;
    }
}
