using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
class SquareTests : SetupTests
{
    [Test]
    public void NewMatrixBottomLeftSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 0));
    }

    [Test]
    public void NewMatrixCenterSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(3, 3));
    }

    [Test]
    public void NewMatrixTopRightSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(6, 6));
    }

    private void AssertSquareIsTrulyRandom(Vector2 squareOrigin)
    {
        int squareOriginX = (int) squareOrigin.X;
        int squareOriginY = (int) squareOrigin.Y;
        _validationStorage = new List<int>();

        for (int i = squareOriginX; i < squareOriginX + 3; i++)
            for (int j = squareOriginY; j < squareOriginY + 3; j++)
                if (!_validationStorage.Contains(_sudoku.matrix[i, j]))
                    _validationStorage.Add(_sudoku.matrix[i, j]);
        
        Assert.AreEqual(9, _validationStorage.Count);
    }
}