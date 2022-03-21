using NUnit.Framework;

[TestFixture]
class PuzzlerTests : TestsSetup
{
    [Test]
    public void EasyDifficulty()
    {
        AssertDifficulty(Difficulty.EASY, 45);
    }

    [Test]
    public void MediumDifficulty()
    {
        AssertDifficulty(Difficulty.MEDIUM, 35);
    }

    [Test]
    public void HardDifficulty()
    {
        AssertDifficulty(Difficulty.HARD, 28);
    }

    void AssertDifficulty(Difficulty difficulty, int hintsCount)
    {
        _sudokuPuzzle = 
            _puzzler.GenerateSuDoKuPuzzle(_sudokuMatrix, difficulty);

        int emptySpaces = 0;
        for (int i = 0; i < _sudokuPuzzle.GetLength(0); i++)
            for (int j = 0; j < _sudokuPuzzle.GetLength(1); j++)
                if (_sudokuPuzzle[i, j] == 0)
                    emptySpaces++;
        
        Assert.AreEqual(81 - emptySpaces, hintsCount);
    }
}