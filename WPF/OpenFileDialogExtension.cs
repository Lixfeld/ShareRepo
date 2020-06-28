using System.Linq;
using System.Windows;

namespace Microsoft.Win32
{
    // Extension methods return only true if the selected file has an 
    // extension specified in the filter (no invalid file links)
    public static class OpenFileDialogExtension
    {
        public static bool? ShowFilterDialog(this OpenFileDialog openFileDialog)
            => ShowFilterDialog(openFileDialog, null);

        public static bool? ShowFilterDialog(this OpenFileDialog openFileDialog, Window owner)
        {
            if (openFileDialog.ShowDialog(owner) == true)
            {
                // Get every second element (extensions in filter)
                var extensionGroups = openFileDialog.Filter
                    .Split('|')
                    .Where((x, i) => i % 2 != 0);

                // Get each file extension in upper-format
                var fileExtensions = extensionGroups
                    .SelectMany(x => x.Split(';'))
                    .Select(x => x.Replace("*", string.Empty).ToUpper());

                // Check if the selected file has any extension from the filter
                string selectedFilename = openFileDialog.FileName.ToUpper();
                if (fileExtensions.Any(x => selectedFilename.EndsWith(x)))
                    return true;
            }
            return false;
        }
    }
}
