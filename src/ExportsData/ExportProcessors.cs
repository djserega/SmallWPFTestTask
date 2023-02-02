using System.Text;

namespace SmallWPFTestTask.ExportsData
{
    /// <summary>
    /// Class converter
    /// </summary>
    public sealed class ExportProcessors
    {
        public static void ConvertAndSaveDataToFile(string pathFile, IEnumerable<Interfaces.IConvertingCSV> dataToCSV)
        {
            FileStream fileStream = File.Create(pathFile);

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

        public static void ConvertAndSaveDataToFile(string pathFile, IEnumerable<Interfaces.IConvertingTXT> dataToCSV)
        {
            FileStream fileStream = File.Create(pathFile);

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
