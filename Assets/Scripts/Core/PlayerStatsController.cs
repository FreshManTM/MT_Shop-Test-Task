using System.Linq;
using UnityEngine;

public sealed class PlayerStatsController: MonoBehaviour
{
    [SerializeField] int _defaultMoneyPerClick;

    public int MoneyPerClick { get; private set; } = 10;
    public int PassiveIncomePerSecond { get; private set; } = 0;

    InventoryController _inventoryController;

    public void Initialize(InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        _inventoryController.OnInventoryChanged += RecalculateStats;

        RecalculateStats();
    }

    private void OnDestroy()
    {
        _inventoryController.OnInventoryChanged -= RecalculateStats;
    }

    void RecalculateStats()
    {
        var moneyPerClick = _inventoryController.Items
            .Where(i => i.ItemDefinition.ItemType == ItemType.MoneyPerClick)
            .Sum(i => i.ItemDefinition.Value * i.Quantity);
        MoneyPerClick = moneyPerClick + _defaultMoneyPerClick;


        PassiveIncomePerSecond = _inventoryController.Items
            .Where(i => i.ItemDefinition.ItemType == ItemType.PassiveIncome)
            .Sum(i => i.ItemDefinition.Value * i.Quantity);
    }

}
