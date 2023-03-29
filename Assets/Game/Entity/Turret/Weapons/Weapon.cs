using UnityEngine;


[CreateAssetMenu]
public class Weapon : Item
{
	[Header("Weapon")]
	public int damage;
	public float attackSpeed;
	public float spread;
	public float randomSpread => Random.Range(-spread, spread) / 2;
	public float attackDelay => 1f / attackSpeed;
	public float swivelSpeed;

	public override string tooltip =>
		base.tooltip +
		RichTextBuilder.ValueLine("Damage:", RichTextBuilder.IntegerString(damage, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Attack Speed:", RichTextBuilder.FloatString(attackSpeed, RichTextBuilder.Palette.goodPalette)) +
		RichTextBuilder.ValueLine("Spread:", RichTextBuilder.FloatString(spread, RichTextBuilder.Palette.badPalette)) +
		RichTextBuilder.ValueLine("Swivel Speed:", RichTextBuilder.FloatString(swivelSpeed, RichTextBuilder.Palette.goodPalette));
}
