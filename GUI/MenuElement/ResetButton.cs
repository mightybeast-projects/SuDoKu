class ResetButton : MenuButton
{
    public ResetButton(GUIGame game) 
        : base(game, "R", ": Reset SuDoKu")
    {
        button.Clicked += () => game.ResetGame();
        button.Enabled = false;
    }
}