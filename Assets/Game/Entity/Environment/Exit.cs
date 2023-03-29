using UnityEngine;

public class Exit : Entity
{
	public FriendlyBase friendlyBase;

	public void DamageBase(int damage)
	{
		friendlyBase.Damage(damage);
	}

	public void RepairBase(int repair)
	{
		friendlyBase.Repair(repair);
	}
}