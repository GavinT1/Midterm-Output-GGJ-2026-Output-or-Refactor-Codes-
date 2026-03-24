
using UnityEngine;
public class GameOverState : IGameState
{
    public void Enter() { Time.timeScale = 0f; }
    public void Tick() { }
    public void Exit() { }
}