using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class CustomButton : MonoBehaviour
{
	public UnityEvent onClick;
	private Sprite unhoveredSprite;
	[SerializeField] Sprite hoveredSprite;
	private bool mouseOver = false;
	[SerializeField] KeyCode primaryKey;
	[Header("Plugs")]
	[SerializeField] TextMeshPro text;

	void Start()
	{
		unhoveredSprite = GetComponent<SpriteRenderer>().sprite;
	}

	void Update()
	{
		if (mouseOver && Input.GetKeyDown(primaryKey))
		{
			onClick.Invoke();
		}
	}


	void OnMouseEnter()
	{
		mouseOver = true;
		GetComponent<SpriteRenderer>().sprite = hoveredSprite;
		text.color = Color.black;
	}

	void OnMouseExit()
	{
		mouseOver = false;
		GetComponent<SpriteRenderer>().sprite = unhoveredSprite;
		text.color = Color.white;
	}
}