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

    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    float fade = 1;

    DamagePopup damagePopup;

    bool stackDamageOn = false;
    int stackedDamage = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkRightAnim = new SpriteAnimator(sprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(sprites, spriteRenderer, true);
        currentAnim = walkRightAnim;

        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = spriteRenderer.material.shader;
    }

    void Update()
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

    public void Die()
    {
        StartCoroutine(DeathAnimation());
    }

    public IEnumerator DeathAnimation()
    {
        spriteRenderer.material.shader = shaderSpritesDefault;
        while(true)
        {
            if(fade <= 0)
            {
                Destroy(gameObject);
            }
            fade -= Time.deltaTime;
            spriteRenderer.material.SetFloat("_Fade", fade);
            yield return null;
        }
    }

    public IEnumerator WhiteSpriteEffect()
    {

        spriteRenderer.material.shader = shaderGUItext;
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material.shader = shaderSpritesDefault;
        spriteRenderer.color = Color.white;
    }

    public void GetDamage(int damage)
    {
        stackedDamage += damage;
        if(!stackDamageOn)
            StartCoroutine(ShowDamagePopup());
    }

    private IEnumerator ShowDamagePopup()
    {
        stackDamageOn = true;
        yield return new WaitForSeconds(0.05f);
        damagePopup = ObjectPool.SharedInstance.GetPooledObject(1).GetComponent<DamagePopup>();
        damagePopup.ShowUp(stackedDamage + "", this.transform.position);
        stackDamageOn = false;
        stackedDamage = 0;
    }
}
