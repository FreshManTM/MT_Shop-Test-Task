using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "InventoryMilestonesData",
    menuName = "Inventory/Milestones Data"
)]
public sealed class InventoryMilestonesData : ScriptableObject
{
    [SerializeField] List<InventoryMilestone> _milestones;

    public IReadOnlyList<InventoryMilestone> Milestones => _milestones;
}
