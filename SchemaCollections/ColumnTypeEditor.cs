using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CodeSmith.Xamples
{
    public class CustomDropDownListProperty
    {
        private List<string> _values = new List<string>();

        public CustomDropDownListProperty()
        {
            SelectedItem = "None";
        }

        public CustomDropDownListProperty(List<string> values)
        {
            if (values.Count > 0)
                SelectedItem = values[0];
            else
                SelectedItem = "None";

            Values = values;
        }

        public List<string> Values
        {
            get
            {
                if (_values == null)
                    _values = new List<string>();

                return _values;
            }
            set
            {
                if (value != null)
                    _values = value;
            }
        }

        [Browsable(false)]
        public string SelectedItem { get; set; }

        public override string ToString()
        {
            return SelectedItem;
        }
    }

    public class CustomDropDownListPropertyEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _service;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                _service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (_service != null && value is CustomDropDownListProperty)
                {
                    var property = (CustomDropDownListProperty)value;
                    var list = new ListBox
                    {
                        SelectionMode = SelectionMode.One
                    };

                    list.Click += (s, e) => _service.CloseDropDown();

                    foreach (string item in property.Values)
                    {
                        list.Items.Add(item);
                    }

                    _service.DropDownControl(list);

                    if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
                    {
                        property.SelectedItem = list.SelectedItem.ToString();
                        value = property;
                    }
                }
            }

            return value;
        }
    }
}
