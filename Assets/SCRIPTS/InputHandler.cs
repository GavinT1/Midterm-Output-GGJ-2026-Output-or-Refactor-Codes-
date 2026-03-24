using UnityEngine;
using MyGame;
public class InputHandler : MonoBehaviour
{
    public GameplayFactory factory;
    public Transform firePoint;
    public GameController_Messy controller;

    private ICommand shootCommand;
    private ICommand pauseCommand;
    private ICommand restartCommand;

    void Start()
    {
        shootCommand = new ShootCommand(factory, firePoint);
        pauseCommand = new PauseCommand(controller);
        restartCommand = new RestartCommand(controller);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            shootCommand.Execute();

        if (Input.GetKeyDown(KeyCode.P))
            pauseCommand.Execute();

        if (Input.GetKeyDown(KeyCode.R))
            restartCommand.Execute();
    }
}