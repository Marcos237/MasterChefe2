using System.Collections.Generic;

namespace MasterChefe.Mobile.Model
{
    public class RecipeModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public string WayOfPrepare { get; set; }

        public ICollection<IngredienteModel> Ingredients { get; set; }

        public string Image { get; set; }

        public string Photo
        {
            get
            {
                return $"imagem10.jpg".Replace(" ", "");
            }
        }
    }
}
