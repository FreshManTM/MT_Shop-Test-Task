using System;
using UnityEngine;

public sealed class CurrencyController : MonoBehaviour
{
    [SerializeField] int _startAmount = 0;

    int _currentAmount;

    public int CurrentAmount => _currentAmount;

    public event Action<int> OnCurrencyChanged;

    void Awake()
    {
        _currentAmount = _startAmount;
        NotifyCurrencyChanged();
    }

    public void Add(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        _currentAmount += amount;
        NotifyCurrencyChanged();
    }

    public bool CanSpend(int amount)
    {
        return amount > 0 && _currentAmount >= amount;
    }

    public bool Spend(int amount)
    {
        if (!CanSpend(amount))
        {
            return false;
        }

        _currentAmount -= amount;
        NotifyCurrencyChanged();
        return true;
    }

    void NotifyCurrencyChanged()
    {
        OnCurrencyChanged?.Invoke(_currentAmount);
    }
}
