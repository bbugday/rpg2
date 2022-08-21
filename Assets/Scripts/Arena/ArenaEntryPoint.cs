using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : MonoBehaviour, Interactable
{
    [SerializeField] string arenaSceneName;

    public void Interact()
    {
        CustomSceneManager.Instance.SwitchToArena(arenaSceneName);
    }
}
