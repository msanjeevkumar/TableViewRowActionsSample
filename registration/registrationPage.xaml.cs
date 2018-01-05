using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace registration
{
    public partial class registrationPage : ContentPage
    {
        public registrationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            CartList.CartTransaction = new ListTransaction()
            {
                item = new ListItemViewModel() { Title = "Title", Detail = "Detail" },
                TransactionAtIndex = 0,
                TransactionType = "Add"
            };
        }
    }
}
