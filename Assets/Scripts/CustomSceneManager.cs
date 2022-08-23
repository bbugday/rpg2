using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : Singleton<CustomSceneManager>
{
    [SerializeField] GameObject essentialObjects;

    public void SwitchToArena(string arenaName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(arenaName);

        asyncLoad.completed += (asyncOperation) =>
        {
            essentialObjects.SetActive(false);
            GameManager.Instance.gameObject.SetActive(false);
        };
    }

    public void SwitchToFreeRoam()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);;

        asyncLoad.completed += (asyncOperation) =>
        {
            essentialObjects.SetActive(true);
            GameManager.Instance.gameObject.SetActive(true);
        };
    }
}
