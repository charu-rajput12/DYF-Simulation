using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINpc : UIBase
{
	static UINpc s_instance;
	[SerializeField] DialogManager_Quest1 dialogManager_Quest1;
	//public bool ifNpcInteracted;

	bool m_canUpdate = false;
	Npc m_npc;

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
	public static void ShowUI(Npc a_npc)
	{
		s_instance.Internal_ShowUI(a_npc);
	}
	public static void HideUI(Npc a_npc)
	{
		s_instance.Internal_HideUI(a_npc);
	}
	#endregion

	private void Update()
	{
		if (!m_canUpdate) return;

		if (Input.GetKeyUp(KeyCode.E))
		{
			OnInteract();
		}
	}
	void Internal_ShowUI(Npc a_npc)
	{
		m_npc = a_npc;
		s_instance.Show();
		m_canUpdate = true;
	}
	void Internal_HideUI(Npc a_npc)
	{
		m_canUpdate = false;
		s_instance.Hide();
	}
	public void OnBtnClicked_Interact()
	{
			
			OnInteract();

			

		//
	}

	void OnInteract()
	{
		int currentqUEST = DataManager.GameData.PlayerData.currentQuest;
		if (m_npc.NpcId > currentqUEST)
		{
			DoFirst.ShowUI(m_npc.NpcId);
		}
		else 
		{
            if (!m_npc.npc_Interactable)
            {
				if (m_npc.NpcId == 0 && currentqUEST == 0)
					dialogManager_Quest1.StartQuest();
				else if (currentqUEST == 1)
				{
					QuestManager.OnInteract(m_npc, () => m_canUpdate = true);
				}
				m_npc.npc_Interactable = true;
			}


			UIGameplay.HideUI();
			m_canUpdate = false;
			s_instance.Hide();


		}
	} 
}
