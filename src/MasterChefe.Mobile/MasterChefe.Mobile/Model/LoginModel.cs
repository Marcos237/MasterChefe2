using MasterChefe.Mobile.View;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MasterChefe.Mobile.Model
{
    public class LoginModel : INotifyPropertyChanged
    {
        public LoginModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public Action InvalidLoginNotification;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public async void OnSubmit()
        {
            if (_email != "login@email.com" || _password != "123456")
            {
                InvalidLoginNotification();
                this.Email = string.Empty;
                this.Password = string.Empty;

                return;
            }

            Application.Current.MainPage = new RecipeView();
        }
    }
}
