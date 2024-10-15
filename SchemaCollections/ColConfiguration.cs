using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CodeSmith.Xamples
{
    public class ColumnConfiguration
    {
        public string ColumnName { get; set; }

        private CustomDropDownListProperty _type = new CustomDropDownListProperty(new List<string> { "String", "Int", "Float", "DateTime", "Bool" });

        [Editor(typeof(CustomDropDownListPropertyEditor), typeof(UITypeEditor))]
        public CustomDropDownListProperty Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string AlternateName { get; set; }
        public bool OneClick { get; set; }

        public override string ToString()
        {
            return $"ColumnName: {ColumnName}, Type: {Type}, AlternateName: {AlternateName}, OneClick: {OneClick}";
        }
    }
}
