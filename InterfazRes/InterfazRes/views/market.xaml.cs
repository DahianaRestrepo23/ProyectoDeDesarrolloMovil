using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InterfazRes.models;
using InterfazRes.servicios;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class market : ContentPage
    {
        usuariosModel user;
        productosServicio producServicio = new productosServicio();

        public market(usuariosModel actUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            user = actUser;

            var forgetPassword_tap = new TapGestureRecognizer();
            forgetPassword_tap.Tapped += (s, e) =>
            {
                labelCelularesRobados.IsVisible = true;
                contenCelularesRobados.IsVisible = true;
            };
            ControlCelularesRobados.GestureRecognizers.Add(forgetPassword_tap);
        }
    }
}