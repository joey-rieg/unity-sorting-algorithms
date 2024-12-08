using System.Collections.Generic;
using UnityEngine;
using static SortingAlgorithms.Algorithms;

[CreateAssetMenu(fileName = "MergeSort", menuName = "SortingAlgorithms/Algorithms/MergeSort")]
public class MergeSort : SortingAlgorithm
{
  public override void Sort<T>(IList<T> list)
  {
    MergeSort(list);
  }
}
