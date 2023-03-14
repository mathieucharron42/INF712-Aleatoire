using System;

namespace Aleatoire_Common.Extensions
{
    public static class TypeExtensions
    {
        public static string ToStringWithGenerics(this Type type)
        {
            string typeStr = type.Name;
            for (int i = 0; i < type.GenericTypeArguments.Length; ++i)
            {
                string origin = string.Format("`{0}", i + 1);
                string destination = string.Format("<{0}>", type.GenericTypeArguments[i].Name);
                typeStr = typeStr.Replace(origin, destination);
            }
            return typeStr;
        }
    }
}
