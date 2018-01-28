using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using CodeHelperWPF.Data;

namespace CodeHelperWPF.ViewModel
{
    partial class CodeDataViewModel : DependencyObject
    {
        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as CodeDataViewModel;
            if (current != null)
            {
                //current.Items.Filter = null;
                //current.Items.Filter = current.FilterCodeData;
            }
        }

        private bool FilterCodeData(object obj)
        {
            bool result = true;
            CodeData currnet = obj as CodeData;

            if (!string.IsNullOrWhiteSpace(FilterText) && currnet != null /* &&
                !currnet.FirstName.Contains(FilterText) && !currnet.LastName.Contains(FilterText)*/)
            {
                result = false;
            }

            return result;

        }
    }
}
