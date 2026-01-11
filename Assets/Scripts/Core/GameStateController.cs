using System;
using UnityEngine;

public sealed class GameStateController : MonoBehaviour
{
    GameState _currentState;

    public GameState CurrentState => _currentState;

    public event Action<GameState> OnStateChanged;

    public void SwitchState(GameState newState)
    {
        if (_currentState == newState)
            return;

        _currentState = newState;
        OnStateChanged?.Invoke(_currentState);
    }
}
