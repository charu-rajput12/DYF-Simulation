using UnityEngine;
public class Item : MonoBehaviour
{
	[SerializeField] string m_itemId;
	[SerializeField] EItemType m_itemTpe;
	[SerializeField] SpriteRenderer m_spriteRenderer;
	[SerializeField] Sprite m_spriteOpenState;
	[SerializeField] Sprite m_spriteCloseState;
	[SerializeField] Transform m_transCanvasParent;
	public Transform TransCanvasParent => m_transCanvasParent;
	public string ItemId => m_itemId;
	public Sprite SpriteOpenState => m_spriteOpenState;
	public Sprite SpriteCloseState => m_spriteCloseState;
	public EItemType ItemType => m_itemTpe;

	bool m_openState = false;
	public void OnChestInteract()
	{
		//for chest
		if (m_openState)
			{
				m_openState = !m_openState;
				if (SpriteCloseState != null)
					m_spriteRenderer.sprite = SpriteCloseState;
			}
			else
			{
				m_openState = !m_openState;
				if (SpriteOpenState != null)
					m_spriteRenderer.sprite = SpriteOpenState;
			}
	}

}