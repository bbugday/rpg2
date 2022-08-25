using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;

    public float MoveX { get; set; }

    SpriteAnimator walkRightAnim;
    SpriteAnimator walkLeftAnim;

    SpriteAnimator currentAnim;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkRightAnim = new SpriteAnimator(sprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(sprites, spriteRenderer, true);

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
