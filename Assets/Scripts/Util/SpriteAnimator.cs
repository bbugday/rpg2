using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator
{
    SpriteRenderer spriteRenderer;
    List<Sprite> frames;
    float frameRate;

    int currentFrame;
    float timer;

    bool flipX;
    bool flipY;

    public SpriteAnimator(List<Sprite> frames, SpriteRenderer spriteRenderer, bool flipX = false, bool flipY = false, float frameRate=0.16f)
    {
        this.frames = frames;
        this.spriteRenderer = spriteRenderer;
        this.frameRate = frameRate;
        this.flipX = flipX;
        this.flipY = flipY;
    }

    public void Start()
    {
        currentFrame = 0;
        timer = 0f;
        spriteRenderer.sprite = frames[0];
        spriteRenderer.flipX = flipX;
        spriteRenderer.flipY = flipY;
    }

    public void HandleUpdate()
    {
        timer += Time.deltaTime;
        if(timer > frameRate)
        {
            currentFrame = (currentFrame + 1) % frames.Count;
            spriteRenderer.sprite = frames[currentFrame];
            timer -= frameRate;
        }

    }

    public List<Sprite> Frames
    {
        get { return frames; }
    }
}
