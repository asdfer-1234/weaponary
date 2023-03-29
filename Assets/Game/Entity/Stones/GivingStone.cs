using UnityEngine;
using System.Collections.Generic;

public class GivingStone : Stone
{
	public List<ItemStack> reward;
	public override void Score(Exit exit)
	{
		Inventory.main.AddItemStack(reward[Random.Range(0, reward.Count)]);
		Die();
	}
}
