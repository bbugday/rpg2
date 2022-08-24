using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    [SerializeField] List<Sprite> walkRightSprites;
    [SerializeField] List<Sprite> walkLeftSprites;

    public float MoveX { get; set; }

    SpriteAnimator walkRightAnim;
    SpriteAnimator walkLeftAnim;

    SpriteAnimator currentAnim;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkRightAnim = new SpriteAnimator(walkRightSprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(walkLeftSprites, spriteRenderer);

        currentAnim = walkRightAnim;
    }

    private void Update()
    {
        var prevAnim = currentAnim;

        if (MoveX > 0)
            currentAnim = walkRightAnim;
        else 
            currentAnim = walkLeftAnim;

        if (currentAnim != prevAnim)
            currentAnim.Start();

        currentAnim.HandleUpdate();
    }
}
