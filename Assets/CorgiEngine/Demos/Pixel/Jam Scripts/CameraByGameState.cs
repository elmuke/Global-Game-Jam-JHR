using UnityEngine;
using MoreMountains.CorgiEngine;

/// <summary>
/// Modifies the existing camera behavior based on game states
/// </summary>
/// <remarks>
/// This mecanic is being deprecated
/// </remarks>
public class CameraByGameState : MonoBehaviour
{
    private CameraController _cameraController;

    void Start()
    {
        _cameraController = GetComponent<CameraController>();
        StateManager.StateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }


    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.Normal)
            _cameraController.enabled = true;
        if (state == GameState.PlacingMask)
            _cameraController.enabled = true;
        if (state == GameState.MaskOn)
            _cameraController.enabled = false;
    }
}
