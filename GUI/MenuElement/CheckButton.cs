using Terminal.Gui;

class CheckButton : MenuButton
{
    public CheckButton(GUIGame game)
        : base(game, "C", ": Check SuDoKu")
    {
        button.Clicked += () => ShowCheckResultMessage();
        button.Enabled = false;
    }

    void ShowCheckResultMessage()
    {
        if (_game.CheckSudoku())
            MessageBox.Query(50, 5, "Result",
                "SuDoKu is CORRECT!", "Okay");
        else
            MessageBox.ErrorQuery(50, 5, "Result",
                "SuDoKu is WRONG or NOT FULLY FILLED!", "Okay");
    }
}