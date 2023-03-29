using UnityEngine;
using System.Collections;
using System;

class Turret : MonoBehaviour
{

	public Weapon defaultWeapon;
	public Ammunition defaultAmmunition;
	[SerializeField] private KeyCode shootKey;
	private Animator animator;
	private bool attackCooled = true;
	public InventorySlot weaponSlot;
	public InventorySlot ammunitionSlot;
	private Weapon weapon;
	private Ammunition ammunition;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}


	void Update()
	{
		GetWeapon();
		GetAmmunition();
		Swivel();
		if (attackCooled && Input.GetKey(KeyCode.Mouse0))
		{
			Shoot();
		}

	}


	private void GetWeapon()
	{
		weapon = GetItemByType<Weapon>(weaponSlot.itemStack.itemType, defaultWeapon);
	}

	private void GetAmmunition()
	{
		ammunition = GetItemByType<Ammunition>(ammunitionSlot.itemStack.itemType, defaultAmmunition);
	}

	private T GetItemByType<T>(Item item, T defaultItem) where T : Item
	{
		if (item is T)
		{
			return (T)item;
		}
		return defaultItem;
	}

	private void Shoot()
	{
		for (int i = 0; i < ammunition.additionalBullets + 1; i++)
		{
			GameObject instantiated = Instantiate(ammunition.projectile, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + weapon.randomSpread * ammunition.spreadMultiplier));
			instantiated.GetComponent<Projectile>().damage = Mathf.CeilToInt(weapon.damage * ammunition.damageMultiplier);
			instantiated.GetComponent<Projectile>().piercing += ammunition.additionalPiercing;

		}
		UseAmmunition();
		Cooldown(weapon.attackDelay / ammunition.attackSpeedMultiplier);
		animator.SetTrigger("Shoot");
	}

	private void UseAmmunition()
	{
		ammunitionSlot.itemStack.count--;
		ammunitionSlot.itemStack.CheckEmpty();
	}

	private void Swivel()
	{
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion lookRotationAngle = Quaternion.LookRotation(Vector3.forward, (Vector3)worldPosition - transform.position) * Quaternion.Euler(0, 0, 90);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotationAngle, weapon.swivelSpeed * Time.deltaTime);

	}

	private void Cooldown(float duration)
	{
		StartCoroutine(CooldownCoroutine(duration));
		IEnumerator CooldownCoroutine(float duration)
		{
			attackCooled = false;
			yield return new WaitForSeconds(duration);
			attackCooled = true;
		}
	}
}