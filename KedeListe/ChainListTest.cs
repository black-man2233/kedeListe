using KedeListe.Models;
using Microsoft.VisualBasic.CompilerServices;
using Xunit;

namespace KedeListe.Models;

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
            list.Add(data[i]);
        }

        // Assert
        Assert.Equal(data[0], list.First?.Data);
        Assert.Equal(dataCount, list.Count());
    }

    [Theory]
    [InlineData("1,2,3,4,s")]
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
            list.Add(data[i].Trim());
        }

        // Assert
        Assert.Equal(data[0].Trim(), list.First?.Data);
        Assert.Equal(dataCount, list.Count());
    }

    [Theory]
    [InlineData(22)]
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

    [Theory]
    [InlineData("sdasdasd,sadsd,ads")]
    public void CanSortStrings(string data)
    {
        // Arrange
        List<string> dataList = data.Split(',').ToList();
        var dataCount = dataList.Count();
        ChainList<string> list = new();

        for (int i = 0; i < dataCount; i++)
            list.Add(dataList[i]);

        // Acts
        list.Sort();

        // Assert
        var a = list.To_String();
    }

    [Theory]
    [InlineData(new int[] { 3242143, 4, 4, 1, 456345 })]
    public void ListCountUpdates(int[] data)
    {
        // Arrange
        Int16 elemtCounter = 0;
        Int32 givenDataCount = data.Count();
        ChainList<int> chainList = new();
        for (int i = 0; i < data.Count(); i++)
        {
            chainList.Add_First(data[i]);
        }

        Element<int>? currentElemt = chainList.First;

        // Act
        while (currentElemt != null)
        {
            elemtCounter++;
            currentElemt = currentElemt.Next;
        }

        // Assert
        Assert.Equal(givenDataCount, chainList.Count());
        Assert.Equal(givenDataCount, elemtCounter);
        Assert.Equal(chainList.Count(), elemtCounter);
    }

    [Theory]
    [InlineData(new int[] { 3242143, 2323 })]
    public void CanCallToString(int[] data)
    {
        // Arrange
        ChainList<int> chainList = new();
        for (int i = 0; i < data.Count(); i++)
        {
            chainList.Add(data[i]);
        }

        var expectedResult = string.Join(" | ", data);

        // Act
        var result = chainList.To_String();

        // Assert
        Assert.Equal(result, expectedResult);
    }


    [Theory]
    [InlineData(new int[] { 3242143, 2323 })]
    public void CanCompareIntegers(int[] data)
    {
        // Arrange
        ChainList<int> chainList = new();
        var expectedValue = 2323;
        for (int i = 0; i < data.Count(); i++)
        {
            chainList.Add(data[i]);
        }

        // Act
        var result = chainList.Compare(expectedValue, (int)(chainList.First?.Next?.Data));

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("3242143, 2323")]
    public void CanCompareString(string dataString)
    {
        // Arrange
        ChainList<string> chainList = new();
        var data = dataString.Split(',');
        var dataCount = data.Length;

        // Act 
        for (int i = 0; i < dataCount; i++)
        {
            chainList.Add(data[i].Trim());
        }

        var expectedValue = "2323";

        // Act
        var result = chainList.Compare(expectedValue, (string)(chainList.First?.Next?.Data));

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("3242143, 2323, 2323,1,213,1241,24")]
    public void CanAddFirst(string dataString)
    {
        // Arrange
        ChainList<string> chainList = new();
        var data = dataString.Split(',');
        var dataCount = data.Length;
        string expectedValue = data.Last();

        // Act 
        for (int i = 0; i < dataCount; i++)
        {
            chainList.Add_First(data[i].Trim());
        }

        // Assert
        Assert.Equal(expectedValue, chainList.First.Data);
    }
}