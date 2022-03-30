class CheckButton : MenuButton
{
    public CheckButton(GUIGame game) 
        : base(game, "C", ": Check SuDoKu")
    {
        button.Enabled = false;
    }
}