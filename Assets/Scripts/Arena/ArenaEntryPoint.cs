using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : MonoBehaviour, Interactable
{
    [SerializeField] string arenaName;

    [SerializeField] string arenaSceneName;

    void Start()
    {
        GameManager.Instance.objectsDB.AddArenaEntryPoint(arenaName, this);
        this.gameObject.SetActive(false);
    }

    public void Interact()
    {
        StartCoroutine(CustomSceneManager.Instance.SwitchToArena(arenaSceneName));
    }
}
