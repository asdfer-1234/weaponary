using UnityEngine;

[CreateAssetMenu]
public class Ammunition : Item
{
	public float damageMultiplier;
	public float attackSpeedMultiplier;
	public int spreadMultiplier;
	public int additionalPiercing;
	public int additionalBullets;

	public GameObject Projectile;

	public override string tooltip => base.tooltip +
		RichTextBuilder.ValueLine("Damage:", RichTextBuilder.MultiplierString(damageMultiplier, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Attack Speed:", RichTextBuilder.MultiplierString(attackSpeedMultiplier, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Spread Multiplier:", RichTextBuilder.MultiplierString(spreadMultiplier, RichTextBuilder.Palette.badPalette)) +
		RichTextBuilder.ValueLine("Additional Bullets:", RichTextBuilder.IntegerString(additionalBullets, RichTextBuilder.Palette.goodPalette));
}
