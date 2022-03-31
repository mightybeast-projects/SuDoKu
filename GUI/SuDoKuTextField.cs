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
        if (FieldRequiresReset()) Text = ".";
        return base.OnLeave(view);
    }

    bool TextIsNotANumber()
    {
        return !Regex.IsMatch(Text.ToString(), @"^\d+$");
    }

    bool FieldRequiresReset()
    {
        return Text == "" || Text.Length > 1 || TextIsNotANumber();
    }
}