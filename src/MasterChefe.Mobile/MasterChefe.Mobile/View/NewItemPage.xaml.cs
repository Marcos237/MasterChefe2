using MasterChefe.Mobile.Model;
using MasterChefe.Mobile.ViewModel;
using Xamarin.Forms;

namespace MasterChefe.Mobile.View
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}