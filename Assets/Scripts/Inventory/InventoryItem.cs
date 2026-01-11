using UnityEngine;

[System.Serializable]
public sealed class InventoryItem
{
    [SerializeField] ItemDefinition _itemDefinition;
    [SerializeField] int _quantity;

    public ItemDefinition ItemDefinition => _itemDefinition;
    public int Quantity => _quantity;
    public int TotalValue => _itemDefinition.Value * _quantity;

    public InventoryItem(ItemDefinition itemDefinition)
    {
        _itemDefinition = itemDefinition;
        _quantity = 1;
    }

    public void AddQuantity(int amount = 1)
    {
        _quantity += amount;
    }
}
