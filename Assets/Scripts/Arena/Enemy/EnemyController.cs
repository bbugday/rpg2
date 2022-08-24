using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    ArenaPlayerController player;

    EnemyAnimator animator;

    public float moveSpeed;

    void Awake()
    {
        player = FindObjectOfType<ArenaPlayerController>();
        animator = GetComponent<EnemyAnimator>();
    }

    void Update()
    {
        var targetPos = player.transform.position;

        animator.MoveX = (player.transform.position - transform.position).normalized.x;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
