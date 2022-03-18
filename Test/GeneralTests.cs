using NUnit.Framework;

[TestFixture]
class GeneralTests : TestsSetup
{
    [Test]
    public void NewMatrixIsNotNull()
    {
        Assert.NotNull(_sudokuMatrix);
    }
}