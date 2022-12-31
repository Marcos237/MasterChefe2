﻿using Android.Graphics;
using Android.Widget;
using MasterChefe.Mobile.Model;
using MasterChefe.Mobile.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterChefe.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtualizaRecipeView : ContentPage
    {
        public AtualizaRecipeView(AtualizaRecipeViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        private async void btnUpLoad_Clicked(object sender, System.EventArgs e)
        {
            await GetPhoto();
        }

        private  void btnSalvar_Clicked(object sender, System.EventArgs e)
        {
             AtualizarReceita();
             Navigation.PushAsync(new DetalheRecipeView());
        }

        public bool AtualizarReceita()
        {
            var recipe = new RecipeModel()
            {
                Id = Convert.ToInt32(lblId.Text),
                Title = txtTitulo.Text,
                Description= txtDescricao.Text,
                WayOfPrepare= edModoPreparo.Text,
                Image = lblReceita.Text,
                Photo = imgReceita
            };

            AtualizaRecipeViewModel model = new AtualizaRecipeViewModel();
            var fullpath = lblFullPath.Text;
             model.AtualizarRecipe(recipe, fullpath);
            return true;
        }

        public async Task<bool> GetPhoto()
        {
            try
            {
                RecipeModel recipe = new RecipeModel();
                await CrossMedia.Current.Initialize();

                var pickImage = await FilePicker.PickAsync(new PickOptions()
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Imagem"
                });
                if (pickImage != null)
                {
                    var steam = await pickImage.OpenReadAsync();
                    imgReceita.Source = ImageSource.FromStream(() => steam);
                    lblReceita.Text = pickImage.FileName;
                    lblFullPath.Text = pickImage?.FullPath;
                }

                return true;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        private void btnExcluir_Clicked(object sender, System.EventArgs e)
        {
            DeletarReceita();
            Navigation.PushAsync(new DetalheRecipeView());
        }

        public bool DeletarReceita()
        {
            var recipe = new RecipeModel()
            {
                Id = Convert.ToInt32(lblId.Text),
            };

            AtualizaRecipeViewModel model = new AtualizaRecipeViewModel();
            model.DeletarRecipe(recipe);
            return true;
        }
    }
}