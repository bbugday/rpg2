using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : Singleton<CustomSceneManager>
{
    [SerializeField] GameObject essentialObjects;

    public IEnumerator SwitchToArena(string arenaName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(arenaName);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {         
            if( asyncLoad.progress >= 0.9f)
            {
                break;
            }
            yield return null;
        }

        essentialObjects.SetActive(false);
        GameManager.Instance.gameObject.SetActive(false);
        asyncLoad.allowSceneActivation = true;
    }

    //SwitchArenaToFreeroam

    public IEnumerator SwitchToFreeRoam(ArenaSO arenaSO)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {         
            if( asyncLoad.progress >= 0.9f)
            {
                break;
            }
            yield return null;
        }

        essentialObjects.SetActive(true);
        GameManager.Instance.gameObject.SetActive(true);
        asyncLoad.allowSceneActivation = true;

        arenaSO.onExitArena.Invoke();

        // var player = FindObjectOfType<PlayerData>();
        // player.xp += arenaSO.gainedXP;
    }
}
