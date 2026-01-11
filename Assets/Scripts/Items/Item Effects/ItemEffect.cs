using UnityEngine;

public abstract class ItemEffect : ScriptableObject
{
	public abstract void Apply(PlayerStatsController stats, InventoryItem item);

    public virtual string GetValueString(ItemDefinition item)
    {
        return $"+{item.Value}";
    }

    public virtual string GetTotalValueString(InventoryItem item)
    {
        return $"+{item.TotalValue}";
    }
}
