using Terminal.Gui;

class MenuFrame : FrameView
{
    public MenuFrame(GUIGame game) : base()
    {
        InitializeFrameSettings();

        GeneratePuzzleButton generateButton = new GeneratePuzzleButton(game);
        ResetButton resetButton = new ResetButton(game);
        CheckButton checkButton = new CheckButton(game);

        Add(generateButton.button, generateButton.label);
        Add(resetButton.button, resetButton.label);
        Add(checkButton.button, checkButton.label);
    }

    void InitializeFrameSettings()
    {
        Title = "Menu";
        ColorScheme = Colors.Menu;
        Width = Dim.Fill();
        Height = 15;
        X = 33;
        Y = Pos.Center();
        Border.BorderStyle = BorderStyle.Double;
    }
}