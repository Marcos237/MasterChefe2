using MasterChefe.Mobile.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterChefe.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public DetalheView(DetalhesViewModel view)
        {
            InitializeComponent();
            BindingContext = view;
        }
    }
}