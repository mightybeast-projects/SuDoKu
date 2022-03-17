using System.Numerics;
using System;
class SuDoKu
{
    public int[,] matrix;

    private Random _rnd;

    public SuDoKu() {}

    public SuDoKu(int rndSeed)
    {
        _rnd = new Random(rndSeed);
    }

    public void Generate()
    {
        matrix = new int[9, 9];

        Vector2 squareOrigin;
        squareOrigin = new Vector2(0, 0);
        FillSquare(squareOrigin);
        squareOrigin = new Vector2(3, 3);
        FillSquare(squareOrigin);
        squareOrigin = new Vector2(6, 6);
        FillSquare(squareOrigin);
    }

    private void FillSquare(Vector2 squareOrigin)
    {
        int squareOriginX = (int) squareOrigin.X;
        int squareOriginY = (int) squareOrigin.Y;

        for (int i = squareOriginX; i < squareOriginX + 3; i++)
            for (int j = squareOriginY; j < squareOriginY + 3; j++)
                FillNumber(squareOrigin, i, j);
    }

    private void FillNumber(Vector2 squareOrigin, int i, int j)
    {
        int rndNumber;
        while (true)
        {
            rndNumber = _rnd.Next(1, 10);
            if (!SquareContainsNumber(squareOrigin, rndNumber))
                break;
        }
        matrix[i, j] = rndNumber;
    }

    private bool SquareContainsNumber(Vector2 squareOrigin, int number)
    {
        int squareOriginX = (int) squareOrigin.X;
        int squareOriginY = (int) squareOrigin.Y;

        for (int i = squareOriginX; i < squareOriginX + 3; i++)
            for (int j = squareOriginY; j < squareOriginY + 3; j++)
                if (matrix[i, j] == number)
                    return true;
        return false;
    }
}