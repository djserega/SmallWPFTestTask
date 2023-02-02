using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SmallWPFTestTask.ViewModels
{
    public class MainWindow : BindableBase
    {
        public MainWindow()
        {
            GenerateFakeData();
        }

        public ObservableCollection<Models.Data> Items { get; set; } = new();

        #region Commands

        public ICommand SaveDataToCsvCommand => new DelegateCommand(() =>
        {
            string? fileName = Dialogs.GetFileNameSaving(ExportFormats.csv);

            if (string.IsNullOrWhiteSpace(fileName))
                return;

            IEnumerable<Interfaces.IConvertingCSV> selectedItems = GetSelectedItems();
            ExportsData.ExportProcessors.ConvertAndSaveDataToFile(fileName, selectedItems);
        });

        public ICommand SaveDataToTxtCommand => new DelegateCommand(() =>
        {
            string? fileName = Dialogs.GetFileNameSaving(ExportFormats.txt);

            if (string.IsNullOrWhiteSpace(fileName))
                return;

            IEnumerable<Interfaces.IConvertingTXT> selectedItems = GetSelectedItems();
            ExportsData.ExportProcessors.ConvertAndSaveDataToFile(fileName, selectedItems);
        });

        public ICommand GenerateNewDataCommand => new DelegateCommand(() =>
        {
            GenerateFakeData();
        });

        #endregion

        private void GenerateFakeData()
        {
            Items.Clear();
            FakeDataProvider.CreateFakeData(Items);
        }

        private IEnumerable<Models.Data> GetSelectedItems()
            => Items.Where(el => el.IsSelected).ToList();
    }
}