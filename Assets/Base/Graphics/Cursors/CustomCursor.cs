using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(SpriteRenderer))]
public class CustomCursor : MonoBehaviour
{

	void Start()
	{
		Cursor.visible = false;
#if UNITY_EDITOR
		Cursor.visible = true;
#endif
	}

	void Update()
	{
		transform.position = (Vector2)Camera.main.GetComponent<PixelPerfectCamera>().RoundToPixel(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
