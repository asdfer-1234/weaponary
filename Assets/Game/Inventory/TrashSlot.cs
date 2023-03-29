using UnityEngine;

[RequireComponent(typeof(InventorySlot))]
public class TrashSlot : MonoBehaviour
{
	void Update()
	{
		GetComponent<InventorySlot>().itemStack = ItemStack.empty;
		InventoryCursor.main.DropIfEmpty();
	}
}
