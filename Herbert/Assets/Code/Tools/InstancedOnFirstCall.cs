using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstancedOnFirstCall<T> where T : MonoBehaviour
{
	private static T s_instanceBackingField = default;
	public static T s_instance
	{
		get
		{
			if (s_instanceBackingField == null)
			{
				GameObject tmp = new GameObject("INSTANCE_" + typeof(T));
				s_instanceBackingField = tmp.AddComponent<T>();
			}
			return s_instanceBackingField;
		}
	}

	public static bool Exists() => s_instanceBackingField != default;
}
