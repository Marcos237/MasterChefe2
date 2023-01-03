using MasterChefe.Mobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterChefe.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsDetalheView : ContentPage
    {
        public IngredientsDetalheView(IngredientsViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}