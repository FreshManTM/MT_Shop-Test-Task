using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class InventoryController : MonoBehaviour
{
    public IReadOnlyList<InventoryItem> Items => _items;

    public event Action OnInventoryChanged;

    List<InventoryItem> _items = new List<InventoryItem>();

    public void AddItem(ItemDefinition itemDefinition)
    {
        if (itemDefinition == null)
            return;

        InventoryItem existingItem = _items.Find(i => i.ItemDefinition == itemDefinition);

        if (existingItem != null)
        {
            existingItem.AddQuantity();
        }
        else
        {
            _items.Add(new InventoryItem(itemDefinition));
        }

        OnInventoryChanged?.Invoke();
    }

}
