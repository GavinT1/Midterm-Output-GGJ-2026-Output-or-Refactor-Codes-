using MyGame;
public class RestartCommand : ICommand
{
    private GameController_Messy controller;

    public RestartCommand(GameController_Messy ctrl)
    {
        controller = ctrl;
    }

    public void Execute()
    {
        controller.RestartGame();
    }
}