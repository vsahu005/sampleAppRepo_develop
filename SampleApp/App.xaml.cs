using System;
using SampleApp.IOCContainer;
using SampleApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitDefaults();
            MainPage = new NavigationPage(new MusicFormPage());
        }

        private void InitDefaults()
        {
            IocRegisterer.Init();
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
