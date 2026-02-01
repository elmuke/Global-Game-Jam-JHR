using UnityEngine;
using MoreMountains.CorgiEngine;

public class ActivateMaskItem : PickableItem
{
    /// <summary>
    /// Triggered when picked
    /// </summary>
    protected override void Pick(GameObject picker)
    {
        StateManager.SetState(GameState.PlacingMask);
    }
}
