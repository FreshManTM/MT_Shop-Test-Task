using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ShopView : ViewBase
{
    [SerializeField] Transform _contentParent;
    [SerializeField] ShopItemUI _shopItemPrefab; // prefab with icon, name, price, button

    ShopController _shopController;
    Dictionary<ItemDefinition, ShopItemUI> _shopItems = new Dictionary<ItemDefinition, ShopItemUI>();


    public void Initialize(GameStateController stateController, ShopController shopController)
    {
        base.Initialize(stateController);
        _shopController = shopController;

        _shopController.OnPurchaseSuccess += OnPurchaseSuccess;
        _shopController.OnPurchaseFailed += OnPurchaseFailed;

        RefreshShop();
    }

    void OnDestroy()
    {
        if (_shopController != null)
        {
            _shopController.OnPurchaseSuccess -= OnPurchaseSuccess;
            _shopController.OnPurchaseFailed -= OnPurchaseFailed;
        }
    }

    void RefreshShop()
    {

        foreach (var item in _shopController.ShopItems)
        {
            ShopItemUI shopItemUI = Instantiate(_shopItemPrefab, _contentParent);
            shopItemUI.SetShopItem(item, () => _shopController.PurchaseItem(item));

            _shopItems[item] = shopItemUI;
        }
    }

    void OnPurchaseSuccess(ItemDefinition item)
    {
        _shopItems[item].PlaySuccessFeedback();
        Debug.Log("Purchased: " + item.ItemName);
    }

    void OnPurchaseFailed(ItemDefinition item)
    {
        _shopItems[item].PlayFailFeedback();
        Debug.Log("Cannot purchase: " + item.ItemName);
    }
}
