using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    private const float fullTime = 0.5f;
    private float disappearTimer;

    Vector3 moveVector;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        transform.position += moveVector * Time.deltaTime;

        moveVector -= moveVector * 8f * Time.deltaTime;


        if(disappearTimer > fullTime / 2f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime; 
        }
        else if(disappearTimer > 0f)
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime; 
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        disappearTimer -= Time.deltaTime;
    }

    //make random colors?
    public void ShowUp(string text, Vector3 pos)
    {
        disappearTimer = fullTime;
        textMeshPro.text = text;
        this.transform.position = pos;
        moveVector = new Vector3(.7f, 1) * 16f;
    }
}
