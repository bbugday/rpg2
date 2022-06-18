using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private bool isMoving = false;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    CharacterAnimator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<CharacterAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input;

        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //if(input.x != 0) input.y = 0;

            if(input != Vector2.zero)
            {
                animator.MoveX = input.x;
                animator.MoveY = input.y;

                var targetPos = transform.position;

                //sonradan 4le böldüm
                targetPos.x += (input.x / 4.0f);
                targetPos.y += (input.y / 4.0f);

                // targetPos.x += input.x;
                // targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.IsMoving = isMoving;

        // if(Input.GetKeyDown(KeyCode.Z))
        //     Interact();
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                                  targetPos, moveSpeed * Time.deltaTime);
            
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 1.5f, 0), 0.3f);
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(new Vector3(targetPos.x, targetPos.y - 1.5f, 0), 0.3f, solidObjectsLayer | interactableLayer) != null)
            return false;
            
        return true;
    }

}
