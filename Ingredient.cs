using System.Collections.Generic;
using System.Text;

namespace SpellShop
{
    internal class Ingredient
    {
        //properties
        public string Name { get; private set; }
        public string Description { get; private set; }

        //constructors
        public Ingredient(string name, string description)
        {
            Name = name;
            Description = description;
        }

        //methods
        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}