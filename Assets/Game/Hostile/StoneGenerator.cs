using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
	public float interval;
	[SerializeField] float timer;
	[SerializeField] StoneGenerationWeight[] stones;
	[SerializeField] Vector2 randomVelocity;


	void Update()
	{
		timer += Time.deltaTime;
		if (interval <= timer)
		{
			timer -= interval;
			Generate();
		}
	}

	private void Generate()
	{
		GameObject stone = StoneGenerationWeight.RandomStone(stones).stone;

		GameObject instantiated = Instantiate(stone, transform.position + (Vector3)randomInScale, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
		instantiated.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * randomVelocity);
	}

	private Vector2 randomInScale => new Vector2(Random.Range(-transform.localScale.x, transform.localScale.x), Random.Range(-transform.localScale.y, transform.localScale.y)) / 2;
}
