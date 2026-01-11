using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class PlayerStatsController: MonoBehaviour
{
    [SerializeField] int _defaultMoneyPerClick;
    [SerializeField] InventoryMilestonesData _milestonesData;

    //Income
    public int MoneyPerClickFlat { get; private set; } = 10;
    public int PassiveIncomeFlat { get; private set; } = 0;
    public int FinalMoneyPerClick => MoneyPerClickFlat + (MoneyPerClickFlat * _clickBonusPercent / 100);
    public int FinalPassiveIncome => PassiveIncomeFlat + (PassiveIncomeFlat * _passiveBonusPercent / 100);

    //Percentages
    public int ClickBonusPercent => _clickBonusPercent;
    public int PassiveBonusPercent => _passiveBonusPercent;

    //Milestones
    public int CurrentMilestoneIndex => _currentMilestoneIndex;
    public IReadOnlyList<InventoryMilestone> Milestones => _milestonesData.Milestones;

    InventoryController _inventoryController;
    int _currentMilestoneIndex = -1;
    int _clickBonusPercent;
    int _passiveBonusPercent;

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
        MoneyPerClickFlat = _defaultMoneyPerClick;
        PassiveIncomeFlat = 0;

        foreach (var item in _inventoryController.Items)
        {
            if (item.ItemDefinition.ItemType == ItemType.MoneyPerClick)
                MoneyPerClickFlat += item.ItemDefinition.Value * item.Quantity;

            if (item.ItemDefinition.ItemType == ItemType.PassiveIncome)
                PassiveIncomeFlat += item.ItemDefinition.Value * item.Quantity;
        }

        ApplyMilestones();
    }


    void ApplyMilestones()
    {
        int totalItems = 0;
        foreach (var item in _inventoryController.Items)
            totalItems += item.Quantity;

        int nextIndex = _currentMilestoneIndex + 1;

        if (nextIndex >= _milestonesData.Milestones.Count)
            return;

        InventoryMilestone nextMilestone = _milestonesData.Milestones[nextIndex];

        if (totalItems >= nextMilestone.RequiredItemCount)
        {
            _currentMilestoneIndex = nextIndex;
            _clickBonusPercent += nextMilestone.ClickBonusPercent;
            _passiveBonusPercent += nextMilestone.PassiveBonusPercent;
        }
    }

}
