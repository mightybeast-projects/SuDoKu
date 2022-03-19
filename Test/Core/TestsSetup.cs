using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
class TestsSetup
{
    protected SuDoKu _sudoku;
    protected Puzzler _puzzler;
    protected List<int> _numbersStorage;
    protected int[,] _sudokuMatrix;
    protected int[,] _sudokuPuzzle;

    [SetUp]
    protected void Setup()
    {
        _sudoku = new SuDoKu();
        _puzzler = new Puzzler();
        _sudokuMatrix = _sudoku.GenerateMatrix();
    }
}