using System.Text.RegularExpressions;
using Terminal.Gui;

class SuDoKuTextField : TextField
{
    public SuDoKuTextField(string text) : base(text) { }

    public override bool OnEnter(View view)
    {
        Text = "";
        return base.OnEnter(view);
    }

    public override bool OnLeave(View view)
    {
        if (Text == "" || TextIsNotANumber()) Text = ".";
        return base.OnLeave(view);
    }

    bool TextIsNotANumber()
    {
        return !Regex.IsMatch(Text.ToString(), @"^\d+$");
    }
}