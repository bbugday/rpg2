using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    bool isMoving = false;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    CharacterAnimator animator;

    float footOffset = -1.5f;

    void Start()
    {
        animator = GetComponent<CharacterAnimator>();
    }

    public void HandleUpdate()
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

                Vector3 xMovement = new Vector3(targetPos.x + input.x, targetPos.y, targetPos.z);
                Vector3 yMovement = new Vector3(targetPos.x, targetPos.y + input.y, targetPos.z);

                targetPos.x += (input.x / 4.0f);
                targetPos.y += (input.y / 4.0f);

                // Duvar sağımızda diyelim duvara yapışıkken sağ üste basınca aynı yerde 
                // kalıyor üste doğru gitmesini sağlamak için else ifleri kullanıyoruz. 

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
                else if(IsWalkable(xMovement))
                    StartCoroutine(Move(xMovement));
                else if(IsWalkable(yMovement))
                    StartCoroutine(Move(yMovement));
            }
        }

        animator.IsMoving = isMoving;

        if(Input.GetKeyDown(KeyCode.Space))
            Interact();
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



    bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(new Vector3(targetPos.x, targetPos.y + footOffset, 0), 0.3f, solidObjectsLayer | interactableLayer) != null)
            return false;

        return true;
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.MoveX, animator.MoveY);

        var footPos = new Vector3(transform.position.x, transform.position.y + footOffset, 0);

        var interactPos = footPos + facingDir;
        
        var collider = Physics2D.OverlapCircle(interactPos, 0.75f, interactableLayer);

        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    //interact's circle
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.black;

    //     var facingDir = new Vector3(animator.MoveX, animator.MoveY);

    //     var footPos = new Vector3(transform.position.x, transform.position.y + footOffset, 0);

    //     var interactPos = footPos + facingDir;

    //     Gizmos.DrawSphere(interactPos, 0.75f);
    // }

}
