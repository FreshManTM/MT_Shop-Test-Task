using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "Shop/Shop Data")]
public class ShopData : ScriptableObject
{
    public List<ItemDefinition> ShopItems;
}
