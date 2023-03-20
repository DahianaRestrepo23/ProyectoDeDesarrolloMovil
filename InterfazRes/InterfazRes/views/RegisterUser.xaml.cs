using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InterfazRes.models;
using InterfazRes.servicios;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterUser : ContentPage
    {
        usuariosServicio userServicio = new usuariosServicio();

        public RegisterUser()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ButtonRegistrarUsuario(object sender, EventArgs e)
        {
            if (txtNombres.Text == "" || txtNombres.Text == " " || txtNombres.Text == null)
            {
                await DisplayAlert("¡ERROR!", "El nombre(s) no puede estar vacio.", "Continuar!");
                return;
            }

            if (txtApellidos.Text == "" || txtApellidos.Text == " " || txtApellidos.Text == null)
            {
                await DisplayAlert("¡ERROR!", "El apellido(s) no puede estar vacio.", "Continuar!");
                return;
            }

            if (txtIdentificacion.Text == "" || txtIdentificacion.Text == " " || txtIdentificacion.Text == null)
            {
                await DisplayAlert("¡ERROR!", "La identificacion no puede estar vacia.", "Continuar!");
                return;
            }

            if (txtUsuario.Text == "" || txtUsuario.Text == " " || txtUsuario.Text == null)
            {
                await DisplayAlert("¡ERROR!", "El nombre de usuario no puede estar vacio.", "Continuar!");
                return;
            }

            if (txtContrasena.Text == "" || txtContrasena.Text == " " || txtContrasena.Text == null)
            {
                await DisplayAlert("¡ERROR!", "La contraseña no puede estar vacia.", "Continuar!");
                return;
            }

            if (userServicio.validarUsuarioIdentificacion(txtIdentificacion.Text.Trim(), txtUsuario.Text.Trim()) == false)
            {
                if (userServicio.guardarUsuario(txtNombres.Text.Trim(), txtApellidos.Text.Trim(), txtIdentificacion.Text.Trim(), txtUsuario.Text.Trim(), txtContrasena.Text.Trim()))
                {
                    await DisplayAlert("¡EXITOSO!", "Usuario registrado con exito.", "Continuar!");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("¡ERROR!", "Vuelva a intentarlo por favor.", "Continuar!");
                    return;
                }
            }
            else
            {
                await DisplayAlert("¡ERROR!", "La identificacion y/o el usuario ya existen.", "Continuar!");
                return;
            }
        }
    }
}