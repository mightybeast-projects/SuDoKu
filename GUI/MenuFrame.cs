using System;
using Terminal.Gui;

class MenuFrame : FrameView
{
    SuDoKuFrame _sudokuFrame;

    Button _generateButton;
    Button _resetButton;

    public MenuFrame(SuDoKuFrame sudokuFrame) : base()
    {
        _sudokuFrame = sudokuFrame;

        InitializeFrameSettings();

        _generateButton = new Button("G");
        _generateButton.Clicked += () => 
        {
            var dialog = new Dialog("Choose puzzle difficulty");
            dialog.Width = 50;
            dialog.Height = 4;
            dialog.AddButton(CreateDifficultyButton("Easy"));
            dialog.AddButton(CreateDifficultyButton("Medium"));
            dialog.AddButton(CreateDifficultyButton("Hard"));
            Application.Run(dialog);
        };

        _resetButton = new Button("R") { Y = 1 };
        _resetButton.Clicked += () => _sudokuFrame.ResetGame();

        Add(_generateButton, new Label(": Generate new puzzle") { X = 6 });
    }

    Button CreateDifficultyButton(string name)
    {
        var difficultyButton = new Button(name);
        difficultyButton.Clicked += () => 
        { 
            Difficulty difficulty = 
                (Difficulty) Enum.Parse(typeof(Difficulty), name.ToUpper());
            _sudokuFrame.StartGame(difficulty);
            Add(_resetButton, new Label(": Reset game") { X = 6, Y = 1 });
            Application.RequestStop(); 
        };

        return difficultyButton;
    }

    private void InitializeFrameSettings()
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