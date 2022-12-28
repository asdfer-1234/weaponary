using UnityEngine;

public abstract class Health : CanDie
{
	public int maxHealth;
	private int m_health;

	public virtual int health
	{
		get
		{
			return m_health;
		}
		set
		{
			m_health = value;
		}
	}

	void Start()
	{
		ResetHealth();
	}

	protected virtual void ResetHealth()
	{
		health = maxHealth;
	}

	public virtual void Damage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Die();
		}
	}

	public virtual void Repair(int repair)
	{
		health += repair;
		if (health > maxHealth)
		{
			health = maxHealth;
		}
	}
}
