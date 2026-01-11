using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text _currencyText;

    GameStateController _gameStateController;
    CurrencyController _currencyController;

    public void Initialize(
        GameStateController stateController,
        CurrencyController currencyController)
    {
        _gameStateController = stateController;
        _currencyController = currencyController;

        _currencyController.OnCurrencyChanged += UpdateCurrencyText;
        UpdateCurrencyText(_currencyController.CurrentAmount);
    }

    void OnDestroy()
    {
        _currencyController.OnCurrencyChanged -= UpdateCurrencyText;
    }

    public void OnShopButtonClicked() => _gameStateController.SwitchState(GameState.Shop);
    public void OnInventoryButtonClicked() => _gameStateController.SwitchState(GameState.Inventory);
    public void OnCloseViewClicked() => _gameStateController.SwitchState(GameState.Idle);

    void UpdateCurrencyText(int amount)
    {
        _currencyText.text = $"Coins: {amount}";
    }

}
