namespace SmallWPFTestTask.ExportsData
{
    /// <summary>
    /// Base derived class for importing data into others formats.
    /// Supported formats: CSV, TXT
    /// </summary>
    public abstract class ExportModelBase : Interfaces.IConvertingCSV, Interfaces.IConvertingTXT
    {
        string Interfaces.IConvertingCSV.ConvertedItem() => GetConvertedItem(Config.separatorCSV);
        string Interfaces.IConvertingTXT.ConvertedItem() => GetConvertedItem(Config.separatorTXT);

        public abstract string GetConvertedItem(char separatorChar);
    }
}
