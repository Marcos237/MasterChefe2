using MasterChefe.Mobile.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MasterChefe.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheRecipeView : ContentPage
    {
        public DetalheRecipeView()
        {
            InitializeComponent();
            BindingContext = new RecipeViewModel();
        }


    }
}