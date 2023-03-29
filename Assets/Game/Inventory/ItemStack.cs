using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemStack
{
	public Item itemType;
	public int count;
	public bool full => count >= itemType.stackSize;

	public bool containsItem => itemType != null && count > 0;
	public static ItemStack empty => new ItemStack(null, 0);

	public ItemStack(Item itemType, int count)
	{
		this.itemType = itemType;
		this.count = count;
	}

	public void CheckEmpty()
	{
		if (count <= 0)
		{
			count = 0;
			itemType = null;
		}
	}
}