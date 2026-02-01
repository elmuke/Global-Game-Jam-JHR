using UnityEngine;
using MoreMountains.CorgiEngine;

/// <summary>
/// Attach this to the item that activates the Mask Placement mode
/// </summary>
public class ActivateMaskItem : PickableItem
{

    protected override void Pick(GameObject picker)
    {
        StateManager.SetState(GameState.PlacingMask);
    }
}
