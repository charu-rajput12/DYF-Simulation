using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaTrigger : MonoBehaviour
{
	[SerializeField] Item m_Item;
	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.gameObject.name);
		ItemAreaUIManager.OnTriggerEnter2D(m_Item, collision);
	}
	void OnTriggerExit2D(Collider2D collision)
	{
		ItemAreaUIManager.OnTriggerExit2D(m_Item, collision);
	}
}