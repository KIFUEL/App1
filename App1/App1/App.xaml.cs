using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Data;
using System.IO;
using App1.Vista;

namespace App1
{
    
    public partial class App : Application
    {
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new login());
        }
        public static SQLiteHelper SQLiteDB
        {

            get
            {
                if (db==null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tindersql.db3"));
                }
                return db;
            }
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
