using System.Collections.Generic;
using System.Text;

namespace CodeSmith.Xamples
{
    public class ColumnConfigurationCollection
    {
        public List<ColumnConfiguration> Columns { get; set; } = new List<ColumnConfiguration>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Columns:");
            foreach (var column in Columns)
            {
                sb.AppendLine(column.ToString());
            }
            return sb.ToString();
        }
    }
}
