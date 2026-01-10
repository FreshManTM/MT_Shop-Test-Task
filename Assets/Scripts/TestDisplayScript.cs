using TMPro;
using UnityEngine;

public sealed class TestDisplayScript : MonoBehaviour
{
    [SerializeField] CurrencyController _currencyController;
    [SerializeField] InventoryController _inventoryController;
    [SerializeField] TMP_Text _currencyText;
    [SerializeField] TMP_Text _passiveIncomeText;

    void Awake()
    {
        if (_currencyController == null)
            Debug.LogError("CurrencyController reference missing!");

        if (_currencyText == null)
            Debug.LogError("TMP_Text reference missing!");
    }

    void OnEnable()
    {
        _currencyController.OnCurrencyChanged += UpdateCurrencyText;
        _inventoryController.OnInventoryChanged += UpdatePassiveIncomeText;
        UpdateCurrencyText(_currencyController.CurrentAmount);
    }

    void OnDisable()
    {
        _currencyController.OnCurrencyChanged -= UpdateCurrencyText;
    }


    void UpdateCurrencyText(int amount)
    {
        _currencyText.text = $"Coins: {amount}";
    }
    void UpdatePassiveIncomeText()
    {
        _passiveIncomeText.text = $"Passive Income: {_inventoryController.GetTotalPassiveIncome()}";
    }
}
