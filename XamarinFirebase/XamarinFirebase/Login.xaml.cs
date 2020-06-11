using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void LoginClicked(object sender, EventArgs e)
        {
            string value = Preferences.Get(
                 email.Text, "");

            if (password.Text == value)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                var result = await DisplayAlert("Login Process", "Username and Password Dismatch!", "", "CANCEL");
                if (result != true) // if it's equal to cancel
                {
                    return; // just return to the page and do nothing.
                }
            }
        }
        private async void Register_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}