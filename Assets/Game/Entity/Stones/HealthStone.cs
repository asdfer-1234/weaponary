using UnityEngine;

public class HealthStone : Stone
{
	public int rewardHealth;

	public override void Score(Exit exit)
	{
		exit.RepairBase(rewardHealth);
		Die();
	}
}
