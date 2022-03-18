using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class ColTests : TestsSetup
{
    [Test]
    public void FirstColIsTrulyRandom()
    {
        AssertColIsTrulyRandom(0);
    }

    [Test]
    public void AllColsAreTrulyRandom()
    {
        for (int i = 0; i < 9; i++)
            AssertColIsTrulyRandom(i);
    }

    private void AssertColIsTrulyRandom(int col)
    {
        _numbersStorage = new List<int>();

        for (int i = 0; i < _sudokuMatrix.GetLength(0); i++)
            if (!_numbersStorage.Contains(_sudokuMatrix[col, i]))
                    _numbersStorage.Add(_sudokuMatrix[col, i]);

        Assert.AreEqual(9, _numbersStorage.Count);
    }
}