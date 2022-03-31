using Terminal.Gui;

class ExitButton : MenuButton
{
    public ExitButton(GUIGame game)
        : base(game, "E", ": Exit")
    {
        button.Clicked += () => Application.Shutdown();

        Y = Pos.Percent(100) - 1;
    }
}