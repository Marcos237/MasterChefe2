using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChefe.Mobile.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterChefe.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            var model = new RegisterModel();
            this.BindingContext = model;

            model.InvalidPasswordNotification+= () => DisplayAlert("Erro", "Senhas não conferem!", "OK");

            InitializeComponent();

        }
    }
}