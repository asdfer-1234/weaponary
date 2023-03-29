using UnityEngine;

public class SplitStone : Stone
{
	[SerializeField] private GameObject child;
	[SerializeField] private int childCount;
	[SerializeField] private float childSpread;
	[SerializeField] private float splitForce;

	//private Vector2 randomChildSpread => Random.insideUnitCircle * childSpread;

	private void SpawnChildren()
	{
		for (int i = 0; i < childCount; i++)
		{
			Vector2 direction = Random.insideUnitCircle;
			Rigidbody2D instantiatedRigidbody = Instantiate(child, transform.position + (Vector3)direction * childSpread, Quaternion.identity).GetComponent<Rigidbody2D>();
			instantiatedRigidbody.AddForce(direction.normalized * splitForce);
		}
	}

	public override void OnDeath()
	{
		base.OnDeath();
		SpawnChildren();
	}
}
