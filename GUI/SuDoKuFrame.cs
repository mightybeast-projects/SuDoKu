using Terminal.Gui;

class SuDoKuFrame : FrameView
{
    Difficulty _puzzleDifficulty;
    int[,] _sudokuPuzzle;
    int _iOffset = 0;
    int _jOffset = 0;

    public SuDoKuFrame() : base()
    {
        InitializeFrameSettings();
    }

    public void StartGame(Difficulty difficulty)
    {
        _puzzleDifficulty = difficulty;

        InitializeSuDoKuPuzzle();
        DrawSudokuMatrix();
    }

    public void ResetGame()
    {
        DrawSudokuMatrix();
    }

    void InitializeSuDoKuPuzzle()
    {
        SuDoKu sudoku = new SuDoKu();
        Puzzler puzzler = new Puzzler();
        int[,] sudokuMatrix = sudoku.GenerateSuDoKu();
        _sudokuPuzzle = 
            puzzler.GenerateSuDoKuPuzzle(sudokuMatrix, _puzzleDifficulty);
    }

    void InitializeFrameSettings()
    {
        Y = Pos.Center();
        Width = 33;
        Height = 15;
        Title = "SuDoKu";
        ColorScheme = Colors.Menu;
    }

    void DrawSudokuMatrix()
    {
        RemoveAll();
        _iOffset = 0;

        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            DrawSudokuMatrixRow(i);
    }

    private void DrawSudokuMatrixRow(int i)
    {
        if (i % 3 == 0)
        {
            DrawHorizontalSeparator(0, i + _iOffset);
            _iOffset++;
        }

        for (int j = 0; j < _sudokuPuzzle.GetLength(1); j++)
            DrawSudokuMatrixCell(i, j);

        if (i == _sudokuPuzzle.GetLength(0) - 1)
            DrawHorizontalSeparator(0, 9 + _iOffset);
    }

    private void DrawSudokuMatrixCell(int i, int j)
    {
        if (j % 3 == 0)
        {
            DrawVerticalSeparator(j + _jOffset + j * 2, i + _iOffset);
            _jOffset++;
        }

        DrawSudokuMatrixEntry(i, j);

        if (j == _sudokuPuzzle.GetLength(1) - 1)
        {
            DrawVerticalSeparator(9 + _jOffset + 18, i + _iOffset);
            _jOffset = 0;
        }
    }

    private void DrawSudokuMatrixEntry(int i, int j)
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
}