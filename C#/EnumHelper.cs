using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

// Recommended enum library: Enums.NET (https://github.com/TylerBrinkley/Enums.NET)
namespace PROJECT.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum enumObj)
        {
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            DescriptionAttribute descriptionAttribute = fieldInfo.GetCustomAttributes<DescriptionAttribute>(false).FirstOrDefault();

            return descriptionAttribute?.Description ?? enumObj.ToString();
        }

        public static IEnumerable<string> GetAllDescriptions(Type enumType)
        {
            return Enum.GetValues(enumType)
                       .Cast<Enum>()
                       .Select(x => GetDescription(x));
        }

        public static void BindEnumToComboBox(Type enumType, ComboBox comboBox)
        {
            var valuesAndDescription = Enum.GetValues(enumType)
                .Cast<Enum>()
                .Select(e => new { Value = e, Description = GetDescription(e) })
                .ToList();

            comboBox.ItemsSource = valuesAndDescription;
            comboBox.SelectedValuePath = "Value";
            comboBox.DisplayMemberPath = "Description";
        }
    }
}