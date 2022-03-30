class HintButton : MenuButton
{
    public HintButton(GUIGame game) 
        : base(game, "H", ": Give a hint")
    {
        button.Clicked += () => game.GiveAHint();
        button.Enabled = false;
    }
}