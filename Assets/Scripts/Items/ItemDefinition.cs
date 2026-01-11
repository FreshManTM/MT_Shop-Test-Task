using UnityEngine;

[CreateAssetMenu(
    fileName = "ItemDefinition",
    menuName = "Shop/Item Definition"
)]
public sealed class ItemDefinition : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] string _itemName;

    [Header("Presentation")]
    [SerializeField] Sprite _icon;
    
    [Header("Economy")]
    [SerializeField] int _price;

    [Header("Type")]
    [SerializeField] ItemType _itemType;

    [Header("Values")]
    [SerializeField] int _effectValue;

    public string ItemName => _itemName;
    public Sprite Icon => _icon;
    public int Price => _price;
    public ItemType ItemType => _itemType;
    public int Value => _effectValue;
}
