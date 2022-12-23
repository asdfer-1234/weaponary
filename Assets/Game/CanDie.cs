using UnityEngine;

public abstract class CanDie : Entity
{
	[SerializeField] private GameObject particle;
	private bool dead = false;


	public void Die()
	{
		if (dead)
		{
			return;
		}
		dead = true;
		OnDeath();
	}

	public virtual void OnDeath()
	{
		if (particle != null)
		{
			Instantiate(particle, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}
