using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
	[SerializeField] int m_npcId;
	[SerializeField] Sprite m_spriteNpc;
	[SerializeField] Transform m_transCanvasParent;
	public Transform TransCanvasParent => m_transCanvasParent;
	public int NpcId => m_npcId; 
	public Sprite Sprite => m_spriteNpc;

	public bool npc_Interactable = false;
}
