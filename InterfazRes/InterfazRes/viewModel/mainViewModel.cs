using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text;
using InterfazRes.models;
using InterfazRes.servicios;

namespace InterfazRes.viewModel
{
    public class MainViewModel : BaseViewModel
    {
        public List<productosModel> ProductsListNuevos { get; set; }
        public List<productosModel> ProductsListUsados { get; set; }
        public List<productosModel> ProductsListRobados { get; set; }

        productosServicio productServicio = new productosServicio();

        public MainViewModel()
        {
            //Picks = GetPicks();
            ProductsListNuevos = productServicio.obtenerProductosActivos(1);
            ProductsListUsados = productServicio.obtenerProductosActivos(2);
            ProductsListRobados = productServicio.obtenerProductosActivos(3);
        }

        public ICommand RegistarUsuarioCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new RegisterUser()));

        //public List<Pick> Picks { get; set; }
        //public ICommand OrderCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new OrderPage()));

        //private List<Pick> GetPicks()
        //{
        //    return new List<Pick>
        //    {
        //        new Pick
        //        {
        //            Title = "Desayuno", Image = "IMG01.png", Description = "Ordene un desayuno europeo"
        //        },
        //        new Pick
        //        {
        //            Title = "Almuerzo", Image = "IMG03.png", Description = "Ordene un almuerzo europeo" }
        //        };
        //}
    }

    //public class Pick
    //{
    //    public string Title { get; set; }
    //    public string Image { get; set; }
    //    public string Description { get; set; }
    //    public string Price { get; set; }

    //}

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
