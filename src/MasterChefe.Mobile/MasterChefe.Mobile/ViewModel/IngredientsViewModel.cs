using MasterChefe.Mobile.Model;
using MasterChefe.Mobile.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MasterChefe.Mobile.ViewModel
{
    public class IngredientsViewModel : BaseViewModel
    {
        private ObservableCollection<IngredienteModel> model;
        public ObservableCollection<IngredienteModel> Model
        {
            get { return model; }
            set
            {
                SetProperty(ref model, value);
            }
        }
        private IngredienteModel selectedModel;
        public IngredienteModel SelectedModel
        {
            get { return selectedModel; }
            set { SetProperty(ref selectedModel, value); }
        }
        public IngredientsViewModel(int id)
        {
            var dados = ingredientesService.GetById(id);
            Model = new ObservableCollection<IngredienteModel>(dados);
        }
        public ICommand OpenDetalheCommand => new Command<IngredienteModel>(async (IngredienteModel d) =>
        {
            var vm = new AtualizaIngredienteViewModel(d);
            await App.Current.MainPage.Navigation.PushAsync(new AtualizaIngredienteView(vm));
        });
    }
}
