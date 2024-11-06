using KedeListe.Models;
using Xunit;

namespace KedeListe;

public class ChainListTest
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 })]
    public void CanAddIntegers(int[] data)
    {
        // Arrange
        ChainList<int> list = new();
        var dataCount = data.Count();

        // Act 
        for (int i = 0; i < dataCount; i++)
        {
            list.Add_First(data[i]);
        }

        // Assert
        Assert.Equal(data[0], list.First?.Data);
        Assert.Equal(dataCount, list.Count());
    }

    [Theory]
    [InlineData("1,2,3,4")]
    [InlineData("1,3,4")]
    [InlineData("sdasdasd,sadsd,ads")]
    public void CanAddStrings(string dataString)
    {
        // Arrange
        ChainList<string> list = new();
        var data = dataString.Split(',');
        var dataCount = data.Length;

        // Act 
        for (int i = 0; i < dataCount; i++)
        {
            list.Add_First(data[i].Trim());
        }

        // Assert
        Assert.Equal(data[0].Trim(), list.First?.Data);
        Assert.Equal(dataCount, list.Count());
    }


    [Theory]
    [InlineData(22)]
    [InlineData(68)]
    public void CanRemoveFirstElemt(int data)
    {
        // Arange
        ChainList<int> list = new();

        // Act 
        list.Remove_First();

        // Assert
        Assert.Null(list.First);
        Assert.Equal(0, list.Count());
    }
    
    
}