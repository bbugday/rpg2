using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : BattleEntity
{
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    DamagePopup damagePopup;

    bool stackDamageOn = false;
    int stackedDamage = 0;

    void Awake()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    private IEnumerator WhiteSpriteEffect()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }

    public void GetHit(Projectile projectile)
    {
        StartCoroutine(WhiteSpriteEffect());
        Damage(projectile.attackDamage);
        PushBack(projectile.transform.right, projectile.force);

        stackedDamage += projectile.attackDamage;
        if(!stackDamageOn)
            StartCoroutine(ShowUp());
    }

    private IEnumerator ShowUp()
    {
        stackDamageOn = true;
        yield return new WaitForSeconds(0.05f);
        damagePopup = ObjectPool.SharedInstance.GetPooledObject(1).GetComponent<DamagePopup>();
        damagePopup.ShowUp(stackedDamage + "", this.transform.position);
        stackDamageOn = false;
        stackedDamage = 0;
    }

    public override void Damage(int AttackDamage)
    {
        health -= AttackDamage;
    }

    public void PushBack(Vector3 direction, int force)
    {
        Vector3 velocity = (direction * force) * Time.deltaTime;
        transform.Translate(velocity);
    }
}
