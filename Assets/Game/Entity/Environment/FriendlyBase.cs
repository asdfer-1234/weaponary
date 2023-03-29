using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FriendlyBase : Health
{
	[SerializeField] TextMeshPro text;

	void Start()
	{
		GlobalData.time = 0f;
		ResetHealth();
	}

	void Update()
	{
		GlobalData.time += Time.deltaTime;
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
		GameOver();
	}

	public void GameOver()
	{
		SceneManager.LoadScene("GameOverScene");
	}
}
