using UnityEngine;

[CreateAssetMenu]
public class Ammunition : Item
{
	[Header("Ammunition")]
	public GameObject projectile;
	public float damageMultiplier;
	public float attackSpeedMultiplier;
	public float spreadMultiplier;
	public int additionalPiercing;
	public int additionalBullets;

	public override string tooltip => base.tooltip +
		RichTextBuilder.ValueLine("Damage:", RichTextBuilder.MultiplierString(damageMultiplier, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Attack Speed:", RichTextBuilder.MultiplierString(attackSpeedMultiplier, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Spread Multiplier:", RichTextBuilder.MultiplierString(spreadMultiplier, RichTextBuilder.Palette.badPalette)) +
		RichTextBuilder.ValueLine("Additional Bullets:", RichTextBuilder.IntegerString(additionalBullets, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Additional Piercing:", RichTextBuilder.IntegerString(additionalPiercing, RichTextBuilder.Palette.goodPalette));
}
