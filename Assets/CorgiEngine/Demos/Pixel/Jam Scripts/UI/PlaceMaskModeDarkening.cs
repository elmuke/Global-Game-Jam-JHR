using System.Collections;
using UnityEngine;

/// <summary>
/// Causes the screen to darken while the mask is being placed.
/// Attach this to a covering panel child of the Camera
/// </summary>
public class PlaceMaskModeDarkening : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float targetAlpha = 0.75f;
    public float pulseFrequency = 0.5f;
    public float pulseIntensity = 0.2f;

    private SpriteRenderer _sprite;
    private float fadeStartTime = float.NegativeInfinity;
    private bool _maskIsOn = false;

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
        if (gameState == GameState.Normal)
            _sprite.enabled = false;
        if (gameState == GameState.PlacingMask)
        {
            _sprite.enabled = true;
            StartCoroutine(FadeIn());
        }
        //Deprecating:
        /*
        if (gameState == GameState.MaskOn)
        {
            _sprite.enabled = true;
            _maskIsOn = true;
        }
        else
            _maskIsOn = false;
        */
        // New version:
        if (gameState == GameState.MaskOn)
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

    private void Update()
    {
        if (_maskIsOn)
        {
            //Pulse
            var spriteColor = _sprite.color;
            spriteColor.a = (Mathf.Sin(Time.time * pulseFrequency) + 1) * 0.5f * pulseIntensity;
            _sprite.color = spriteColor;
        }
    }

}
