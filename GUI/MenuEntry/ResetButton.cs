class ResetButton : MenuButton
{
    public ResetButton(GUIGame game) 
        : base(game, "R", ": Reset game")
    {
        button.Y = 1;
        button.Clicked += () => game.ResetGame();
        button.Enabled = false;

        label.Y = 1;
    }
}