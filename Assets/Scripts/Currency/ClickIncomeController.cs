using Unity.VisualScripting;
using UnityEngine;

public sealed class ClickIncomeController : MonoBehaviour
{
    CurrencyController _currencyController;
    PlayerStatsController _playerStatsController;

    public void Initialize(CurrencyController currencyController, PlayerStatsController playerStatsController)
    {
        _currencyController = currencyController;
        _playerStatsController = playerStatsController;
    }

    public void RegisterClick()
    {
        int income = _playerStatsController.MoneyPerClick;

        if (income > 0)
        {
            _currencyController.Add(income);
        }
    }
}
