using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.RecipeCreatorModules
{
   public class ComboBoxItem
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ComboBoxItem(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
