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

        _incomeText.text = BuildInventoryEffectText(item);
        _iconImage.sprite = item.ItemDefinition.Icon;
    }

    string BuildInventoryEffectText(InventoryItem item)
    {
        if (item.ItemDefinition.Effects.Count == 0)
            return string.Empty;

        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.AppendLine("Total bonus:");

        foreach (ItemEffect effect in item.ItemDefinition.Effects)
        {
            builder.AppendLine(effect.GetTotalValueString(item));
        }

        return builder.ToString().TrimEnd();
    }
}
