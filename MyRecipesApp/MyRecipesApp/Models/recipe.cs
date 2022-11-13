using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyRecipesApp.Models
{
    public class recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string Ingredients { get; set; }
        public string StepsNotes { get; set; }
        public string ImageUrl { get; set; }
    }
}
