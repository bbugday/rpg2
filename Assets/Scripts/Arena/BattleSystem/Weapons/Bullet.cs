using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    void OnBecameInvisible(){
        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 direction)
    {
        transform.right = direction;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

}
