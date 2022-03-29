class CheckButton : MenuButton
{
    public CheckButton(GUIGame game) 
        : base(game, "C", ": Check SuDoKu")
    {
        button.Y = 2;
        button.Enabled = false;
        label.Y = 2;
    }
}