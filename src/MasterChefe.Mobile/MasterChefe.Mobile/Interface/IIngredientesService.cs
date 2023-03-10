using MasterChefe.Mobile.Model;
using System.Collections.Generic;

namespace MasterChefe.Mobile.Interface
{
    public interface IIngredientesService
    {
        List<IngredienteModel> GetById(int id);
        List<RecipeModel>  MontarIngredientes(List<RecipeModel> recipe);
        bool  AtualizarIngrediente(IngredienteModel model);
        bool  CadastrerIngrediente(IngredienteModel model);
        bool  Deletar(int id);
    }
}
