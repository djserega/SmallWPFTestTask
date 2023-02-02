using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmallWPFTestTask
{
    internal class Dialogs
    {
        internal static string? GetFileNameSaving(ExportFormats format)
        {
            string extension = format switch
            {
                ExportFormats.csv => "csv",
                ExportFormats.txt => "txt",
                _ => throw new NotImplementedException($"Not find the format file as {format}"),
            };

            SaveFileDialog fileDialog = new()
            {
                CheckFileExists = false,
                DefaultExt = extension
            };
            if (fileDialog.ShowDialog() is bool)
            {
                string fileName = fileDialog.FileName;
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show("File is not selected");
                    return default;
                }

                return fileName;
            }

            return default;
        }
    }
}
