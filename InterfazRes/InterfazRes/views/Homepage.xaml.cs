using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfazRes.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    public partial class Homepage : ContentPage
    {
        usuariosModel user;

        public Homepage(usuariosModel actUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            

            user = actUser;
        }

        private async void buttonIrMenuCompras(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new market(user));
        }

        private async void buttonIrAgregar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new addProduct(user));
        }

        
    }
}