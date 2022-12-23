using UnityEngine;
using System.Collections;

class Turret : MonoBehaviour
{
	public Weapon weapon;
	[SerializeField] private KeyCode shootKey;
	private Animator animator;
	private bool attackCooled = true;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}


	void Update()
	{
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.right = (Vector3)worldPosition - transform.position;
		if (attackCooled && Input.GetKey(KeyCode.Mouse0))
		{
			Instantiate(weapon.projectile, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + weapon.randomSpread));
			StartCoroutine(Cooldown(weapon.attackDelay));
			animator.SetTrigger("Shoot");
		}
	}

	private IEnumerator Cooldown(float duration)
	{
		attackCooled = false;
		yield return new WaitForSeconds(duration);
		attackCooled = true;
	}
}