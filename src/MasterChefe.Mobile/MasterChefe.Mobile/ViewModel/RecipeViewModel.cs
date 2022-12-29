using MasterChefe.Mobile.Model;
using MasterChefe.Mobile.Services;
using MasterChefe.Mobile.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MasterChefe.Mobile.ViewModel
{
    public class RecipeViewModel : BaseViewModel
    {
        private ObservableCollection<RecipeModel> model;
        public ObservableCollection<RecipeModel> Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }
        private RecipeModel selectedModel;
        public RecipeModel SelectedModel
        {
            get { return selectedModel; }
            set { SetProperty(ref selectedModel, value); }
        }
        public RecipeViewModel()
        {
            var recipeService = new RecipeService();
            var dados = recipeService.GetAll().Result;
            Model = new ObservableCollection<RecipeModel>(dados);
        }

        public ICommand OpenDetalheCommand => new Command<RecipeModel>(async (RecipeModel d) =>
        {
            var vm = new DetalhesViewModel(d);
            await App.Current.MainPage.Navigation.PushAsync(new DetalheView(vm));
        });
    }
}