using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : Singleton<CustomSceneManager>
{
    [SerializeField] GameObject essentialObjects;

    public void SwitchToArena(string arenaName)
    {
        SceneManager.LoadSceneAsync(arenaName);
        essentialObjects.SetActive(false);
        GameManager.Instance.gameObject.SetActive(false);
    }

    public void SwitchToFreeRoam()
    {
        SceneManager.LoadSceneAsync(0);
        essentialObjects.SetActive(true);
        GameManager.Instance.gameObject.SetActive(true);
    }
}
