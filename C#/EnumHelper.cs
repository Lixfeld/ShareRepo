using System;
using System.Linq;
using System.Reflection;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace PROJECT.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescriptionOrName(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute descriptionAttribute = fieldInfo.GetCustomAttributes<DescriptionAttribute>(false).FirstOrDefault();

            return descriptionAttribute?.Description ?? value.ToString();
        }

        public static string[] GetAllDescriptions(Type enumType)
        {
            return Enum.GetValues(enumType)
                       .Cast<Enum>()
                       .Select(x => GetDescriptionOrName(x))
                       .ToArray();
        }
    }
}