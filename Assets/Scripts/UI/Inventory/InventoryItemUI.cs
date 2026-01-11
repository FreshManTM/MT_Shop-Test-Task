using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _quantityText;
    [SerializeField] TextMeshProUGUI _incomeText;
    [SerializeField] Image _iconImage;

    public void SetInventoryItem(InventoryItem item)
    {
        _nameText.text = item.ItemDefinition.ItemName;
        _quantityText.text = $"Amount: x{item.Quantity}";

        string bonusText = "";
        if (item.ItemDefinition.ItemType == ItemType.PassiveIncome)
            bonusText = $"+{item.TotalValue}/s";
        else if (item.ItemDefinition.ItemType == ItemType.MoneyPerClick)
            bonusText = $"+{item.TotalValue}/click";

        _incomeText.text = $"Total bonus:\n{bonusText}";
        _iconImage.sprite = item.ItemDefinition.Icon;
    }
}
