using TMPro;
using UnityEngine;

public sealed class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] CurrencyController _currencyController;
    [SerializeField] TMP_Text _currencyText;

    void Awake()
    {
        if (_currencyController == null)
            Debug.LogError("CurrencyController reference missing!");

        if (_currencyText == null)
            Debug.LogError("TMP_Text reference missing!");
    }

    void OnEnable()
    {
        _currencyController.OnCurrencyChanged += UpdateText;
        UpdateText(_currencyController.CurrentAmount);
    }

    void OnDisable()
    {
        _currencyController.OnCurrencyChanged -= UpdateText;
    }

    void UpdateText(int amount)
    {
        _currencyText.text = $"Coins: {amount}";
    }
}
