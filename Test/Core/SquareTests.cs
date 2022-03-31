using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
class SquareTests : TestsSetup
{
    [Test]
    public void BottomLeftSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 0));
    }

    [Test]
    public void AllSquaresAreTrulyRandom()
    {
        for (int i = 0; i < 9; i += 3)
            for (int j = 0; j < 9; j += 3)
                AssertSquareIsTrulyRandom(new Vector2(j, i));
    }

    void AssertSquareIsTrulyRandom(Vector2 squareOrigin)
    {
        int squareOriginX = (int)squareOrigin.X;
        int squareOriginY = (int)squareOrigin.Y;
        _numbersStorage = new List<int>();

        for (int i = squareOriginX; i < squareOriginX + 3; i++)
            for (int j = squareOriginY; j < squareOriginY + 3; j++)
                if (!_numbersStorage.Contains(_sudokuMatrix[i, j]))
                    _numbersStorage.Add(_sudokuMatrix[i, j]);

        Assert.AreEqual(9, _numbersStorage.Count);
    }
}