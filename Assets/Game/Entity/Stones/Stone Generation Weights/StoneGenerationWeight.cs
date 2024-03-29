using UnityEngine;
using System;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class StoneGenerationWeight : ScriptableObject
{
	public GameObject stone;
	public int weight;
	public float requiredDifficulty;

	public static StoneGenerationWeight RandomStone(StoneGenerationWeight[] stones, float difficulty)
	{
		int totalWeight = 0;
		foreach (StoneGenerationWeight i in stones)
		{
			if (i.requiredDifficulty <= difficulty)
			{
				totalWeight += i.weight;
			}
		}

		int randomWeight = Random.Range(0, totalWeight);

		foreach (StoneGenerationWeight i in stones)
		{
			if (i.requiredDifficulty <= difficulty)
			{
				randomWeight -= i.weight;
				if (randomWeight < 0)
				{
					return i;
				}
			}
		}
		if (stones.Length == 0)
		{
			throw new ArgumentException("stones length is 0");
		}
		throw new NotSupposedToHappenException("Stone generation random could not generate a random. wth?");
	}
}
