using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortableData<T> : ScriptableObject where T : IComparable<T>
{
  public abstract void Init(int numberOfElements, bool randomize = false);
  public abstract IList<T> GetData();
}
