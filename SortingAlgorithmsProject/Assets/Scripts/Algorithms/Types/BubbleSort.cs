using System.Collections.Generic;
using UnityEngine;
using static SortingAlgorithms.Algorithms;

[CreateAssetMenu(fileName = "BubbleSort", menuName = "SortingAlgorithms/Algorithms/BubbleSort")]
public class BubbleSort : SortingAlgorithm
{
  public override void Sort<T>(IList<T> list)
  {
    BubbleSort(list);
  }
}
