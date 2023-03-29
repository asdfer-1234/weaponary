using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class FinalTimeDisplay : MonoBehaviour
{
	void Start()
	{
		GetComponent<TextMeshPro>().text = GetComponent<TextMeshPro>().text + RichTextBuilder.FloatString(GlobalData.time, RichTextBuilder.Palette.goodPalette);
	}
}
