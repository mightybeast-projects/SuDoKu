using Terminal.Gui;

class MenuListView : View
{
    int currentY;

    public MenuListView() : base()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();
    }

    public void Add(MenuButton menuButton)
    {
        menuButton.Y = currentY++;
        base.Add(menuButton);
    }
}