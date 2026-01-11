using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class InventoryView : ViewBase
{
    [SerializeField] InventoryItemUI _inventoryItemPrefab;
    [SerializeField] Transform _contentParent;

    [SerializeField] TMP_Text _statisticText;

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
        RefreshInventory();
        UpdateStatisticText();
    }


    void OnDestroy()
    {
        _inventoryController.OnInventoryChanged -= RefreshInventory;
        _inventoryController.OnInventoryChanged -= UpdateStatisticText;
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
        _statisticText.text = $"Money per click: {_playerStatsController.MoneyPerClick}$\nPassive Income: +{_playerStatsController.PassiveIncomePerSecond}/s";
    }
}
