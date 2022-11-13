using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRecipesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(itemId), nameof(itemId))]
    public partial class RecipeEntryPage : ContentPage
    {
        public String itemId
        {
            set
            {
                LoadRecipe(value);
            }
            
        }
        public RecipeEntryPage()
        {
            InitializeComponent();
            BindingContext = new recipe();
        }
        async void LoadRecipe(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                //retrieve recipe -> set as binding context for page
                recipe Recipe = await App.Database.GetRecipeAsync(id);
                BindingContext = Recipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to Load Recipe.");
            }
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var Recipe = (recipe)BindingContext;

            if(!string.IsNullOrEmpty(Recipe.Name))
            {
                //save the recipe
                await App.Database.SaveRecipeAsync(Recipe);
            }
            //navigate back
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var Recipe = (recipe)BindingContext;

            //delete the recipe
            await App.Database.DeleteRecipeAsync(Recipe);

            //navigate back
            await Shell.Current.GoToAsync("..");
        }
    }
}