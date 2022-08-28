using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaEntryPoint : MonoBehaviour, Interactable
{
    [SerializeField] ArenaSO arenaSO;

    void Start()
    {
        arenaSO.AddEntryPoint(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void Interact()
    {
        StartCoroutine(CustomSceneManager.Instance.SwitchToArena(arenaSO.arenaSceneName));
    }
}
