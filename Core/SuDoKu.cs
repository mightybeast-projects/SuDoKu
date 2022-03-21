using System;

class SuDoKu
{
    Random _rnd = new Random();
    int[,] _matrix;
    int _currentNumber;

    public int[,] GenerateSuDoKu()
    {
        _matrix = new int[9, 9];

        for (int i = 0; i < 9; i += 3)
            FillDiagonalSquare(i, i);

        FillEmptySpace(0, 0);

        return _matrix;
    }

    void FillDiagonalSquare(int row, int col)
    {
        for (int i = row; i < row + 3; i++)
            for (int j = col; j < col + 3; j++)
                FillNumber(i, j);
    }

    void FillNumber(int i, int j)
    {
        while (true)
        {
            _currentNumber = _rnd.Next(1, 10);

            if (SquareDoNotContainCurrentNumber(i, j))
                break;
        }

        _matrix[i, j] = _currentNumber;
    }

    bool FillEmptySpace(int row, int col)
    {
        if (row == 8 && col == 9)
            return true;

        if (col == 9)
        {
            row++;
            col = 0;
        }

        if (_matrix[row, col] != 0)
            return FillEmptySpace(row, col + 1);

        for (int num = 1; num < 10; num++)
        {
            _currentNumber = num;
            if (CurrentNumberIsSafeToFill(row, col))
            {
                _matrix[row, col] = num;

                if (FillEmptySpace(row, col + 1))
                    return true;
            }
            _matrix[row, col] = 0;
        }
        return false;
    }

    bool CurrentNumberIsSafeToFill(int i, int j)
    {
        return SquareDoNotContainCurrentNumber(i, j) &&
                RowDoNotContainCurrentNumber(j) &&
                ColDoNotContainCurrentNumber(i);
    }

    bool SquareDoNotContainCurrentNumber(int row, int col)
    {
        int startRow = row - row % 3;
        int startCol = col - col % 3;

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (_matrix[i + startRow, j + startCol] == _currentNumber)
                    return false;
        return true;
    }

    bool RowDoNotContainCurrentNumber(int row)
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
            if (_matrix[i, row] == _currentNumber)
                return false;
        return true;
    }

    bool ColDoNotContainCurrentNumber(int col)
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
            if (_matrix[col, i] == _currentNumber)
                return false;
        return true;
    }
}