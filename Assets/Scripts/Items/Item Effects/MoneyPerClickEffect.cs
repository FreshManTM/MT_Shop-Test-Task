using UnityEngine;

[CreateAssetMenu(menuName = "Items/Effects/Money Per Click")]
public sealed class MoneyPerClickEffect : ItemEffect
{

    public override void Apply(PlayerStatsController stats, InventoryItem item)
    {
        stats.AddMoneyPerClick(item.TotalValue);
    }

    public override string GetValueString(ItemDefinition item)
    {
        return $"+{item.Value}/click";
    }

    public override string GetTotalValueString(InventoryItem item)
    {
        return $"+{item.TotalValue}/click";
    }
}
