using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfazRes.models;
using InterfazRes.servicios;
using Realms.Sync;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detailProduct : ContentPage
    {
        productosServicio productServicio = new productosServicio();
        productosModel producto = new productosModel();

        public detailProduct(int idProducto)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            producto = productServicio.obtenerProductoPorId(idProducto);

            txtNombre.Text = producto.strNombre;
            txtDescripcion.Text = producto.strDescripcion;
            txtPrecio.Text = producto.fltPrecio.ToString("$#,##0.00");
            chkEsUsado.IsChecked = producto.intCondicion == 1 ? false : true;
            chkEsRobado.IsChecked = producto.intCondicion == 3 ? true : false;
            chkEstaReportado.IsChecked = producto.bitReportado;
            controladorRobado.IsVisible = producto.intCondicion == 3 ? true : false;
        }

        private async void btnComprar_Clicked(object sender, EventArgs e)
        {
            if (productServicio.actualizarEstadoCompra(producto.intIdProducto))
            {
                await DisplayAlert("¡EXITOSO!", "Compra registrada con exito.", "Continuar!");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("¡ERROR!", "Vuelva a intentarlo por favor.", "Continuar!");
                return;
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}