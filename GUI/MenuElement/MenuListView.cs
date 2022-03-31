using Terminal.Gui;

class MenuListView : View
{
    int currentY;

    public MenuListView() : base()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();
    }

    public new void Add(View menuElement)
    {
        menuElement.Y = currentY++;
        base.Add(menuElement);
    }
}