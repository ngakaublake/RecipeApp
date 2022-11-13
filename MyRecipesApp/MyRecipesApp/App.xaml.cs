using MyRecipesApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRecipesApp.Data;

namespace MyRecipesApp
{
    public partial class App : Application
    {
        static RecipeDatabase database;

        public static RecipeDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new RecipeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipes.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
