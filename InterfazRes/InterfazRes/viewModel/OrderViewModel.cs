using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InterfazRes.viewModel
{
    public class OrderViewModel : BaseViewModel
    {
        public OrderViewModel()
        {
            MenuList = GetMenu();
        }
        public List<Pick> MenuList { get; set; }
        //public ICommand BackCommand => new Command(() => ApplicationException.Current.MainPage.Navigation.PopAsync());

        public List<Pick> GetMenu()
        {
            return new List<Pick>
            {
                new Pick{Title="Plato #1", Image="IMG01.png", Description="Esta melito", Price="30 pesitos"},
                new Pick{Title="Plato #2", Image="IMG04.png", Description="Este si es muy potente", Price="Ni le va alcanzar ome"},
                new Pick{Title="Plato #3", Image="IMG05.png", Description="Este es breve", Price="¿Cuanto tiene?"}
            };
        }
    }
}
