using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace PROJECT.Dialogs
{
    public class OpenFolderDialog
    {
        // WindowsAPICodePack-Shell: https://www.nuget.org/packages/WindowsAPICodePack-Shell/
        private readonly CommonOpenFileDialog openFolderDialog;
        public string FolderName { get; private set; }

        public OpenFolderDialog()
        {
            openFolderDialog = new CommonOpenFileDialog() { IsFolderPicker = true };
        }

        public bool? ShowDialog(Window owner)
        {
            CommonFileDialogResult dialogResult;
            if (owner != null)
                dialogResult = openFolderDialog.ShowDialog(owner);
            else
                dialogResult = openFolderDialog.ShowDialog();

            switch (dialogResult)
            {
                case CommonFileDialogResult.Ok:
                    FolderName = openFolderDialog.FileName;
                    return true;
                case CommonFileDialogResult.Cancel:
                    return false;
                case CommonFileDialogResult.None:
                default:
                    return null;
            }
        }
    }
}
