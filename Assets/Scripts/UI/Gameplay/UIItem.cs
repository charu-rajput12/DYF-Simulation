using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : UIBase
{

	static UIItem s_instance;

	bool m_canUpdate = false;
	Item m_item;

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

	#region Static Methods
	public static void ShowUI(Item a_item)
	{
		s_instance.Internal_ShowUI(a_item);
	}
	public static void HideUI(Item a_item)
	{
		s_instance.Internal_HideUI(a_item);
	}
	#endregion

	private void Update()
	{
		if (!m_canUpdate) return;

		if (Input.GetKeyUp(KeyCode.E))
		{
			ChestInteraction();
			//QuestManager.OnInteract(m_item, () => m_canUpdate = true);
		}
	}
	void Internal_ShowUI(Item a_item)
	{
		m_item = a_item;
		s_instance.Show();
		m_canUpdate = true;
	}
	void Internal_HideUI(Item a_item)
	{
		m_canUpdate = false;
		s_instance.Hide();
	}
	public void OnBtnClicked_Interact()
	{
		//m_canUpdate = false;

		//UIGameplay.HideUI();
		//QuestManager.OnInteract(m_item, () => m_canUpdate = true);

		ChestInteraction();
		//else
		//UIMiniGames.ShowUI();
	}

	void ChestInteraction()
	{
		if (m_item.ItemType == EItemType.Chest)
			m_item.OnChestInteract();

	}

}
