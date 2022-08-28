using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] ArenaPlayerController arenaPlayerController;

    [SerializeField] ArenaSO arenaSO;

    private bool finished = false;

    void Update()
    {
        if(!finished && CheckCleared())
        {
            if(arenaSO.onClearEvent != null)
            {
                arenaSO.onClearEvent.Invoke();
            }
            
            finished = true;    
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
