using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using CodeHelperWPF.Data;

namespace CodeHelperWPF.ViewModel
{
    partial class DataModelViewModel : DependencyObject
    {
        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as DataModelViewModel;
            if (current != null)
            {
                //current.Items.Filter = null;
                //current.Items.Filter = current.FilterDataModel;
            }
        }

        private bool FilterDataModel(object obj)
        {
            bool result = true;
            DataModel currnet = obj as DataModel;

            if (!string.IsNullOrWhiteSpace(FilterText) && currnet != null /* &&
                !currnet.FirstName.Contains(FilterText) && !currnet.LastName.Contains(FilterText)*/)
            {
                result = false;
            }

            return result;

        }
    }
}
