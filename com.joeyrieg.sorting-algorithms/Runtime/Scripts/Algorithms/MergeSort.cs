using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
  public static partial class Algorithms
  {
    public static void MergeSort<T>(IList<T> list) where T : IComparable<T>
    {
      MergeSort(list, 0, list.Count - 1);
    }

    private static void MergeSort<T>(IList<T> nums, int start, int end) where T : IComparable<T>
    {
      if (start >= end) // Base condition
        return;

      int mid = start + (end - start) / 2; // Avoid potential overflow

      // Recursively split and sort the halves
      MergeSort(nums, start, mid);
      MergeSort(nums, mid + 1, end);

      // Merge sorted halves
      Merge(nums, start, mid, end);
    }

    private static void Merge<T>(IList<T> nums, int start, int mid, int end) where T : IComparable<T>
    {
      int n1 = mid - start + 1; // Size of left part
      int n2 = end - mid;       // Size of right part

      IList<T> leftList = new List<T>();
      IList<T> rightList = new List<T>();

      // Populate temporary lists
      for (int idx = 0; idx < n1; idx++)
        leftList.Add(nums[start + idx]);

      for (int idx = 0; idx < n2; idx++)
        rightList.Add(nums[mid + 1 + idx]);

      int i = 0, j = 0;
      int k = start;

      // Merge sorted lists
      while (i < n1 && j < n2)
      {
        if (leftList[i].CompareTo(rightList[j]) <= 0) // CompareTo for ordering
        {
          nums[k] = leftList[i];
          i++;
        }
        else
        {
          nums[k] = rightList[j];
          j++;
        }
        k++;
      }

      // Copy any remaining elements
      while (i < n1)
      {
        nums[k] = leftList[i];
        i++;
        k++;
      }

      while (j < n2)
      {
        nums[k] = rightList[j];
        j++;
        k++;
      }
    }
  }
}
