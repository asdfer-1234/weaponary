using UnityEngine;


[CreateAssetMenu]
public class Weapon : ScriptableObject
{
	public GameObject projectile;
	public float attackSpeed;
	public float spread;
	public float randomSpread => Random.Range(-spread, spread) / 2;
	public float attackDelay => 1f / attackSpeed;
}
