using MyGame;
public class PauseCommand : ICommand
{
    private GameController_Messy controller;

    public PauseCommand(GameController_Messy ctrl)
    {
        controller = ctrl;
    }

    public void Execute()
    {
        controller.TogglePause();
    }
}