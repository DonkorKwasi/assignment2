using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
namespace assignment2
{
    public partial class App : Application
    {

        static DatabaseManager database;
        public static DatabaseManager Database
        {
            get
            {
                if(database == null)
                {
                    database = new DatabaseManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "anime.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            List<AnimeDisplay> l = null;
           
            MainPage = new NavigationPage(new MainPage(l));
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
