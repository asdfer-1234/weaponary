using UnityEngine;
using TMPro;

public class ItemStackDisplay : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public TextMeshPro text;
	public Sprite heldSprite;

	public void Display(InventorySlot inventorySlot)
	{
		DisplaySprite(inventorySlot);
		DisplayText(inventorySlot);
	}

	public void InventorySlotDisplay(InventorySlot inventorySlot)
	{
		if (inventorySlot == null)
		{
			DisplayNothing();
		}
		else if (inventorySlot.inCursor)
		{
			DisplayHeld();
		}
		else
		{
			Display(inventorySlot);
		}
	}



	private void DisplaySprite(InventorySlot inventorySlot)
	{
		if (inventorySlot == null)
		{
			spriteRenderer.sprite = null;
		}
		else if (inventorySlot.itemStack.containsItem)
		{
			spriteRenderer.sprite = inventorySlot.itemStack.itemType.sprite;
		}
		else
		{
			spriteRenderer.sprite = null;
		}

	}

	private void DisplayText(InventorySlot inventorySlot)
	{
		if (inventorySlot == null)
		{
			text.enabled = false;
		}
		else
		{
			text.text = ColorizeCount(inventorySlot.itemStack);
			text.enabled = inventorySlot.itemStack.containsItem && inventorySlot.itemStack.count != 1;
		}
	}

	private static string ColorizeCount(ItemStack itemStack)
	{
		if (!itemStack.containsItem)
		{
			return "";
		}
		return RichTextBuilder.MinMaxString(itemStack.count, itemStack.itemType.stackSize, RichTextBuilder.Palette.goodPalette);
	}

	private void DisplayHeld()
	{
		spriteRenderer.sprite = heldSprite;
		text.enabled = false;
	}

	private void DisplayNothing()
	{
		spriteRenderer.sprite = null;
		text.enabled = false;
	}
}
