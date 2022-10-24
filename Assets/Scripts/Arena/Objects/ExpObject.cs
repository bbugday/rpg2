using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObject : MonoBehaviour, Collectable
{
    [SerializeField] int exp;
    [SerializeField] int gold;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void Collect(MainCharacter character)
    {
        character.AddExp(exp);
        PlayerDataManager.Instance.AddGold(gold);
        gameObject.SetActive(false);
    }
}
