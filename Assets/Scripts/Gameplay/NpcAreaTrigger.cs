using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAreaTrigger : MonoBehaviour
{
	[SerializeField] Npc m_Npc;
	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.gameObject.name);
		NpcAreaUIManager.OnTriggerEnter2D(m_Npc,collision);
	}
	void OnTriggerExit2D(Collider2D collision)
	{
		NpcAreaUIManager.OnTriggerExit2D(m_Npc,collision);
	}
}
