using UnityEngine;
using MoreMountains.CorgiEngine;

public class CameraByGameState : MonoBehaviour
{
    private CameraController _cameraController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cameraController = GetComponent<CameraController>();
        StateManager.StateChanged += OnGameStateChanged;
    }

    
    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.MaskOn)
            _cameraController.enabled = false;
        if (state == GameState.Normal)
            _cameraController.enabled = true;
    }
}
