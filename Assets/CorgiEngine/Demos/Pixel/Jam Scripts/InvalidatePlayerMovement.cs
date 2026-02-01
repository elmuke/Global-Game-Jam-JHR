using UnityEngine;
using MoreMountains.CorgiEngine;


/// <summary>
/// Stops the Main Character from movin on mask placement mode
/// </summary>
public class InvalidatePlayerMovement : MonoBehaviour
{
    private Character _character;
    void Start()
    {
        _character = GetComponent<Character>();
        StateManager.StateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.PlacingMask)
            _character.Freeze();
        else
            _character.UnFreeze(); ;
    }
}
