using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance = null;
	public static T Instance 
	{
    	get 
    	{
      		if (instance == null) 
      		{
          		instance = FindObjectOfType<T> ();
          		if (instance == null) 
          		{
					GameObject obj = new GameObject ();
					obj.name = typeof(T).Name;
					instance = obj.AddComponent<T>();
          		}
			}
			return instance;
		}
	}

	public virtual void Awake ()
  	{
		if (instance != null) 
		{
			Destroy (gameObject);
			return;
		}

		instance = GetComponent<T>();

		DontDestroyOnLoad(gameObject);

		if(instance == null)
			return;
	}
}