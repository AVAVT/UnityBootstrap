using Entitas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class IGroupExt
{
  public static T Any<T>(this IGroup<T> group) where T : class, IEntity
  {
    return group.AsEnumerable().DefaultIfEmpty(null).First();
  }
}