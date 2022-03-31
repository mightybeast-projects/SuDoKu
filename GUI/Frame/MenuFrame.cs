using Terminal.Gui;

class MenuFrame : FrameView
{
    MenuListView _menuListView;
    GenerateButton _generateButton;
    ResetButton _resetButton;
    CheckButton _checkButton;
    HintButton _hintButton;
    ExitButton _exitButton;

    public MenuFrame(GUIGame game) : base()
    {
        InitializeFrameSettings();
        InstantiateButtons(game);
        InstantiateMenuListView();

        Add(_menuListView);
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

    void InstantiateMenuListView()
    {
        _menuListView = new MenuListView();
        _menuListView.Add(new Label("[ Alt + key ] or click with mouse"));
        _menuListView.Add(new Label(" "));
        _menuListView.Add(_generateButton);
        _menuListView.Add(_resetButton);
        _menuListView.Add(_checkButton);
        _menuListView.Add(_hintButton);
    }

    void InstantiateButtons(GUIGame game)
    {
        _generateButton = new GenerateButton(game);
        _resetButton = new ResetButton(game);
        _checkButton = new CheckButton(game);
        _exitButton = new ExitButton(game);
        _hintButton = new HintButton(game);
    }
}