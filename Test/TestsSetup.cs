using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class TestsSetup
{
    protected SuDoKu _sudoku;
    protected List<int> _numbersStorage;
    protected int[,] _sudokuMatrix;

    [SetUp]
    protected void Setup()
    {
        _sudoku = new SuDoKu();
        _sudokuMatrix = _sudoku.Generate();
    }
}