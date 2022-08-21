using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlayerController : MonoBehaviour
{

    public int moveSpeed;

    public void HandleUpdate()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.T))
            CustomSceneManager.Instance.SwitchToFreeRoam();
    }

    public void Move()
    {
        if(Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.S))
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
