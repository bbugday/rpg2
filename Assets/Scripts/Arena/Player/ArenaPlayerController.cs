using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlayerController : MonoBehaviour
{
    CharacterAnimator animator;

    public int moveSpeed;

    void Awake()
    {
        animator = GetComponent<CharacterAnimator>();
        moveSpeed += FindObjectOfType<PlayerDataManager>().moveSpeedUpgrade * 10;
    }

    public void HandleUpdate()
    {
        Move();

        // if(Input.GetKeyDown(KeyCode.T))
        //     StartCoroutine(CustomSceneManager.Instance.SwitchToFreeRoam());
    }

    public void Move()
    {
        Vector2 input;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if(input != Vector2.zero)
        {
            transform.position += new Vector3(input.normalized.x, input.normalized.y, 0) * Time.deltaTime * moveSpeed;

            animator.IsMoving = true;
            animator.MoveX = input.x;
            animator.MoveY = input.y;
        }
        else
        {
            animator.IsMoving = false;
        }
    }
}
