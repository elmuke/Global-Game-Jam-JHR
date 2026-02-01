using UnityEngine;
using UnityEngine.UI;

public class MaskHelp : MonoBehaviour
{
    private Image _image;
    void Start()
    {
        _image = GetComponent<Image>();
        _image.enabled = false;
        StateManager.StateChanged += OnGameStateChanged;
    }


    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }


    private void OnGameStateChanged(GameState state)
    {
        _image.enabled = state == GameState.PlacingMask;
    }
}
