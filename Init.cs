using System;

class Init
{
    static SuDoKu _sudoku;
    static Puzzler _puzzler;
    static int[,] _sudokuMatrix;

    static void Main()
    {
        _sudoku = new SuDoKu();
        _sudokuMatrix = _sudoku.GenerateMatrix();
        PrintMatrix(_sudokuMatrix);

        _puzzler = new Puzzler();
        _sudokuMatrix = 
            _puzzler.CreateNewSudokuPuzzle(_sudokuMatrix, Difficulty.EASY);
        PrintMatrix(_sudokuMatrix);
    }

    static void PrintMatrix(int[,] matrix)
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

    static void PrintRow(int[,] matrix, int rowIndex)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
            Console.Write(" " + matrix[i, rowIndex] + " ");
        Console.WriteLine();
    }

    static void PrintCol(int[,] matrix, int colIndex)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(1); i++)
            Console.Write(" " + matrix[colIndex, i] + " ");
        Console.WriteLine();
    }
}