using System;
using System.Linq;

namespace System.Windows.Controls
{
    public static class ComboBoxExtensions
    {
        public static void BindToEnum(this ComboBox comboBox, Type enumType)
        {
            var valuesAndDescriptions = Enum.GetValues(enumType)
                .Cast<Enum>()
                .Select(x => new
                {
                    Value = x,
                    Description = EnumHelper.GetDescriptionOrName(x)
                })
                .ToArray();

            comboBox.ItemsSource = valuesAndDescriptions;
            comboBox.SelectedValuePath = "Value";
            comboBox.DisplayMemberPath = "Description";
        }

        /* XAML and Code-Behind
        <ComboBox x:Name="enumComboBox" SelectedValue="{Binding SelectedEnumValue}" />
        enumComboBox.BindToEnum(typeof(YourEnum));
         */
    }
}