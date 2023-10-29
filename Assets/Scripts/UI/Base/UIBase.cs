using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
	[SerializeField] GameObject m_Screen;

	protected void Show()
	{
		m_Screen.SetActive(true);
	}
	protected void Hide()
	{
		m_Screen.SetActive(false);
	}
  
}
