using System;
using Terminal.Gui;

class SuDoKuDrawer : View
{
    public TextField[,] sudokuFields;

    int[,] _fieldNumbers;
    int[,] _sudokuPuzzle;
    int _iOffset = 0;
    int _jOffset = 0;

    public SuDoKuDrawer() : base()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();
    }

    public void DrawSudokuPuzzle(int[,] sudokuPuzzle)
    {
        sudokuFields = new TextField[9, 9];
        RemoveAll();

        _sudokuPuzzle = sudokuPuzzle;
        _iOffset = 0;

        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            DrawSudokuPuzzleRow(i);
    }

    public int[,] GetFieldNumbers()
    {
        _fieldNumbers = new int[9, 9];

        for (int i = 0; i < sudokuFields.GetLength(0); i++)
            for (int j = 0; j < sudokuFields.GetLength(1); j++)
                GetFieldNumber(i, j);

        return _fieldNumbers;
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
            sudokuNumberField
                = new ReadOnlyTextField(sudokuNumber.ToString());

        sudokuNumberField.X = j + _jOffset + j * 2 + 1;
        sudokuNumberField.Y = i + _iOffset;

        sudokuFields[i, j] = sudokuNumberField;
        Add(sudokuNumberField);
    }

    void GetFieldNumber(int i, int j)
    {
        string fieldText = sudokuFields[i, j].Text.ToString();
        if (fieldText == ".") fieldText = "0";
        int fieldNumber = Int32.Parse(fieldText);
        _fieldNumbers[j, i] = fieldNumber;
    }
}