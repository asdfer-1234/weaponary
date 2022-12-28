using UnityEngine;
using TMPro;

public class FriendlyBase : Health
{
	[SerializeField] TextMeshPro text;

	void Start()
	{
		ResetHealth();
	}

	public override int health
	{
		set
		{
			base.health = value;
			text.text = health.ToString();
		}
	}

	public override void OnDeath()
	{
		Debug.Log("Game End");
	}
}
