using UnityEngine;

public class InventoryCursor : MonoBehaviour
{
	public InventorySlot inventorySlot
	{
		get => m_inventorySlot;
		set
		{
			InventorySlot oldInventorySlot = inventorySlot;
			m_inventorySlot = value;
			display.Display(inventorySlot);
			if (inventorySlot != null)
			{
				inventorySlot.display.InventorySlotDisplay(inventorySlot);
			}
			if (oldInventorySlot != null)
			{
				oldInventorySlot.display.InventorySlotDisplay(oldInventorySlot);
			}
		}
	}

	public ItemStackDisplay display;
	private InventorySlot m_inventorySlot;
	public KeyCode releaseKey;

	private const string selfTag = "Inventory Cursor";
	public static InventoryCursor main => GameObject.FindGameObjectWithTag(selfTag).GetComponent<InventoryCursor>();
	public bool holding => inventorySlot != null;


	void Update()
	{
		if (Input.GetKeyDown(releaseKey))
		{
			Drop();
		}
	}

	public void Drop()
	{
		if (inventorySlot == null)
		{
			return;
		}
		inventorySlot = null;
	}

	public void DropIfEmpty()
	{
		if (!inventorySlot.itemStack.containsItem)
		{
			Drop();
		}
	}

	public void Pick(InventorySlot slot)
	{
		inventorySlot = slot;
	}
}
