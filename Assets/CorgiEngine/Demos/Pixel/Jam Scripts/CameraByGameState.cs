using UnityEngine;
using MoreMountains.CorgiEngine;


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
            _cameraController.enabled = false;
        if (state == GameState.MaskOn)
            _cameraController.enabled = false;
    }
}
