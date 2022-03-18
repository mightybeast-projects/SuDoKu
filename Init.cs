using System;

class Init
{
    static SuDoKu _sudoku;

    static void Main()
    {
        _sudoku.Generate();
        PrintMatrix(_sudoku.matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(" " + matrix[j, i] + " ");
            Console.WriteLine();
        }
    }
}