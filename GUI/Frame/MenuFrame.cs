using Terminal.Gui;

class MenuFrame : FrameView
{
    GenerateButton _generateButton;
    ResetButton _resetButton;
    CheckButton _checkButton;
    HintButton _hintButton;
    ExitButton _exitButton;

    public MenuFrame(GUIGame game) : base()
    {
        InitializeFrameSettings();

        _generateButton = new GenerateButton(game);
        _resetButton = new ResetButton(game);
        _checkButton = new CheckButton(game);
        _exitButton = new ExitButton(game);
        _hintButton = new HintButton(game);

        MenuListView menuListView = new MenuListView();
        menuListView.Add(_generateButton);
        menuListView.Add(_resetButton);
        menuListView.Add(_checkButton);
        menuListView.Add(_hintButton);

        Add(menuListView);
        Add(_exitButton);
    }

    public void EnablePuzzleButtons()
    {
        _resetButton.button.Enabled = true;
        _checkButton.button.Enabled = true;
        _hintButton.button.Enabled = true;
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