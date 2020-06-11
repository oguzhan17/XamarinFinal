using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;
using ZXing.Net.Mobile.Forms;
using System.Collections.ObjectModel;

namespace XamarinFirebase
{

    public partial class MainPage : ContentPage
    {
        ObservableCollection<Comment> list = new ObservableCollection<Comment>();

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
            lst.BindingContext = list;
            scancode.IsVisible = false;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {

                    await Navigation.PopAsync();


                    scancode.Text = result.Text;
                    var product = await firebaseHelper.GetProduct(Convert.ToInt32(scancode.Text));
                    string pro = product.BarcodeNo.ToString();
                    string scantxt = scancode.Text;


                    scancode.Text = product.BarcodeNo.ToString();
                    scanName.Text = product.ProductName;



                    var comment = await firebaseHelper.GetComment(Convert.ToInt32(scancode.Text));



                    if (comment != null)
                    {
                        list.Add(comment);
                    }

                    //await Navigation.PushAsync(new ProductPage(scanName.Text));
                    //  await DisplayAlert("Success", "Product Retrive Successfully", "OK");

                });
            };




        }


        private async void map_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());

        }
    }
}
