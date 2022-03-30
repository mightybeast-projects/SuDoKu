using System;
using Terminal.Gui;

class GenerateButton : MenuButton
{
    public GenerateButton(GUIGame game) 
        : base(game, "G", ": Generate new SuDoKu")
    {
        button.Clicked += ShowGenerateDialog();
    }

    Action ShowGenerateDialog()
    {
        return () =>
        {
            var dialog = new Dialog("Choose puzzle difficulty");
            dialog.Width = 50;
            dialog.Height = 4;
            dialog.AddButton(CreateDifficultyButton("Easy"));
            dialog.AddButton(CreateDifficultyButton("Medium"));
            dialog.AddButton(CreateDifficultyButton("Hard"));
            Application.Run(dialog);
        };
    }

    Button CreateDifficultyButton(string name)
    {
        var difficultyButton = new Button(name);
        difficultyButton.Clicked += () =>
        {
            Difficulty difficulty =
                (Difficulty)Enum.Parse(typeof(Difficulty), name.ToUpper());
            _game.StartGame(difficulty);
            Application.RequestStop();
        };

        return difficultyButton;
    }
}