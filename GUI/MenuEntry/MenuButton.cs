using Terminal.Gui;

class MenuButton
{
    public Button button;
    public Label label;

    protected GUIGame _game;

    public MenuButton(GUIGame game, string buttonText, string labelText)
    {
        _game = game;

        button = new Button(buttonText);
        label = new Label(labelText);

        label.X = 6;
    }
}