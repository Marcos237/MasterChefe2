using ImageCircle.Forms.Plugin.Abstractions;
using MasterChefe.Mobile.Interface;
using MasterChefe.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace MasterChefe.Mobile.Services
{
    public class RecipeService : IRecipeService
    {
        private IConnectionService service;
        private IImagemService iimagemService;
        private IIngredientesService ingredientesService;
        public RecipeService(IConnectionService service, IImagemService iimagemService, IIngredientesService ingredientesService)
        {
            this.iimagemService = iimagemService;
            this.service = service;
            this.ingredientesService = ingredientesService;
        }
        public List<RecipeModel> GetAll()
        {
            var models = new List<RecipeModel>();

            var client = service.GetClient();
            var url = service.GetUrl("/api/recipes");
            using (var cliente = client)
            {
                cliente.Timeout = new TimeSpan(0, 0, 30);
                cliente.DefaultRequestHeaders.Clear();

                var response = cliente.GetAsync(url);
                if (response.Result.IsSuccessStatusCode)
                {
                    try
                    {
                        var responseString = response.Result.Content.ReadAsStringAsync();
                        models = JsonConvert.DeserializeObject<IEnumerable<RecipeModel>>(responseString.Result).ToList();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                models = iimagemService.MontarImagem(models);
                models = ingredientesService.MontarIngredientes(models);
            }
            return models;
        }
    }
}
