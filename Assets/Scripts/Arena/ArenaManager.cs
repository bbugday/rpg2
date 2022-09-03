using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum State{Battle, Finish, Loading}

public class ArenaManager : MonoBehaviour
{
    State state = State.Battle;

    [SerializeField] ArenaPlayerController arenaPlayerController;

    [SerializeField] ArenaSO arenaSO;

    [SerializeField] GameObject dieCanvas;
    [SerializeField] GameObject clearCanvas;

    public delegate void FinishEvent();
    public FinishEvent clearEvent;
    public FinishEvent dieEvent;

    void Awake()
    {
        dieCanvas.SetActive(false);
        clearCanvas.SetActive(false);

        clearEvent += () => 
        {
            if(arenaSO.onClearEvent != null)
            {
                arenaSO.onClearEvent.Invoke();
            }
            
            state = State.Finish;
        };

        dieEvent += () => 
        {
            state = State.Finish;
            dieCanvas.SetActive(true);
        };
    }

    void Update()
    {
        if(state == State.Battle)
        {
            arenaPlayerController.HandleUpdate();

            if(CheckCleared())
            {
                clearEvent();
            }
        }
        
        if(state == State.Finish)
        {
            if(Input.anyKey)
            {
                StartCoroutine(CustomSceneManager.Instance.SwitchToFreeRoam());
                state = State.Loading;
            }
        }
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
