using UnityEngine;

public class Stone : Health
{
	[SerializeField] private GameObject scoreParticle;
	[SerializeField] private int damage;
	public virtual void Knockback(Vector2 force)
	{
		GetComponent<Rigidbody2D>().AddForce(force);
	}

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		Exit exit = other.gameObject.GetComponent<Exit>();
		if (exit != null)
		{
			Score(exit);
			Exit();
		}
	}

	public virtual void Score(Exit exit)
	{
		Instantiate(scoreParticle, transform.position, Quaternion.identity);
		exit.DamageBase(damage);
	}

	public virtual void Exit()
	{
		Destroy(gameObject);
	}
}