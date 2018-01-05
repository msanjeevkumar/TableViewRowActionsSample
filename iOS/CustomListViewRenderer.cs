using System;
using registration;
using registration.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]

namespace registration.iOS
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        private CustomListView _listView;

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            _listView = Element as CustomListView;
            if (e.PropertyName == CustomListView.CartTransactionProperty.PropertyName)
            {
                var items = (Control.Source as CustomiOSListViewSource).Items;
                var transaction = _listView.CartTransaction;
                if (transaction.TransactionType == "Add")
                {
                    items.Insert(transaction.TransactionAtIndex, transaction.item);
                }
                else if (transaction.TransactionType == "Delete")
                {
                    items.RemoveAt(transaction.TransactionAtIndex);
                }
                else if (transaction.TransactionType == "Update")
                {
                    items[transaction.TransactionAtIndex] = transaction.item;
                }
                else if (transaction.TransactionType == "Clear")
                {
                    var count = items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        items.RemoveAt(0);
                    }
                }

                Control.ReloadData();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                Control.Source = new CustomiOSListViewSource(e.NewElement as CustomListView);
            }
        }
    }
}
