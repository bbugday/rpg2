using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private bool isMoving = false;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    // Start is called before the first frame update
    void Start()
    {
        
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
                // animator.SetFloat("MoveX", input.x);
                // animator.SetFloat("MoveY", input.y);

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

        //animator.SetBool("IsMoving", isMoving);

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

    private bool IsWalkable(Vector3 targetPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.49f),
         (Vector2)(targetPos - transform.position), 1f, solidObjectsLayer | interactableLayer);

        if(hit.collider != null)
            return false;

        return true;
    }
}
