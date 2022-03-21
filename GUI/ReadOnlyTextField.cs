using Terminal.Gui;

class ReadOnlyTextField : TextField
{
    public ReadOnlyTextField(string str) : base(str)
    {
        ReadOnly = true;
    }
}