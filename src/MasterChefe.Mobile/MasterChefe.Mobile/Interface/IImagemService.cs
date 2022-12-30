using MasterChefe.Mobile.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MasterChefe.Mobile.Interface
{
    public interface IImagemService
    {
        byte[] GetImage(string url);
        List<RecipeModel> MontarImagem(List<RecipeModel> itens);
    }
}
