using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortingAlgorithm : ScriptableObject
{
  public abstract void Sort<T>(IList<T> list) where T : IComparable<T>;
}
