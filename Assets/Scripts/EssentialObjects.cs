using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjects : MonoBehaviour
{
    private static EssentialObjects instance;

    void Awake()
    {
        if (instance != null) 
		{
			Destroy (gameObject);
			return;
		}

        instance = GetComponent<EssentialObjects>();

        DontDestroyOnLoad(gameObject);
    }
}
