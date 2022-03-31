using Terminal.Gui;

class GUIGame
{
    SuDoKuFrame _sudokuFrame;
    MenuFrame _menuFrame;

    public void Init()
    {
        Application.Init();
        
        _sudokuFrame = new SuDoKuFrame();
        _menuFrame = new MenuFrame(this);

        Application.Top.Add(_sudokuFrame, _menuFrame);

        Application.Run();
    }

    public void StartGame(Difficulty difficulty)
    {
        _sudokuFrame.InitializeSudokuPuzzle(difficulty);
        _menuFrame.EnablePuzzleButtons();
    }

    public void ResetGame()
    {
        _sudokuFrame.ResetSudokuPuzzle();
    }

    public bool CheckSudoku()
    {
        return _sudokuFrame.CheckSudokuPuzzle();
    }

    public void GiveAHint()
    {
        _sudokuFrame.ShowHint();
    }
}