using UnityEngine;
public class PausedState : IGameState
{
    public void Enter() { Time.timeScale = 0f; }
    public void Tick() { }
    public void Exit() { Time.timeScale = 1f; }
}