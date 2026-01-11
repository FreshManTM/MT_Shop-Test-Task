using System.Collections;
using UnityEngine;

public sealed class PassiveIncomeController : MonoBehaviour
{
    [SerializeField] float _tickInterval = 1f; // seconds

    CurrencyController _currencyController;
    PlayerStatsController _playerStatsController;

    public void Initialize(CurrencyController currencyController, PlayerStatsController playerStatsController)
    {
        _currencyController = currencyController;
        _playerStatsController = playerStatsController;

        StartCoroutine(PassiveIncomeRoutine());

    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator PassiveIncomeRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_tickInterval);

        while (true)
        {
            yield return wait;

            int income = _playerStatsController.PassiveIncomePerSecond;
            if (income > 0)
            {
                _currencyController.Add(income);
            }
        }
    }

}
