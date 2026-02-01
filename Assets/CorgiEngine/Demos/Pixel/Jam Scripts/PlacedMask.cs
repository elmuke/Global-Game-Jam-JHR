using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attach this to the Placed Mask game objec to make it work while in MaskOn mode
/// </summary>
/// <remarks>
/// Make sure the object is child of the Mask Stencil Game Object
/// </remarks>
public class PlacedMask : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Collider2D[] _colliders; //these are the actual mask holes


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _colliders = GetComponents<Collider2D>();
        foreach (var c in _colliders)
            c.enabled = false;
        StateManager.StateChanged += OnGameStateChanged;
    }


    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }


    private void OnGameStateChanged(GameState state)
    {
        _spriteRenderer.enabled = state == GameState.MaskOn;
        foreach (var c in _colliders)
            c.enabled = true;
    }




}
