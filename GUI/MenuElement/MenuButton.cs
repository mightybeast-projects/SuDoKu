using Terminal.Gui;

class MenuButton : View
{
    public Button button;
    public Label label;

    protected GUIGame _game;

    public MenuButton(GUIGame game, string buttonText, string labelText)
        : base()
    {
        _game = game;

        button = new Button(buttonText);
        label = new Label(labelText);

        label.X = 6;

        Add(button, label);
        Height = 1;
        Width = Dim.Fill();
    }
}