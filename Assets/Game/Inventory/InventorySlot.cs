using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InventorySlot : MonoBehaviour
{
	public ItemStack startingItemStack = ItemStack.empty;
	public ItemStack itemStack;

	public ItemStackDisplay display;
	[SerializeField] KeyCode primaryKey;
	[SerializeField] KeyCode secondaryKey;

	private const string animatorMouseOver = "Mouse Over";
	private const string animatorInventoryOpen = "Inventory Open";
	private bool mouseOver
	{
		get => m_mouseOver;
		set
		{
			m_mouseOver = value;
			GetComponent<Animator>().SetBool(animatorMouseOver, mouseOver);
		}
	}
	private bool m_mouseOver = false;
	public bool inCursor => InventoryCursor.main.inventorySlot == this;

	void Start()
	{
		itemStack = startingItemStack;
	}

	void Update()
	{
		if (mouseOver)
		{
			if (Input.GetKeyDown(primaryKey))
			{
				Primary();
			}
			if (Input.GetKeyDown(secondaryKey))
			{
				Secondary();
			}
		}
		UpdateDisplay();
	}


	private void Primary()
	{
		if (inCursor)
		{
			InventoryCursor.main.Drop();
		}
		else if (InventoryCursor.main.holding)
		{

			InventoryCursor.main.inventorySlot.TransferStack(this);
		}
		else
		{
			InventoryCursor.main.Pick(this);
		}
	}

	private void Secondary()
	{
		if (eligibleForDropOne)
		{
			InventoryCursor.main.inventorySlot.DropOne(this);
		}
		else
		{
			Primary();
		}
	}

	private bool eligibleForDropOne => !itemStack.containsItem || itemStack.itemType == InventoryCursor.main.inventorySlot.itemStack.itemType && InventoryCursor.main.inventorySlot.itemStack.containsItem;

	private void TransferStack(InventorySlot other)
	{
		if (other.itemStack.itemType == itemStack.itemType)
		{
			MergeStacks(other.itemStack);
		}
		else
		{
			SwapStacks(other);
		}
		InventoryCursor.main.DropIfEmpty();
	}

	public void MergeStacks(ItemStack other)
	{
		int maxStack = itemStack.itemType.stackSize;

		int added = itemStack.count + other.count;

		if (added <= maxStack)
		{
			other.count = added;
			itemStack = ItemStack.empty;
		}
		else
		{

			int leftover = added - maxStack;
			if (other.count == other.itemType.stackSize)
			{
				itemStack.count = maxStack;
				other.count = leftover;
			}
			else
			{
				itemStack.count = leftover;
				other.count = maxStack;
			}
		}
	}

	private void SwapStacks(InventorySlot other)
	{
		ItemStack swapper = itemStack;
		itemStack = other.itemStack;
		other.itemStack = swapper;
	}

	private void DropOne(InventorySlot other)
	{
		if (this == other)
		{
			throw new InventoryInvalidException();
		}
		else
		{
			if (!other.itemStack.containsItem)
			{
				other.itemStack.itemType = itemStack.itemType;
			}
			if (this.itemStack.itemType == other.itemStack.itemType)
			{
				itemStack.count--;
				other.itemStack.count++;
			}
			else
			{
				throw new InventoryInvalidException();
			}
		}
	}

	private void UpdateDisplay()
	{
		display.InventorySlotDisplay(this);
		if (inCursor)
		{
			InventoryCursor.main.display.Display(this);
		}
	}

	void OnMouseEnter()
	{
		if (itemStack.containsItem)
		{
			Tooltip.main.visible = true;
			Tooltip.main.text = itemStack.itemType.tooltip;
		}
		mouseOver = true;

	}

	void OnMouseExit()
	{
		Tooltip.main.visible = false;
		mouseOver = false;
	}
}
