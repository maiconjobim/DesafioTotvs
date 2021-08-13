using System;
using System.Linq;

namespace DesafioTotvs.Application.Extentions
{
  public static class GenericTypeExtention
  {

    public static string GetGenericTypeName(this Type type)
    {
      if (!type.IsGenericType) return type.Name;

      var genericTypes = string.Join(","
          , type.GetGenericArguments().Select(genericArgument => genericArgument.Name));

      var typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";

      return typeName;
    }

    public static string GetGenericTypeName(this object @object) => @object.GetType().GetGenericTypeName();

  }
}