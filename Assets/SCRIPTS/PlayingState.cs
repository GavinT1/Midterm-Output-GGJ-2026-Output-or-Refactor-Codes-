using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter() { Time.timeScale = 1f; }
    public void Tick() { }
    public void Exit() { }
}