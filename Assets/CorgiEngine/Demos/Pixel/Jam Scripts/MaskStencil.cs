using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attach this to the Level Mask Stencil to make it move while in Placing Mask mode
/// </summary>
/// <remarks>
/// Make sure the object has a Player Input component with the right Actions and set to Send Messages
/// </remarks>
public class MaskStencil : MonoBehaviour
{
    public float speed = 5;

    private SpriteRenderer _spriteRenderer;
    private bool _placeMaskMode = false;
    private Vector2 _moveInput;


    /// <summary>
    /// Input for mask movement
    /// </summary>
    public void OnPrimaryMovement(InputValue value)
    {
        if (_placeMaskMode)
            _moveInput = value.Get<Vector2>();
    }


    /// <summary>
    /// The key for jumping will commit mask placemnet
    /// </summary>
    public void OnJump()
    {
        StateManager.SetState(GameState.MaskOn);
        _placeMaskMode = false;
    }



    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StateManager.StateChanged += OnGameStateChanged;
    }


    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }


    private void OnGameStateChanged(GameState state)
    {
        _spriteRenderer.enabled = state == GameState.PlacingMask;
        if (state == GameState.PlacingMask)
            _placeMaskMode = true;
    }


    private void Update()
    {
        if (_placeMaskMode)
            transform.Translate(_moveInput * speed * Time.deltaTime);
    }


}
