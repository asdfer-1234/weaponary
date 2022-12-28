using UnityEngine;

public class Inventory : MonoBehaviour
{
	public InventorySlot[] inventorySlots
	{
		get
		{
			InventorySlot[] slots = new InventorySlot[transform.childCount];
			for (int i = 0; i < transform.childCount; i++)
			{
				slots[i] = transform.GetChild(i).GetComponent<InventorySlot>();
			}
			return slots;
		}
	}



	public InventorySlot AvailableSlot()
	{
		foreach (InventorySlot i in inventorySlots)
		{
			if (!i.itemStack.containsItem)
			{
				return i;
			}
		}
		return null;
	}
}
