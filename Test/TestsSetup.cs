using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
class TestsSetup
{
    protected SuDoKu _sudoku;
    protected List<int> _validationStorage;

    [SetUp]
    protected void Setup()
    {
        _sudoku = new SuDoKu();
        _sudoku.Generate();
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