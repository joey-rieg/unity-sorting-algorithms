using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
  public static partial class Algorithms
  {
    public static void QuickSort<T>(IList<T> list) where T : IComparable<T>
    {
      QuickSort(list, 0, list.Count - 1);
    }

    private static void QuickSort<T>(IList<T> list, int start, int end) where T : IComparable<T>
    {
      if (start >= end)
        return;

      int pivot = QuickSortPartition(list, start, end);

      QuickSort(list, start, pivot - 1);
      QuickSort(list, pivot + 1, end);
    }

    private static int QuickSortPartition<T>(IList<T> list, int start, int end) where T : IComparable<T>
    {
      int i = start - 1;
      int j = start;
      T lastElement = list[end];

      while (j < end)
      {
        if (list[j].CompareTo(lastElement) < 0)
        {
          ++i;
          (list[j], list[i]) = (list[i], list[j]);
        }
        ++j;
      }

      ++i;
      (list[end], list[i]) = (list[i], list[end]);

      return i;
    }
  }
}
