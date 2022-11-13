using MyRecipesApp.Views;
using Xamarin.Forms;


namespace MyRecipesApp
{
    public partial class AppShell : Shell
    {   
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipeEntryPage), typeof(RecipeEntryPage));
        }
    }
}