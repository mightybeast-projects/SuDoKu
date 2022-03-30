class HintButton : MenuButton
{
    public HintButton(GUIGame game) 
        : base(game, "?", ": Give a hint")
    {
        button.Enabled = false;
    }
}