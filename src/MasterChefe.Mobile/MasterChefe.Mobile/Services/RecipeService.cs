using MasterChefe.Mobile.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasterChefe.Mobile.Services
{
    public class RecipeService 
    {
        public async Task<List<RecipeModel>> GetAll()
        {
            using (var cliente = new HttpClient())
            {
                var models = new List<RecipeModel>();
                string url = "https://localhost:7043/api/recipes";
                var response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<RecipeModel>>(responseString);
                }
                return models;
            }
        }
    }
}
