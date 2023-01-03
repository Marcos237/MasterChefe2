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
            
            model.ExistingUserNotification += () => DisplayAlert("Erro", "Usuário já cadastrado!", "OK");
            
            model.CreatedUserNotification += () => DisplayAlert("Erro", "Usuário cadastrado com sucesso!", "OK");
            
            model.ErrorCreatingUserNotification += () => DisplayAlert("Erro", "Erro ao criar usuário, tente novamente!", "OK");

        InitializeComponent();

        }
    }
}