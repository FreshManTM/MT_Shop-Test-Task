using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] ClickIncomeController _clickIncomeController;
    [SerializeField] PassiveIncomeController _passiveIncomeController;
    [SerializeField] ShopController _shopController;
    [SerializeField] PlayerStatsController _playerStatsController;
    [SerializeField] CurrencyController _currencyController;
    [SerializeField] InventoryController _inventoryController;
    [SerializeField] GameStateController _gameStateController;

    [Header("UI")]
    [SerializeField] UIController _uiController;
    [SerializeField] ShopView _shopView;
    [SerializeField] InventoryView _inventoryView;

    private void Awake()
    {
        Initilization();
    }

    void Initilization()
    {
        _playerStatsController.Initialize(_inventoryController);
        _clickIncomeController.Initialize(_currencyController, _playerStatsController);
        _passiveIncomeController.Initialize(_currencyController, _playerStatsController);
        _shopController.Initialize(_currencyController, _inventoryController);

        _uiController.Initialize(_gameStateController, _currencyController);
        _inventoryView.Initialize(_gameStateController, _inventoryController, _playerStatsController);
        _shopView.Initialize(_gameStateController, _shopController);
    }
}