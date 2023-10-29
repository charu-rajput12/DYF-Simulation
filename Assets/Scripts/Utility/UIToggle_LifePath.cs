using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle_LifePath : Toggle
{
	[SerializeField] ELifePath m_lifePath;
	public ELifePath Lifepath => m_lifePath;
}
