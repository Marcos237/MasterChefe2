using MasterChefe.Mobile.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterChefe.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeView : ContentPage
    {
        public RecipeView()
        {
            InitializeComponent();
            BindingContext = new RecipeViewModel();
        }
    }
}