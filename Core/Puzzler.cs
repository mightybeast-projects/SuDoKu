using System.Collections.Generic;
using System;

enum Difficulty { EASY, MEDIUM, HARD }

class Puzzler
{
    Random _rnd = new Random();
    Dictionary<Difficulty, int> _difficultyHints 
        = new Dictionary<Difficulty, int>()
    {
        { Difficulty.EASY, 45 },
        { Difficulty.MEDIUM, 35 },
        { Difficulty.HARD, 28 }
    };
    int[,] _sudokuMatrix;

    public int[,] GenerateSuDoKuPuzzle(int[,] sudokuMatrix, 
        Difficulty difficulty)
    {
        _sudokuMatrix = sudokuMatrix;
        int numbersToRemove = 81 - _difficultyHints[difficulty];

        for (int k = 0; k < numbersToRemove; k++)
            RemoveRandomNumber();

        return _sudokuMatrix;
    }

    void RemoveRandomNumber()
    {
        int i = _rnd.Next(0, 9);
        int j = _rnd.Next(0, 9);

        if (_sudokuMatrix[i, j] != 0)
            _sudokuMatrix[i, j] = 0;
        else RemoveRandomNumber();
    }
}