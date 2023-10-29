using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
	static DontDestroyOnLoad s_instance;

	#region Unity Methods
	private void Awake()
	{
		s_instance = this;
		DontDestroyOnLoad(this);
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion
}
