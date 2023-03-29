using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
	public float interval;
	[SerializeField] float timer;
	[SerializeField] StoneGenerationWeight[] stones;
	[SerializeField] Vector2 randomVelocity;
	[Header("Difficulty")]
	[SerializeField] float difficulty;
	[SerializeField] float difficultyIncrease;


	void Update()
	{
		DifficultyUpdate();
		GenerationalUpdate();
	}

	private void GenerationalUpdate()
	{
		timer += Time.deltaTime;

		if (interval / difficulty <= timer)
		{
			timer -= interval / difficulty;
			Generate();

		}
	}

	private void DifficultyUpdate()
	{
		difficulty += Time.deltaTime * difficultyIncrease;
	}

	private void Generate()
	{
		GameObject stone = StoneGenerationWeight.RandomStone(stones, difficulty).stone;

		GameObject instantiated = Instantiate(stone, transform.position + (Vector3)randomInScale, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
		instantiated.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * randomVelocity);
	}

	private Vector2 randomInScale => new Vector2(Random.Range(-transform.localScale.x, transform.localScale.x), Random.Range(-transform.localScale.y, transform.localScale.y)) / 2;
}
