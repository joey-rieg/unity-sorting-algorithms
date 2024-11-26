using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
  public static partial class Algorithms
  {
    public static void BubbleSort<T>(IList<T> list) where T : IComparable<T>
    {
      for (int i = 0; i < list.Count - 1; i++)
      {
        for (int j = 0; j < list.Count - i - 1; j++)
        {
          if (list[j].CompareTo(list[j + 1]) > 0)
          {
            // Swap
            (list[j + 1], list[j]) = (list[j], list[j + 1]);
          }
        }
      }
    }
  }
}
