using System.Collections.Generic;
using UnityEngine;
using static SortingAlgorithms.Algorithms;

[CreateAssetMenu(fileName = "QuickSort", menuName = "SortingAlgorithms/Algorithms/QuickSort")]
public class QuickSort : SortingAlgorithm
{
  public override void Sort<T>(IList<T> list)
  {
    QuickSort(list);
  }
}
