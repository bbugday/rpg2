using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] ArenaPlayerController arenaPlayerController;

    void Update()
    {
        arenaPlayerController.HandleUpdate();
    }
}
