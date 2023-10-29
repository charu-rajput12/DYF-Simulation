using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaUIManager : MonoBehaviour
{
	static ItemAreaUIManager s_instance;

	[SerializeField] Canvas m_canvasItemUI;

	#region Unity Methods
	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion

	public static void OnTriggerEnter2D(Item a_item, Collider2D collision)
	{
		s_instance.Internal_OnTriggerEnter2D(a_item);
	}
	public static void OnTriggerExit2D(Item a_item, Collider2D collision)
	{
		s_instance.Internal_OnTriggerExit2D(a_item);
	}
	void Internal_OnTriggerEnter2D(Item a_item)
	{
		m_canvasItemUI.transform.parent = a_item.TransCanvasParent;
		m_canvasItemUI.GetComponent<RectTransform>().localPosition = Vector3.zero;

		Debug.Log(a_item.ItemType);
		UIItem.ShowUI(a_item);

	}
	void Internal_OnTriggerExit2D(Item a_item)
	{
		Debug.Log(a_item.ItemType);
		UIItem.HideUI(a_item);
	}


}
