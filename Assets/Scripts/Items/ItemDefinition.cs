using UnityEngine;

[CreateAssetMenu(
    fileName = "ItemDefinition",
    menuName = "Shop/Item Definition"
)]
public sealed class ItemDefinition : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] string _id;
    [SerializeField] string _itemName;

    [Header("Presentation")]
    [SerializeField] Sprite _icon;
    [SerializeField][TextArea(2, 4)] string _description;

    [Header("Economy")]
    [SerializeField] int _price;
    [SerializeField] int _passiveIncomePerSecond;

    public string Id => _id;
    public string ItemName => _itemName;
    public Sprite Icon => _icon;
    public string Description => _description;
    public int Price => _price;
    public int PassiveIncomePerSecond => _passiveIncomePerSecond;
}
