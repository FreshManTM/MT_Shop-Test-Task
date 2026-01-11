using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ShopController : MonoBehaviour
{
    [SerializeField] ShopData _shopData;
    public IReadOnlyList<ItemDefinition> ShopItems => _shopData.ShopItems;

    public event Action<ItemDefinition> OnPurchaseSuccess;
    public event Action<ItemDefinition> OnPurchaseFailed;

    CurrencyController _currencyController;
    InventoryController _inventoryController;

    public void Initialize(CurrencyController currencyController, InventoryController inventoryController)
    {
        _currencyController = currencyController;
        _inventoryController = inventoryController;
    }

    public void PurchaseItem(ItemDefinition item)
    {
        if (item == null)
            return;

        if (_currencyController.CanSpend(item.Price))
        {
            _currencyController.Spend(item.Price);
            _inventoryController.AddItem(item);
            OnPurchaseSuccess?.Invoke(item);
        }
        else
        {
            OnPurchaseFailed?.Invoke(item);
        }
    }
}
