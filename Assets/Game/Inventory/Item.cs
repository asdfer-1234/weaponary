using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
	[Header("Item")]
	public Sprite sprite;
	public string itemName;
	public int stackSize;
	public string description;

	public virtual string tooltip =>
		RichTextBuilder.Line(itemName) +
		RichTextBuilder.Line(RichTextBuilder.ColorizeText(description, RichTextBuilder.Palette.disabledColor)) +
		RichTextBuilder.ValueLine("Stack Size:", RichTextBuilder.StackSizeString(stackSize, RichTextBuilder.Palette.goodPalette));
}