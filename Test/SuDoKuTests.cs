using System.Numerics;
using NUnit.Framework;

[TestFixture]
class SuDoKuTests
{
    private SuDoKu _sudoku;
    private int[,] centerSquare;

    [SetUp]
    public void Setup()
    {
        _sudoku = new SuDoKu(1);
        _sudoku.Generate();
    }

    [Test]
    public void NewMatrixIsNotNull()
    {
        Assert.NotNull(_sudoku.matrix);
    }

    [Test]
    public void NewMatrixBottomLeftSquareIsTrulyRandom()
    {
        centerSquare = new int[3, 3] 
        {
            {5, 4, 8},
            {1, 6, 2},
            {3, 7, 9}
        };

        AssertSquaresAreEqual(centerSquare, new Vector2(0, 0));
    }

    [Test]
    public void NewMatrixCenterSquareIsTrulyRandom()
    {
        centerSquare = new int[3, 3] 
        {
            {3, 1, 4},
            {8, 7, 5},
            {2, 6, 9}
        };

        AssertSquaresAreEqual(centerSquare, new Vector2(3, 3));
    }

    [Test]
    public void NewMatrixTopRightSquareIsTrulyRandom()
    {
        centerSquare = new int[3, 3] 
        {
            {5, 9, 8},
            {7, 2, 6},
            {4, 3, 1}
        };

        AssertSquaresAreEqual(centerSquare, new Vector2(6, 6));
    }

    private void AssertSquaresAreEqual(
        int [,] square,
        Vector2 matrixSquareOrigin)
    {
        int matrixSquareOriginX = (int) matrixSquareOrigin.X;
        int matrixSquareOriginY = (int) matrixSquareOrigin.Y;

        for (int i = 0; i < square.GetLength(0); i++)
            for (int j = 0; j < square.GetLength(1); j++)
                Assert.AreEqual(square[square.GetLength(0) - 1 - j, i], 
                        _sudoku.matrix[i + matrixSquareOriginX, 
                                        j + matrixSquareOriginY]);
    }
}

/*
0  0  0  0  0  0  5  9  8 
0  0  0  0  0  0  7  2  6 
0  0  0  0  0  0  4  3  1 
0  0  0  3  1  4  0  0  0 
0  0  0  8  7  5  0  0  0 
0  0  0  2  6  9  0  0  0 
5  4  8  0  0  0  0  0  0 
1  6  2  0  0  0  0  0  0 
3  7  9  0  0  0  0  0  0
*/