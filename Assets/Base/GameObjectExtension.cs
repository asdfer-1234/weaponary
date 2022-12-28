using UnityEngine;
public static class GameObjectExtension
{
	public static bool HasComponent<T>(this GameObject flag) where T : Component
	{
		return flag.GetComponent<T>() != null;
	}
}