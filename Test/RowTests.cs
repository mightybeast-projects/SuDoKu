using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class RowTests: TestsSetup
{
    [Test]
    public void FirstRowIsTrulyRandom()
    {
        _validationStorage = new List<int>();

        for (int i = 0; i < _sudoku.matrix.GetLength(0); i++)
            if (!_validationStorage.Contains(_sudoku.matrix[i, 0]))
                    _validationStorage.Add(_sudoku.matrix[i, 0]);

        Assert.AreEqual(9, _validationStorage.Count);
    }

    [Test]
    public void SecondRowIsTrulyRandom()
    {
        _validationStorage = new List<int>();

        for (int i = 0; i < _sudoku.matrix.GetLength(0); i++)
            if (!_validationStorage.Contains(_sudoku.matrix[i, 1]))
                    _validationStorage.Add(_sudoku.matrix[i, 1]);

        Assert.AreEqual(9, _validationStorage.Count);
    }
}