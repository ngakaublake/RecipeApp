using MyRecipesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipesApp.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RecipeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<recipe>().Wait();
        }

        public Task<List<recipe>> GetRecipesAsync()
        {
            //Get all notes.
            return database.Table<recipe>().ToListAsync();
        }

        public Task<recipe> GetRecipeAsync(int id)
        {
            // Get a specific Recipe.
            return database.Table<recipe>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(recipe Recipe)
        {
            if (Recipe.ID != 0)
            {
                // Update an existing Recipe.
                return database.UpdateAsync(Recipe);
            }
            else
            {
                // Save a new Recipe.
                return database.InsertAsync(Recipe);
            }
        }

        public Task<int> DeleteRecipeAsync(recipe Recipe)
        {
            // Delete a Recipe.
            return database.DeleteAsync(Recipe);
        }
    }
}
