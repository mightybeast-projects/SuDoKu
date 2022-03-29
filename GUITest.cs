using Terminal.Gui;

class GUITest
{
    SuDoKuFrame _sudokuFrame;
    MenuFrame _menuFrame;

    public void Init()
    {
        Application.Init();
        
        _sudokuFrame = new SuDoKuFrame();
        _menuFrame = new MenuFrame(_sudokuFrame);

        Application.Top.Add(_sudokuFrame, _menuFrame);

        Application.Run();
    }
}