using System;
using System.Collections.Generic;
using System.Text;
using XamarinFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinbarcode.firebaseio.com/");

        public async Task<List<Product>> GetAllProducts()
        {
         
            return (await firebase
              .Child("Products")
              .OnceAsync<Product>()).Select(item => new Product
              {
                  ProductName = item.Object.ProductName,
                  BarcodeNo = item.Object.BarcodeNo
              }).ToList();

        }
        public async Task<Product> GetProduct(int BarcodeNo)
        {
            var allProducts = await GetAllProducts();
            await firebase
              .Child("Products")
              .OnceAsync<Product>();
            return allProducts.Where(a => a.BarcodeNo == BarcodeNo).FirstOrDefault();
        }

        public async Task<List<Comment>> GetAllComment()
        {
            return (await firebase
             .Child("Yorum")
             .OnceAsync<Comment>())
             .Select(item => new Comment
             {

                 Yorum = item.Object.Yorum,
                 BarcodeNo = item.Object.BarcodeNo
             }).ToList();
        }

        public async Task<Comment> GetComment(int BarcodeNo)
        {
            var allComments = await GetAllComment();
            await firebase
              .Child("Yorum")
              .OnceAsync<Comment>();
            return allComments.Where(a => a.BarcodeNo == BarcodeNo).FirstOrDefault();
        }
    }
}
