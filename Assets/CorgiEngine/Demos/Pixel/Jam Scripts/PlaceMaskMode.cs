using MoreMountains.CorgiEngine;
using UnityEngine;

public class PlaceMaskMode : MonoBehaviour
{
    void Start()
    {
        StateManager.StateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }


    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.PlacingMask)
            ActivatePlacingMaskMode();
    }

    private void ActivatePlacingMaskMode()
    {
        Debug.Log("Entering Mask Placement mode");
        //do something
    }
}
