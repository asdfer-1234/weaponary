using UnityEngine;

public static class RichTextBuilder
{


	public class Palette
	{
		public static readonly Color goodColor = Color.green;
		public static readonly Color neutralColor = Color.yellow;
		public static readonly Color badColor = Color.red;
		public static readonly Color normalColor = Color.white;
		public static readonly Color disabledColor = Color.gray;
		public static readonly Palette goodPalette = new Palette(goodColor, badColor, neutralColor);
		public static readonly Palette badPalette = new Palette(badColor, goodColor, neutralColor);

		public Color positiveColor;
		public Color negativeColor;
		public Color zeroColor;
		public Palette(Color positiveColor, Color negativeColor, Color zeroColor)
		{
			this.positiveColor = positiveColor;
			this.negativeColor = negativeColor;
			this.zeroColor = zeroColor;
		}
	}

	public static string ColorizeText(string text, Color color)
	{
		return ColorTag(color) + text + ColorTag(Palette.normalColor);
	}

	private static string ColorTag(Color color)
	{

		return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">";
	}

	public static string MultiplierString(float multiplier, Palette palette)
	{
		if (multiplier == 1f)
		{
			return "";
		}
		float relativeMultiplier = multiplier - 1f;
		string stringMultiplier = (relativeMultiplier * 100).ToString("+#;-#;0.0") + "%";
		if (relativeMultiplier > 0)
		{
			return ColorizeText(stringMultiplier, palette.positiveColor);
		}
		else
		{
			return ColorizeText(stringMultiplier, palette.negativeColor);
		}
	}

	public static string IntegerString(int value, Palette palette)
	{
		if (value == 0)
		{
			return "";
		}
		if (value > 0)
		{
			return ColorizeText(value.ToString(), palette.positiveColor);
		}
		else
		{
			return ColorizeText(value.ToString(), palette.negativeColor);
		}
	}

	public static string FloatString(float value, Palette palette)
	{
		if (value == 0f)
		{
			return "";
		}
		if (value > 0f)
		{
			return ColorizeText(value.ToString(), palette.positiveColor);
		}
		else
		{
			return ColorizeText(value.ToString(), palette.negativeColor);
		}
	}

	public static string Value(string prefix, string value)
	{
		if (value == "")
		{
			return "";
		}
		return prefix + value;
	}

	public static string ValueLine(string prefix, string value)
	{
		return Line(Value(prefix, value));
	}

	public static string Line(string value)
	{
		if (value == "")
		{
			return "";
		}
		return value + "\n";
	}

	public static string MinMaxString(int value, int max, Palette palette)
	{
		if (value == 0)
		{
			return "";
		}

		if (value == max)
		{
			return ColorizeText(value.ToString(), palette.positiveColor);
		}

		if (value < 0 || value > max)
		{
			return ColorizeText(value.ToString(), palette.negativeColor);
		}
		return ColorizeText(value.ToString(), palette.zeroColor);
	}

	public static string StackSizeString(int stackSize, Palette palette)
	{
		if (stackSize == 1)
		{
			return "";
		}
		if (stackSize > 1)
		{
			return ColorizeText(stackSize.ToString(), palette.zeroColor);
		}
		return ColorizeText(stackSize.ToString(), palette.negativeColor);
	}
}
