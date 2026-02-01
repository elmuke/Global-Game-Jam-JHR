using System;
using UnityEngine;

public enum GameState
{
    Normal,
    PlacingMask,
    MaskOn,
} 

/// <summary>
/// Keeps track of the state of the Game.
/// </summary>
public static class StateManager 
{
    private static GameState _state;

    public static event Action <GameState> StateChanged;

    public static void SetState(GameState state)
    {
        _state = state;
        StateChanged?.Invoke(state);
    }
}


