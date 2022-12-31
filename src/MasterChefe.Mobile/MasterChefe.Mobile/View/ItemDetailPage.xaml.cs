using System.ComponentModel;
using MasterChefe.Mobile.ViewModel;
using Xamarin.Forms;

namespace MasterChefe.Mobile.View
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}