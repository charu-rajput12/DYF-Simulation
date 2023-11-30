using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAreaUIManager : MonoBehaviour
{
	static NpcAreaUIManager s_instance;

	[SerializeField] Canvas m_canvasNpcUI;
	[SerializeField] UINpc uINpc;

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

	public static void OnTriggerEnter2D(Npc a_Npc, Collider2D collision)
	{
		s_instance.Internal_OnTriggerEnter2D(a_Npc);
	}
	public static void OnTriggerExit2D(Npc a_Npc, Collider2D collision)
	{
		s_instance.Internal_OnTriggerExit2D(a_Npc);
	}
	void Internal_OnTriggerEnter2D(Npc a_Npc)
	{
		m_canvasNpcUI.transform.parent = a_Npc.TransCanvasParent;
		m_canvasNpcUI.GetComponent<RectTransform>().localPosition = Vector3.zero;

		Debug.Log("trigger entered"+a_Npc.NpcId);
		Debug.Log("trigger entered inside "+a_Npc.NpcId);
		if(!a_Npc.npc_Interactable)
			UINpc.ShowUI(a_Npc);

	}
	void Internal_OnTriggerExit2D(Npc a_Npc)
	{
		Debug.Log("trigger exit");
		UINpc.HideUI(a_Npc);
	}
}
