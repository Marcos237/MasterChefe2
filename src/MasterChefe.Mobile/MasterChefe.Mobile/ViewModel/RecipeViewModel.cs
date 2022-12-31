﻿using MasterChefe.Mobile.Initillizer;
using MasterChefe.Mobile.Interface;
using MasterChefe.Mobile.Model;
using MasterChefe.Mobile.Services;
using MasterChefe.Mobile.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private RecipeModel selectedModelUpdate;
        public RecipeModel SelectedModel
        {
            get { return selectedModel; }
            set { SetProperty(ref selectedModel, value); }
        }
        public RecipeModel SelectedModelUpdate
        {
            get { return selectedModelUpdate; }
            set { SetProperty(ref selectedModelUpdate, value); }
        }
        public RecipeViewModel()
        {
            Model = new ObservableCollection<RecipeModel>(recipeService.GetAll());
        }


        public ICommand OpenDetalheCommandUpdate => new Command<RecipeModel>(async (RecipeModel d) =>
        {
            var view = new AtualizaRecipeViewModel(d);
            await App.Current.MainPage.Navigation.PushAsync(new AtualizaRecipeView(view));
        });

        public ICommand OpenDetalheCommand => new Command<RecipeModel>(async (RecipeModel d) =>
        {
            var vm = new DetalhesViewModel(d);
            await Application.Current.MainPage.Navigation.PushAsync(new DetalheView(vm));
        });

    }
}