using Codice.Client.Common.GameUI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Causes the screen to darken while the mask is being placed.
/// Attach this to a covering panel child of the Camera
/// </summary>
public class PlaceMaskModeDarkening : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float targetAlpha = 0.75f;

    private SpriteRenderer _sprite;
    private float fadeStartTime = float.NegativeInfinity;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.enabled = false;
        StateManager.StateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        StateManager.StateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.PlacingMask)
        {
            _sprite.enabled = true;
            StartCoroutine(FadeIn());
        }
        else
            _sprite.enabled = false;
    }

    private IEnumerator FadeIn()
    {
        fadeStartTime = Time.time;
        while (true)
        {
            float fadeRatio = (Time.time - fadeStartTime) / fadeDuration;
            var spriteColor = _sprite.color;
            spriteColor.a= targetAlpha * fadeRatio;
            _sprite.color = spriteColor;
            if (fadeRatio < 1)
                yield return null;
            else
                yield break;
        }
    }
}
