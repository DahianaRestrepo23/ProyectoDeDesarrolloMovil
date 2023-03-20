using System;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Application.Current.UserAppTheme = OSAppTheme.Light;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
