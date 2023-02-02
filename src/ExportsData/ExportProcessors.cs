using System.Text;

namespace SmallWPFTestTask.ExportsData
{
    /// <summary>
    /// Class converter
    /// </summary>
    public sealed class ExportProcessors
    {
        public string? PathFile { get; set; }

        public void ConvertAndSaveDataToFile(IEnumerable<Interfaces.IConvertingCSV> dataToCSV)
        {
            if (string.IsNullOrEmpty(PathFile))
                throw new NullReferenceException($"{nameof(PathFile)} is empty.");

            FileStream fileStream = File.Create(PathFile);

            int countData = dataToCSV.Count();
            for (int i = 0; i < countData; i++)
            {
                fileStream.Write(GetByteFromString(dataToCSV.ElementAt(i).ConvertedItem()));

                if (i != countData)
                    fileStream.Write(GetByteFromString("\n"));
            }

            fileStream.Flush();
            fileStream.Dispose();
        }

        public void ConvertAndSaveDataToFile(IEnumerable<Interfaces.IConvertingTXT> dataToCSV)
        {
            if (string.IsNullOrEmpty(PathFile))
                throw new NullReferenceException($"{nameof(PathFile)} is empty.");

            FileStream fileStream = File.Create(PathFile);

            int countData = dataToCSV.Count();
            for (int i = 0; i < countData; i++)
            {
                fileStream.Write(GetByteFromString(dataToCSV.ElementAt(i).ConvertedItem()));

                if (i != countData)
                    fileStream.Write(GetByteFromString("\n"));
            }

            fileStream.Flush();
            fileStream.Dispose();
        }

        private static byte[] GetByteFromString(string source)
            => Encoding.UTF8.GetBytes(source);
    }
}
