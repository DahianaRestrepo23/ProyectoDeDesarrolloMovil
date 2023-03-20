using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfazRes.models;
using InterfazRes.servicios;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addProduct : ContentPage
    {
        usuariosModel user;
        productosServicio productServicio = new productosServicio();

        public addProduct(usuariosModel actUser)
        {
            InitializeComponent();

            user = actUser;

            var forgetPassword_tap = new TapGestureRecognizer();
            forgetPassword_tap.Tapped += (s, e) =>
            {
                controladorRobado.IsVisible = true;
            };
            ControlCelularesRobados.GestureRecognizers.Add(forgetPassword_tap);
        }

        private void CheckEsRobado_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkEsRobado.IsChecked == true)
            {
                chkEsUsado.IsEnabled = false;
                chkEsUsado.IsChecked = true;
            }
            else
            {
                chkEsUsado.IsEnabled = true;
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtNombre.Text == " " || txtNombre.Text == null)
            {
                await DisplayAlert("¡ERROR!", "El nombre no puede estar vacio.", "Continuar!");
                return;
            }

            if (txtDescripcion.Text == "" || txtDescripcion.Text == " " || txtDescripcion.Text == null)
            {
                await DisplayAlert("¡ERROR!", "La descripcion no puede estar vacia.", "Continuar!");
                return;
            }

            if (txtPrecio.Text == "" || txtPrecio.Text == " " || txtPrecio.Text == null)
            {
                await DisplayAlert("¡ERROR!", "El precio no puede estar vacio.", "Continuar!");
                return;
            }

            int idCondicion = 0;

            if (chkEsUsado.IsChecked == false)
            {
                idCondicion = 1;
            }
            else
            {
                if (chkEsRobado.IsChecked == true)
                {
                    idCondicion = 3;
                }
                else
                {
                    idCondicion = 2;
                }
            }

            if (productServicio.guardarProducto(txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), idCondicion, float.Parse(txtPrecio.Text.Trim()), chkEstaReportado.IsChecked, user.intIdUsuario))
            {
                await DisplayAlert("¡EXITOSO!", "Producto registrado con exito.", "Continuar!");

                if (productServicio.consultarRangoBrayan(user.intIdUsuario))
                {
                    await DisplayAlert("¡FELICIDADES!", "Nuevo logro desbloqueado\nEres todo un Brayan.", "Eso es todo!");
                }

                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("¡ERROR!", "Vuelva a intentarlo por favor.", "Continuar!");
                return;
            }
        }
    }
}