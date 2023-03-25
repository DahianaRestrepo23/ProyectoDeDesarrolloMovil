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

       
    }

    

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
