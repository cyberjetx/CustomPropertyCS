using System;

namespace CodeSmith.Xamples
{
    public class ColumnConfiguration
    {
        public string ColumnName { get; set; }
        public string Type { get; set; }
        public string AlternateName { get; set; }
        public bool OneClick { get; set; }

        public override string ToString()
        {
            return $"ColumnName: {ColumnName}, Type: {Type}, AlternateName: {AlternateName}";
        }
    }
}
