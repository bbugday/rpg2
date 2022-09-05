using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObject : MonoBehaviour, Collectable
{
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void Collect(MainCharacter character)
    {
        character.AddExp(2); // to do: get information from SO
        gameObject.SetActive(false);
    }

}
