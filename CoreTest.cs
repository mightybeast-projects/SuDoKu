using System;

class CoreTest
{
    SuDoKu _sudoku;
    Puzzler _puzzler;
    int[,] _sudokuMatrix;

    public void Init()
    {
        _sudoku = new SuDoKu();
        _sudokuMatrix = _sudoku.GenerateSuDoKu();
        PrintMatrix(_sudokuMatrix);

        _puzzler = new Puzzler();
        _sudokuMatrix = 
            _puzzler.GenerateSuDoKuPuzzle(_sudokuMatrix, Difficulty.EASY);
        PrintMatrix(_sudokuMatrix);
    }

    void PrintMatrix(int[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            if (i % 3 == 2)
                Console.WriteLine("+---------+---------+---------+");

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j % 3 == 0) Console.Write("|");
                if (matrix[j, i] != 0)
                    Console.Write(" " + matrix[j, i] + " ");
                else
                    Console.Write(" . ");
            }
            
            Console.WriteLine("|");
        }
        Console.WriteLine("+---------+---------+---------+");
    }

    void PrintRow(int[,] matrix, int rowIndex)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
            Console.Write(" " + matrix[i, rowIndex] + " ");
        Console.WriteLine();
    }

    void PrintCol(int[,] matrix, int colIndex)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(1); i++)
            Console.Write(" " + matrix[colIndex, i] + " ");
        Console.WriteLine();
    }
}