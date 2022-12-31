﻿using MasterChefe.Mobile.Model;
using System;

namespace MasterChefe.Mobile.ViewModel
{
    public class AtualizaRecipeViewModel : BaseViewModel
    {

        private RecipeModel model;

        public RecipeModel Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }

        public AtualizaRecipeViewModel()
        {
            Model = new RecipeModel();
        }

        public AtualizaRecipeViewModel(RecipeModel model)
        {
            IsBusy = false;

            Model = model;
        }

        public RecipeModel AtualizarRecipe(RecipeModel recipe, string path )
        {
            if (recipe != null)
            {
                if (path != null)
                {
                    var imagemBytes = System.IO.File.ReadAllBytes(path);
                    var base64 = Convert.ToBase64String(imagemBytes);
                    var imagem = new ImagemModel() { imagem = base64, nameImage = recipe.Image };
                    imageService.SaveImage(imagem);
                }

                recipe.Photo = null;
                recipeService.Atualiza(recipe);

            }
            return recipe;
        }

        public RecipeModel SalvarRecipe(RecipeModel recipe, string path)
        {
            if (recipe != null)
            {
                if (path != null)
                {
                    var imagemBytes = System.IO.File.ReadAllBytes(path);
                    var base64 = Convert.ToBase64String(imagemBytes);
                    var imagem = new ImagemModel() { imagem = base64, nameImage = recipe.Image };
                    imageService.SaveImage(imagem);
                }

                recipe.Photo = null;
                recipeService.Salvar(recipe);

            }
            return recipe;
        }

        public RecipeModel DeletarRecipe(RecipeModel recipe)
        {
            if (recipe != null)
            {
                recipeService.Delete(recipe);
            }
            return recipe;
        }
    }
}
