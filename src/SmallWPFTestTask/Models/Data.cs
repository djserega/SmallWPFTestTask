using System;
using System.Text;

namespace SmallWPFTestTask.Models
{
    public class Data : ExportsData.ExportModelBase
    {
        public bool IsSelected { get; set; }
        public int Column1 { get; set; }
        public string? Column2 { get; set; }
        public string? Column3 { get; set; }
        public DateTime Column4 { get; set; }
        public string? Column5 { get; set; }
        public int Column6 { get; set; }

        public override string GetConvertedItem(char separator)
        {
            StringBuilder builder = new();
            builder.Append(Column1);
            builder.Append(separator);
            builder.Append(Column2);
            builder.Append(separator);
            builder.Append(Column3);
            builder.Append(separator);
            builder.Append(Column4);
            builder.Append(separator);
            builder.Append(Column5);
            builder.Append(separator);

            return builder.ToString();
        }
    }
}
