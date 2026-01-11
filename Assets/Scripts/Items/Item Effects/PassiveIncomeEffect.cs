using UnityEngine;

[CreateAssetMenu(menuName = "Items/Effects/Passive Income")]
public sealed class PassiveIncomeEffect : ItemEffect
{

    public override void Apply(PlayerStatsController stats, InventoryItem item)
    {
        stats.AddPassiveIncome(item.TotalValue);
    }

    public override string GetValueString(ItemDefinition item)
    {
        return $"+{item.Value}/s";
    }

    public override string GetTotalValueString(InventoryItem item)
    {
        return $"+{item.TotalValue}/s";
    }
}
