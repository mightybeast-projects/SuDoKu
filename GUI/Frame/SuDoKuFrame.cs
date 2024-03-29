using System;
using Terminal.Gui;

class SuDoKuFrame : FrameView
{
    Difficulty _puzzleDifficulty;
    SuDoKuDrawer _sudokuDrawer;
    int[,] _fieldNumbers;
    int[,] _sudokuMatrix;
    int[,] _sudokuPuzzle;
    int[,] _sudokuPuzzleCopy;

    public SuDoKuFrame() : base()
    {
        InitializeFrameSettings();
    }

    public void InitializeSudokuPuzzle(Difficulty difficulty)
    {
        _puzzleDifficulty = difficulty;

        InstantiateSudokuPuzzle();
        _sudokuDrawer.DrawSudokuPuzzle(_sudokuPuzzle);
    }

    public void ResetSudokuPuzzle()
    {
        _sudokuPuzzle = _sudokuPuzzleCopy.Clone() as int[,];

        _sudokuDrawer.DrawSudokuPuzzle(_sudokuPuzzle);
    }

    public bool CheckSudokuPuzzle()
    {
        _fieldNumbers = _sudokuDrawer.GetFieldNumbers();

        return CompareFieldNumbersWithMatrix();
    }

    public void ShowHint()
    {
        if (!SudokuPuzzleHasEmptyField()) return;

        _sudokuPuzzle = _sudokuDrawer.GetFieldNumbers();
        ChooseAndShowRandomHint();
        _sudokuDrawer.DrawSudokuPuzzle(_sudokuPuzzle);
    }

    void InitializeFrameSettings()
    {
        _sudokuDrawer = new SuDoKuDrawer();

        Y = Pos.Center();
        Width = 33;
        Height = 15;
        Title = "SuDoKu";
        ColorScheme = Colors.Menu;

        Add(_sudokuDrawer);
    }

    void InstantiateSudokuPuzzle()
    {
        SuDoKu sudoku = new SuDoKu();
        Puzzler puzzler = new Puzzler();
        _sudokuMatrix = sudoku.GenerateSuDoKu();
        _sudokuPuzzle =
            puzzler.GenerateSuDoKuPuzzle(_sudokuMatrix, _puzzleDifficulty);
        _sudokuPuzzleCopy = _sudokuPuzzle.Clone() as int[,];
    }

    bool SudokuPuzzleHasEmptyField()
    {
        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            for (int j = 0; j < _sudokuPuzzle.GetLength(1); j++)
                if (_sudokuPuzzle[j, i] == 0)
                    return true;
        return false;
    }

    bool CompareFieldNumbersWithMatrix()
    {
        for (int i = 0; i < _sudokuMatrix.GetLength(0); i++)
            for (int j = 0; j < _sudokuMatrix.GetLength(1); j++)
                if (_fieldNumbers[j, i] != _sudokuMatrix[j, i])
                    return false;
        return true;
    }

    void ChooseAndShowRandomHint()
    {
        Random rnd = new Random();
        int i, j;
        while (true)
        {
            i = rnd.Next(9);
            j = rnd.Next(9);
            if (_sudokuPuzzle[j, i] == 0 ||
                _sudokuPuzzle[j, i] != _sudokuMatrix[j, i]) break;
        }

        _sudokuPuzzle[j, i] = _sudokuMatrix[j, i];
    }
}