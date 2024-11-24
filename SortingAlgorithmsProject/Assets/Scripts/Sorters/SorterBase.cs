using System;
using UnityEngine;

public abstract class SorterBase<T> : MonoBehaviour where T : IComparable<T>
{
  [SerializeField]
  private SortingAlgorithm _algorithm;

  [SerializeField]
  private SortableData<T> _data;

  void OnGUI()
  {
    if (GUI.Button(new Rect(5, 5, 150, 50), "Sort"))
    {
      Sort();
    }
  }

  public void Sort()
  {
    _algorithm.Sort(_data.GetData());
  }
}
