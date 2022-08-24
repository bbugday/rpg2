using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : MonoBehaviour, Interactable
{
    [SerializeField] string arenaSceneName;

    public void Interact()
    {
        StartCoroutine(CustomSceneManager.Instance.SwitchToArena(arenaSceneName));
    }
}
