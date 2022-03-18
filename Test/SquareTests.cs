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
    public void BottomCenterSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 3));
    }

    [Test]
    public void BottomRightSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 6));
    }

    [Test]
    public void MiddleLeftSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 3));
    }

    [Test]
    public void CenterSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(3, 3));
    }

    [Test]
    public void MiddleRightSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 6));
    }

    [Test]
    public void TopLeftSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(0, 6));
    }

    [Test]
    public void TopCenterSquareIsTrulyRandom()
    {
        AssertSquareIsTrulyRandom(new Vector2(3, 6));
    }

    [Test]
    public void TopRightSquareIsTrulyRandom()
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