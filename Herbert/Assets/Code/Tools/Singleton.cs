using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T s_instanceBackingField = default;
	public static T s_instance
	{
		get
		{
			if (s_instanceBackingField == null)
			{
				GameObject tmp = new GameObject("SINGLETON_" + typeof(T));
				s_instanceBackingField = tmp.AddComponent<T>();
			}
			return s_instanceBackingField;
		}
	}

	private void Awake()
	{
		if (s_instanceBackingField != null)
		{
			Destroy(this);
			return;
		}
		s_instanceBackingField = this as T;
	}

	public static bool Exists() => s_instanceBackingField != default;
}