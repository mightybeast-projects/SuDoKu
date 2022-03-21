using Terminal.Gui;

class SuDoKuWindow : Window
{
    int[,] _sudokuPuzzle;
    int _iOffset = 0;
    int _jOffset = 0;

    public SuDoKuWindow() : base()
    {
        InitializeSuDoKuPuzzle();
        InitializeWindowSettings();
        InitializeSudokuMatrix();
    }

    void InitializeSuDoKuPuzzle()
    {
        SuDoKu sudoku = new SuDoKu();
        Puzzler puzzler = new Puzzler();
        int[,] sudokuMatrix = sudoku.GenerateSuDoKu();
        _sudokuPuzzle = 
            puzzler.GenerateSuDoKuPuzzle(sudokuMatrix, Difficulty.EASY);
    }

    void InitializeWindowSettings()
    {
        X = Pos.Center();
        Y = Pos.Center();
        Width = 33;
        Height = 15;
        Title = "SuDoKu";
        ColorScheme = Colors.Menu;
    }

    void InitializeSudokuMatrix()
    {
        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            AddSudokuMatrixRow(i);
    }

    private void AddSudokuMatrixRow(int i)
    {
        if (i % 3 == 0)
        {
            AddHorizontalSeparator(0, i + _iOffset);
            _iOffset++;
        }

        for (int j = 0; j < _sudokuPuzzle.GetLength(1); j++)
            AddSudokuMatrixCell(i, j);

        if (i == _sudokuPuzzle.GetLength(0) - 1)
            AddHorizontalSeparator(0, 9 + _iOffset);
    }

    private void AddSudokuMatrixCell(int i, int j)
    {
        if (j % 3 == 0)
        {
            AddVerticalSeparator(j + _jOffset + j * 2, i + _iOffset);
            _jOffset++;
        }

        AddSudokuMatrixEntry(i, j);

        if (j == _sudokuPuzzle.GetLength(1) - 1)
        {
            AddVerticalSeparator(9 + _jOffset + 18, i + _iOffset);
            _jOffset = 0;
        }
    }

    private void AddSudokuMatrixEntry(int i, int j)
    {
        AddReadOnlyTextField(" ", j + _jOffset + j * 2, i + _iOffset);
        AddNewSuDoKuTextField(i, j);
        AddReadOnlyTextField(" ", j + _jOffset + j * 2 + 2, i + _iOffset);
    }

    void AddHorizontalSeparator(int x, int y)
    {
        AddReadOnlyTextField("+---------+---------+---------+", x, y);
    }

    void AddVerticalSeparator(int x, int y)
    {
        AddReadOnlyTextField("|", x, y);
    }

    void AddReadOnlyTextField(string text, int x, int y)
    {
        var readOnlyField = new ReadOnlyTextField(text);
        readOnlyField.X = x;
        readOnlyField.Y = y;
        
        Add(readOnlyField);
    }

    void AddNewSuDoKuTextField(int i, int j)
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