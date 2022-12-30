using MasterChefe.Mobile.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterChefe.Mobile.Interface
{
    public interface IRecipeService
    {
        List<RecipeModel> GetAll();
    }
}
