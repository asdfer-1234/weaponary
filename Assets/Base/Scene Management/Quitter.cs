using UnityEngine;

public class Quitter : MonoBehaviour
{
	public void Quit()
	{
		Debug.Log("Quit. In Editor This will not have an effect otherwise logging this message");
		Application.Quit();
	}
}
