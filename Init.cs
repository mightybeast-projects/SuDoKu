using System;

class Init
{
    static SuDoKu _sudoku;

    static void Main()
    {
        _sudoku = new SuDoKu();
        _sudoku.Generate();
        PrintMatrix(_sudoku.matrix);
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
                Console.Write(" " + matrix[j, i] + " ");
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