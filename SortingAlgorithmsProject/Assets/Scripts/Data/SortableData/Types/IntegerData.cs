using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "IntegerData", menuName = "SortingAlgorithms/Data/IntegerData")]
public class IntegerData : SortableData<int>
{
  public int NumValues = 100;
  public int MinValue = 0;
  public int MaxValue = 100;
  public bool Randomize = false;

  [Header("Values can also be manually set.")]
  public List<int> Data = new List<int>();

  public override IList<int> GetData()
  {
    return Data;
  }

  public override void Init(int numberOfElements, bool randomize = false)
  {
    if (randomize)
    {
      Data = InitializeRandomList(MinValue, MaxValue, NumValues);
    }
    else
    {
      Data = InitializeSortedList(MinValue, MaxValue, NumValues);
    }
  }

  private List<int> InitializeSortedList(int min, int max, int numberOfElements)
  {
    if (numberOfElements <= 0 || max < min)
      throw new ArgumentException("Invalid arguments: Ensure max >= min and numberOfValues > 0");

    // Calculate step size (interval)
    double step = (double)(max - min) / (numberOfElements - 1);

    // Generate the array
    return Enumerable.Range(0, numberOfElements)
                     .Select(i => (int)(min + i * step)) // Calculate each value
                     .ToList();
  }

  private List<int> InitializeRandomList(int min, int max, int numberOfElements)
  {
    if (numberOfElements <= 0 || max < min)
      throw new ArgumentException("Invalid arguments: Ensure max >= min and numberOfValues > 0");

    System.Random random = new();
    return Enumerable.Range(0, numberOfElements)
                     .Select(_ => random.Next(min, max + 1)) // Generate random values
                     .ToList();
  }
}
