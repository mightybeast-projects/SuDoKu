class ResetButton : MenuButton
{
    public ResetButton(GUIGame game) 
        : base(game, "R", ": Reset game")
    {
        button.Clicked += () => game.ResetGame();
        button.Enabled = false;
    }
}