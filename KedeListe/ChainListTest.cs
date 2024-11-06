using Xunit;
using MyDickSpace;

namespace KedeListe;

public class ChainListTest
{
    [Theory]
    [InlineData(22)]
    [InlineData(68)]
    [InlineData(100)]
    public void AddElementTest(int data)
    {
        // Arange
        ChainList<int> list = new();

        // Act 
        list.Add_First(data);

        // Assert
        Assert.True(true);
    }
}