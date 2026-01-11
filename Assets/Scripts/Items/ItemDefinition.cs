using System.Collections.Generic;
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

    [Header("Effect")]
    [SerializeField] List<ItemEffect> _effects;

    [Header("Values")]
    [SerializeField] int _effectValue;

    public string ItemName => _itemName;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int Value => _effectValue;
    public IReadOnlyList<ItemEffect> Effects => _effects;
}
