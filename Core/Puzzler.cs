using System.Collections.Generic;
using System;

class Puzzler
{
    private Random _rnd = new Random();
    private Dictionary<Difficulty, int> _difficultyHints 
        = new Dictionary<Difficulty, int>()
        {
            { Difficulty.EASY, 45 },
            { Difficulty.MEDIUM, 35 },
            { Difficulty.HARD, 28 }
        };
    private int[,] _sudokuMatrix;

    public int[,] CreateNewSudokuPuzzle(int[,] sudokuMatrix, 
        Difficulty difficulty)
    {
        _sudokuMatrix = sudokuMatrix;
        int numbersToRemove = 81 - _difficultyHints[difficulty];

        for (int k = 0; k < numbersToRemove; k++)
            RemoveRandomNumber();

        return _sudokuMatrix;
    }

    private void RemoveRandomNumber()
    {
        int i = _rnd.Next(0, 9);
        int j = _rnd.Next(0, 9);

        if (_sudokuMatrix[i, j] != 0)
            _sudokuMatrix[i, j] = 0;
        else RemoveRandomNumber();
    }
}