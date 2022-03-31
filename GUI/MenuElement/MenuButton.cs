using Terminal.Gui;

class MenuButton : View
{
    public Button button;

    protected GUIGame _game;
    Label label;

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