using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] ArenaPlayerController arenaPlayerController;

    [SerializeField] ArenaSO arenaSO;   

    void Update()
    {
        if(CheckCleared())
        {
            if(arenaSO.onClearEvent != null)
                {
                    arenaSO.onClearEvent.Invoke();
                }
        }
        arenaPlayerController.HandleUpdate();
    }

    bool CheckCleared()
    {
        if(!FindObjectOfType<Enemy>())
        {
            return true;
        }

        return false;
    }
}
