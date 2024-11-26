using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace SortingAlgorithms.Tests
{
  public class AlgorithmsTests
  {
    private IList<int> _unsortedValuesOriginal;
    private IList<int> _sortedValuesOriginal;

    private IList<int> _unsortedValues;
    private IList<int> _sortedValues;

    private List<Action<IList<int>>> _algorithms;

    #region SetUp and TearDown

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
      // Setting up cache values
      int min = 0;
      int max = 10;
      _sortedValuesOriginal = Enumerable.Range(min, max).ToList();

      System.Random random = new();
      _unsortedValuesOriginal = Enumerable.Range(min, max)
                                 .Select(_ => random.Next(min, max + 1))
                                 .ToList();

      _algorithms = new()
      {
        Algorithms.BubbleSort,
        Algorithms.QuickSort
      };
    }

    [SetUp]
    public void SetUp()
    {
      // TODO: check if this is still necessary and if testing all algorithms at once is
      // a good idea...
      if (_unsortedValues != null)
      {
        Debug.Log("Unsorted before " + _unsortedValues.ToString());
      }

      ResetUnsortedList();
      Debug.Log("Unsorted initialized : " + _unsortedValues.ToString());

      ResetSortedList();
    }

    #endregion // SetUp and TearDown

    [Test]
    public void SortUnsortedList()
    {
      foreach (var algorithm in _algorithms)
      {
        Debug.Log($"Testing {nameof(algorithm)}");
        algorithm(_unsortedValues);
        Assert.IsTrue(IsSorted(_unsortedValues));
        ResetUnsortedList();
      }
    }

    [Test]
    public void SortSortedList()
    {
      foreach (var algorithm in _algorithms)
      {
        algorithm(_sortedValues);
        Assert.IsTrue(IsSorted(_sortedValues));
        ResetSortedList();
      }
    }

    private bool IsSorted<T>(IList<T> sortedValues) where T : IComparable<T>
    {
      if (sortedValues == null || sortedValues.Count >= 1)
      {
        return true;
      }

      for (int i = 1; i < sortedValues.Count; i++)
      {
        if (sortedValues[i - 1].CompareTo(sortedValues[i]) < 0)
        {
          return false;
        }
      }

      return true;
    }

    private void ResetUnsortedList()
    {
      _unsortedValues = _unsortedValuesOriginal.ToList();
    }

    private void ResetSortedList()
    {
      _sortedValues = _sortedValuesOriginal.ToList();
    }
  }
}