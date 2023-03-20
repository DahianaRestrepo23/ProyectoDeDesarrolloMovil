using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Realms;
using Xamarin.Forms;

namespace InterfazRes.models
{
    public class productosModel : RealmObject
    {
        public int intIdProducto { get; set; }
        public string strNombre { get; set; }
        public string strDescripcion { get; set; }
        public int intCondicion { get; set; } //1.Nuevo 2.Usado 3.Robado
        public float fltPrecio { get; set; }
        public bool bitEstado { get; set; }
        public bool bitReportado { get; set; }
        public int intIdUsuario { get; set; }

        public ICommand MostrarInfoCelularCommand => new Command((idProducto) =>
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            Application.Current.MainPage.Navigation.PushModalAsync(new detailProduct(Convert.ToInt32(idProducto)));
        });
    }
}
