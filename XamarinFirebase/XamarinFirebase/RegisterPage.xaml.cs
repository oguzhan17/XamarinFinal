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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ema.Text) || string.IsNullOrEmpty(pass.Text))
                DisplayAlert("Empty Values", "Please enter E-mail address and Password", "OK");
            else
            {
                Preferences.Set(ema.Text, pass.Text);
                DisplayAlert("Sign Up Success", "", "Ok");
                Navigation.PushAsync(new MainPage());

            }
        }
    }
}