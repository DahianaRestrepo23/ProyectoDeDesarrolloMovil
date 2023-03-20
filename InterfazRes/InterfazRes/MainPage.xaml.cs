using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InterfazRes.models;
using InterfazRes.servicios;
using Realms;
using Realms.Sync;
using Xamarin.Forms;

namespace InterfazRes
{
    public partial class MainPage : ContentPage
    {
        usuariosServicio userServicio = new usuariosServicio();

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ButtonValidarLogin(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtUsuario.Text == " " || txtUsuario.Text == null)
            {
                await DisplayAlert("¡ERROR!", "El usuario no puede estar vacio.", "Continuar!");
                return;
            }

            if (txtContrasena.Text == "" || txtContrasena.Text == " " || txtContrasena.Text == null)
            {
                await DisplayAlert("¡ERROR!", "La contraseña no puede estar vacia.", "Continuar!");
                return;
            }

            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            usuariosModel user = userServicio.validarUsuarioContrasena(nombreUsuario, contrasena);

            if (user == null)
            {
                await DisplayAlert("¡ERROR!", "El usuario y/o la contraseña no son validas.", "Continuar!");
            }
            else
            {
                await Navigation.PushModalAsync(new Homepage(user));
            }
        }
    }
}
