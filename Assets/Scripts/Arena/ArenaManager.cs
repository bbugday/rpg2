using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum State{Battle, Finish, Loading, Upgrade}

public class ArenaManager : MonoBehaviour
{
    State state = State.Battle;

    [SerializeField] ArenaPlayerController arenaPlayerController;

    [SerializeField] ArenaSO arenaSO;

    [SerializeField] GameObject dieCanvas;
    [SerializeField] GameObject clearCanvas;

    ArenaUiManager uiManager;

    public delegate void FinishEvent();
    public FinishEvent clearEvent;
    public FinishEvent dieEvent;

    private const int arenaTimeAsMinute = 15;

    void Awake()
    {
        uiManager = GetComponent<ArenaUiManager>();

        dieCanvas.SetActive(false);
        clearCanvas.SetActive(false);
        clearEvent += () => 
        {
            arenaSO.onExitArena = null;
            arenaSO.onExitArena += arenaSO.onClearEvent.Invoke;
            
            clearCanvas.SetActive(true);
            state = State.Finish;
        };

        dieEvent += () => 
        {
            state = State.Finish;
            dieCanvas.SetActive(true);
        };
    }

    void Start()
    {
        //arenaSO.gainedXP = 0;

        state = State.Battle;

        Invoke("TimeOver", arenaTimeAsMinute * 60f);
        //Invoke("TimeOver", 10f);
    }

    void Update()
    {
        if(state == State.Battle)
        {
            arenaPlayerController.HandleUpdate();

            // if(CheckCleared())
            // {
            //     clearEvent();
            // }
        }

        if(state == State.Upgrade)
        {
            
        }
        
        if(state == State.Finish)
        {
            if(Input.anyKey)
            {
                StartCoroutine(CustomSceneManager.Instance.SwitchToFreeRoam(arenaSO));
                state = State.Loading;
            }
        }
    }

    void TimeOver()
    {
        state = State.Finish;
        clearEvent();
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
