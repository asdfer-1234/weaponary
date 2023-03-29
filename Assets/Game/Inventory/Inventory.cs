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



	public InventorySlot AvailableSlot
	{
		get
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


	public const string selfTag = "Inventory";
	public static Inventory main => GameObject.FindGameObjectWithTag(selfTag).GetComponent<Inventory>();

	public void AddItemStack(ItemStack itemStack)
	{
		if (!itemStack.containsItem)
		{
			throw new InventoryInvalidException();
		}
		foreach (InventorySlot i in inventorySlots)
		{
			if (!i.itemStack.containsItem)
			{
				i.itemStack.itemType = itemStack.itemType;
			}
			if (i.itemStack.itemType == itemStack.itemType)
			{
				int transferCount = Mathf.Min(itemStack.itemType.stackSize - i.itemStack.count, itemStack.count);
				i.itemStack.count += transferCount;
				itemStack.count -= transferCount;
			}
			if (!itemStack.containsItem)
			{
				break;
			}
		}
	}
}
