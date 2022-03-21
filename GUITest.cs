using Terminal.Gui;

class GUITest
{
    public void Init()
    {
        Application.Init();
        Application.Top.Add(new SuDoKuWindow());
        Application.Run();
    }
}