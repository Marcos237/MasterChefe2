using MasterChefe.Mobile.Interface;
using MasterChefe.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterChefe.Mobile.Services
{
    public class IngredienteService : IIngredientesService
    {
        private readonly IConnectionService service;

        public IngredienteService(IConnectionService service)
        {
            this.service = service;
        }
        public List<IngredienteModel> GetById(int id)
        {
            var models = new List<IngredienteModel>();
            var client = service.GetClient();
            var url = service.GetUrl($"/api/Ingredient/{id}");
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
                        models = JsonConvert.DeserializeObject<IEnumerable<IngredienteModel>>(responseString.Result).ToList();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return models;
        }

        public List<RecipeModel> MontarIngredientes(List<RecipeModel> recipe)
        {
            foreach (var item in recipe)
            {
                item.Ingredients = GetById(item.Id);
            }
            return recipe;
        }
    }
}