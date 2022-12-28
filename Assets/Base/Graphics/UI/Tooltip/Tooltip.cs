using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
	[SerializeField] GameObject graphics;
	[SerializeField] TextMeshPro textbox;
	[SerializeField] SpriteRenderer box;


	private const string selfTag = "Tooltip";
	public static Tooltip main => GameObject.FindGameObjectWithTag(selfTag).GetComponent<Tooltip>();

	public string text
	{
		get => textbox.text;
		set
		{
			textbox.text = value;
			UpdateBox();
		}
	}

	private static Vector2 offset = new Vector2(7f / 16f, 6f / 16f);
	private static Vector2 defaultSize = new Vector2(13f / 16f, 13f / 16f);
	private Vector2 cursorOffset;



	public void Start()
	{
		cursorOffset = transform.localPosition;
		UpdateBox();

	}

	public void Update()
	{
		UpdateBoxPosition();
	}

	public void UpdateBoxPosition()
	{
		Vector2 maximumPoint = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0));
		Vector2 minimumPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight));
		Debug.DrawLine(maximumPoint, minimumPoint, Color.cyan);
		if (-box.size.y + transform.parent.position.y + cursorOffset.y < maximumPoint.y)
		{
			transform.localPosition = new Vector2(transform.localPosition.x, -cursorOffset.y + box.size.y);
		}
		else
		{
			transform.localPosition = new Vector2(transform.localPosition.x, cursorOffset.y);
		}
		if (transform.parent.position.x + cursorOffset.x + box.size.x > maximumPoint.x)
		{
			transform.localPosition = new Vector2(-cursorOffset.x - box.size.x, transform.localPosition.y);
		}
		else
		{
			transform.localPosition = new Vector2(cursorOffset.x, transform.localPosition.y);
		}
	}

	public void UpdateBox()
	{

		if (text == "")
		{
			box.size = defaultSize;
		}
		else
		{
			textbox.ForceMeshUpdate();
			box.size = textbox.GetRenderedValues(true) + offset;
		}
	}

	public bool visible
	{
		get
		{
			return graphics.activeSelf;
		}
		set
		{
			graphics.SetActive(value);
		}
	}
}
