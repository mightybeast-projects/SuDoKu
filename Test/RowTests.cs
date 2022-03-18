using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class RowTests : TestsSetup
{
    [Test]
    public void FirstRowIsTrulyRandom()
    {
        AssertRowIsTrulyRandom(0);
    }

    [Test]
    public void AllRowsAreTrulyRandom()
    {
        for (int i = 0; i < 9; i++)
            AssertRowIsTrulyRandom(i);
    }

    private void AssertRowIsTrulyRandom(int row)
    {
        _numbersStorage = new List<int>();

        for (int i = 0; i < _sudokuMatrix.GetLength(0); i++)
            if (!_numbersStorage.Contains(_sudokuMatrix[i, row]))
                    _numbersStorage.Add(_sudokuMatrix[i, row]);

        Assert.AreEqual(9, _numbersStorage.Count);
    }
}