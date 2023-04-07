using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;

namespace PROJECT.Dialogs
{
    public class OpenFolderDialog
    {
        public string FolderName { get; private set; }
        public string InitialDirectory { get; set; }

        public bool? ShowDialog()
        {
            return ShowDialogInternal(x => x.ShowDialog());
        }

        public bool? ShowDialog(Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            return ShowDialogInternal(x => x.ShowDialog(owner));
        }

        private bool? ShowDialogInternal(Func<CommonOpenFileDialog, CommonFileDialogResult> func)
        {
            // WindowsAPICodePack-Shell: https://www.nuget.org/packages/WindowsAPICodePack-Shell/
            using (CommonOpenFileDialog openFolderDialog = new CommonOpenFileDialog())
            {
                openFolderDialog.IsFolderPicker = true;
                openFolderDialog.InitialDirectory = InitialDirectory;

                CommonFileDialogResult dialogResult = func(openFolderDialog);
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
}
