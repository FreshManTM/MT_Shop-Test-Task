using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class InventoryView : ViewBase
{
    [SerializeField] InventoryItemUI _inventoryItemPrefab;
    [SerializeField] Transform _contentParent;

    [SerializeField] TMP_Text _statisticText;

    [Header("Milestones")]
    [SerializeField] TMP_Text _milestoneTitleText;
    [SerializeField] TMP_Text _milestoneProgressText;
    [SerializeField] TMP_Text _milestoneRewardText;

    InventoryController _inventoryController;
    PlayerStatsController _playerStatsController;

    Dictionary<ItemDefinition, InventoryItemUI> _spawnedItems = new Dictionary<ItemDefinition, InventoryItemUI>();

    public void Initialize(GameStateController stateController, InventoryController inventoryController, PlayerStatsController playerStatsController)
    {
        base.Initialize(stateController);
        _inventoryController = inventoryController;
        _playerStatsController = playerStatsController;

        _inventoryController.OnInventoryChanged += RefreshInventory;
        _inventoryController.OnInventoryChanged += UpdateStatisticText;
        _inventoryController.OnInventoryChanged += UpdateMilestoneUI;
        RefreshInventory();
        UpdateStatisticText();
        UpdateMilestoneUI();

    }


    void OnDestroy()
    {
        _inventoryController.OnInventoryChanged -= RefreshInventory;
        _inventoryController.OnInventoryChanged -= UpdateStatisticText;
        _inventoryController.OnInventoryChanged -= UpdateMilestoneUI;
    }

    void RefreshInventory()
    {
        foreach (var item in _inventoryController.Items)
        {
            if (_spawnedItems.TryGetValue(item.ItemDefinition, out var existingUI))
            {
                existingUI.SetInventoryItem(item);
            }
            else
            {
                GameObject go = Instantiate(_inventoryItemPrefab.gameObject, _contentParent);
                InventoryItemUI inventoryItemUI = go.GetComponent<InventoryItemUI>();
                inventoryItemUI.SetInventoryItem(item);

                _spawnedItems.Add(item.ItemDefinition, inventoryItemUI);
            }
        }
    }

    void UpdateStatisticText()
    {
        _statisticText.text =
            $"Money per click: {_playerStatsController.FinalMoneyPerClick}$ " +
            $"(+{_playerStatsController.ClickBonusPercent}%)\n" +
            $"Passive Income: +{_playerStatsController.FinalPassiveIncome}/s " +
            $"(+{_playerStatsController.PassiveBonusPercent}%)";

    }
    void UpdateMilestoneUI()
    {
        int currentIndex = _playerStatsController.CurrentMilestoneIndex;
        var milestones = _playerStatsController.Milestones;

        int totalItems = 0;
        foreach (var item in _inventoryController.Items)
            totalItems += item.Quantity;

        if (currentIndex + 1 >= milestones.Count)
        {
            _milestoneTitleText.text = "All milestones unlocked";
            _milestoneProgressText.text = "";
            _milestoneRewardText.text = "";
            return;
        }

        InventoryMilestone next = milestones[currentIndex + 1];

        _milestoneTitleText.text = $"Milestone {currentIndex + 2}";
        _milestoneProgressText.text =
            $"Progress: {totalItems} / {next.RequiredItemCount} items";

        _milestoneRewardText.text =
            $"Reward:\n+{next.ClickBonusPercent}% click\n+{next.PassiveBonusPercent}% passive";
    }


}
