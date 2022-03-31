using System.Collections.Generic;
using System;

enum Difficulty { EASY, MEDIUM, HARD }

class Puzzler
{
    Dictionary<Difficulty, int> _difficultyHints
        = new Dictionary<Difficulty, int>()
    {
        { Difficulty.EASY, 45 },
        { Difficulty.MEDIUM, 35 },
        { Difficulty.HARD, 28 }
    };
    Random _rnd = new Random();
    int[,] _sudokuMatrix = new int[9, 9];

    public int[,] GenerateSuDoKuPuzzle(int[,] sudokuMatrix, 
        Difficulty difficulty)
    {
        _sudokuMatrix = sudokuMatrix.Clone() as int[,];

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