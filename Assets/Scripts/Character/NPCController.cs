using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    SpriteAnimator spriteAnimator;

    [SerializeField] List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteAnimator = new SpriteAnimator(sprites, GetComponent<SpriteRenderer>());
        spriteAnimator.Start();        
    }

    // Update is called once per frame
    void Update()
    {
        spriteAnimator.HandleUpdate();
    }
}
