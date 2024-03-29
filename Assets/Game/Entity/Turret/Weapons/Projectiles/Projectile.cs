using UnityEngine;
using System.Collections;

class Projectile : CanDie
{
	public float speed;
	public float lifetime;
	public float knockback;
	public int damage;
	public int piercing;
	private bool startWall = true;


	void Start()
	{
		StartCoroutine(Decay());
	}


	private IEnumerator Decay()
	{
		yield return new WaitForSeconds(lifetime);
		Die();
	}

	void Update()
	{
		transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		startWall = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Entity otherEntity = other.gameObject.GetComponent<Entity>();

		if (otherEntity != null)
		{
			if (otherEntity.force == Force.Neutral && !startWall)
			{
				Die();
			}
		}
		Stone stone = other.gameObject.GetComponent<Stone>();

		if (stone is not null)
		{
			stone.Damage(damage);
			stone.Knockback((stone.transform.position - transform.position) * knockback);
			piercing--;
			if (piercing <= 0)
			{
				Die();
			}
		}
	}
}