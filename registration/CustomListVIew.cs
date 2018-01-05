using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
namespace registration
{
    public class CustomListView : ListView, INotifyPropertyChanged
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create("Items", typeof(IEnumerable<ListItemViewModel>), typeof(CustomListView), new List<ListItemViewModel>());

        public static readonly BindableProperty CartTransactionProperty =
            BindableProperty.Create("CartTransaction", typeof(ListTransaction), typeof(CustomListView), default(ListTransaction));

        public event EventHandler<SelectedItemChangedEventArgs> DeleteItemSelected;

        public event EventHandler<SelectedItemChangedEventArgs> ReduceQuantitySelected;

        public IEnumerable<ListItemViewModel> Items
        {
            get
            {
                return (IEnumerable<ListItemViewModel>)GetValue(ItemsProperty);
            }

            set
            {
                SetValue(ItemsProperty, value);
            }
        }

        public ListTransaction CartTransaction
        {
            get { return (ListTransaction)GetValue(CartTransactionProperty); }
            set { SetValue(CartTransactionProperty, value); }
        }

        public void NotifyDeleteItemSelected(int item)
        {
            if (DeleteItemSelected != null)
            {
                DeleteItemSelected(this, new SelectedItemChangedEventArgs(item));
            }
        }

        public void NotifyReduceQuantitySelected(int item)
        {
            if (ReduceQuantitySelected != null)
            {
                ReduceQuantitySelected(this, new SelectedItemChangedEventArgs(item));
            }
        }
    }
}
