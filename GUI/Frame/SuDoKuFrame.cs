using System.Diagnostics;
using System;
using Terminal.Gui;

class SuDoKuFrame : FrameView
{
    Difficulty _puzzleDifficulty;
    int[,] _sudokuMatrix;
    int[,] _sudokuPuzzle;
    int[,] _sudokuPuzzleCopy;
    int _iOffset = 0;
    int _jOffset = 0;

    public SuDoKuFrame() : base()
    {
        InitializeFrameSettings();
    }

    public void InitializeSudokuPuzzle(Difficulty difficulty)
    {
        _puzzleDifficulty = difficulty;

        InstantiateSudokuPuzzle();
        DrawSudokuPuzzle();
    }

    public void ResetSudokuPuzzle()
    {
        _sudokuPuzzle = _sudokuPuzzleCopy.Clone() as int[,];

        DrawSudokuPuzzle();
    }

    public void ShowHint()
    {
        if (!SudokuPuzzleHasEmptyField()) return;

        Random rnd = new Random();
        int i, j;
        while(true)
        {
            i = rnd.Next(9);
            j = rnd.Next(9);
            if (_sudokuPuzzle[j, i] == 0) break;
        }

        _sudokuPuzzle[j, i] = _sudokuMatrix[j, i];

        DrawSudokuPuzzle();
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

    void InitializeFrameSettings()
    {
        Y = Pos.Center();
        Width = 33;
        Height = 15;
        Title = "SuDoKu";
        ColorScheme = Colors.Menu;
    }

    void DrawSudokuPuzzle()
    {
        RemoveAll();
        _iOffset = 0;

        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            DrawSudokuPuzzleRow(i);
    }

    void DrawSudokuPuzzleRow(int i)
    {
        if (i % 3 == 0)
        {
            DrawHorizontalSeparator(0, i + _iOffset);
            _iOffset++;
        }

        for (int j = 0; j < _sudokuPuzzle.GetLength(1); j++)
            DrawSudokuPuzzleCell(i, j);

        if (i == _sudokuPuzzle.GetLength(0) - 1)
            DrawHorizontalSeparator(0, 9 + _iOffset);
    }

    void DrawSudokuPuzzleCell(int i, int j)
    {
        if (j % 3 == 0)
        {
            DrawVerticalSeparator(j + _jOffset + j * 2, i + _iOffset);
            _jOffset++;
        }

        DrawSudokuPuzzleEntry(i, j);

        if (j == _sudokuPuzzle.GetLength(1) - 1)
        {
            DrawVerticalSeparator(9 + _jOffset + 18, i + _iOffset);
            _jOffset = 0;
        }
    }

    void DrawSudokuPuzzleEntry(int i, int j)
    {
        DrawReadOnlyTextField(" ", j + _jOffset + j * 2, i + _iOffset);
        DrawNewSuDoKuTextField(i, j);
        DrawReadOnlyTextField(" ", j + _jOffset + j * 2 + 2, i + _iOffset);
    }

    void DrawHorizontalSeparator(int x, int y)
    {
        DrawReadOnlyTextField("+---------+---------+---------+", x, y);
    }

    void DrawVerticalSeparator(int x, int y)
    {
        DrawReadOnlyTextField("|", x, y);
    }

    void DrawReadOnlyTextField(string text, int x, int y)
    {
        var readOnlyField = new ReadOnlyTextField(text);
        readOnlyField.X = x;
        readOnlyField.Y = y;
        
        Add(readOnlyField);
    }

    void DrawNewSuDoKuTextField(int i, int j)
    {
        int sudokuNumber = _sudokuPuzzle[j, i];
        var sudokuNumberField = new TextField();

        if (sudokuNumber == 0)
            sudokuNumberField = new SuDoKuTextField(".");
        else
            sudokuNumberField = new ReadOnlyTextField(sudokuNumber.ToString());

        sudokuNumberField.X = j + _jOffset + j * 2 + 1;
        sudokuNumberField.Y = i + _iOffset;

        Add(sudokuNumberField);
    }

    bool SudokuPuzzleHasEmptyField()
    {
        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            for (int j = 0; j < _sudokuPuzzle.GetLength(1); j++)
                if (_sudokuPuzzle[j, i] == 0) 
                    return true;
        return false;
    }
}