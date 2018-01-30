using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using CodeHelperWPF.Data;
using System.Data.SQLite;
using System.Collections;

namespace CodeHelperWPF.ViewModel
{
    partial class DataModelViewModel : DependencyObject
    {
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(DataModelViewModel), new PropertyMetadata("", FilterText_Changed));

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(DataModelViewModel), new PropertyMetadata(null));


        public DataModelViewModel()
        {
            DataModel db = new DataModel();

            Items = (CollectionView)
                CollectionViewSource.GetDefaultView(db.GetLanguages());
            Items.Filter = FilterDataModel;
        }
    }
}
