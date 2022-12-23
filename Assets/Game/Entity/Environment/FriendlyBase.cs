using UnityEngine;
using UnityEngine.UIElements;

public class FriendlyBase : Health
{
	[SerializeField] UIDocument ui;
	private Label healthLabel;

	void Start()
	{
		healthLabel = ui.rootVisualElement.Q<Label>("HealthLabel");
		ResetHealth();
	}

	public override int health
	{
		set
		{
			base.health = value;
			healthLabel.text = health.ToString();
		}
	}

	public override void OnDeath()
	{
		Debug.Log("Game End");
	}
}
