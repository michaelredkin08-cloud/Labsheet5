using System;
using System.Collections.Generic;
using System.Text;

namespace SpellShop
{
    internal class Wizard
    {
        //properties
        private List<Ingredient> satchel = new List<Ingredient>();

        public string Name { get; private set; }
        public int MaxIngredients { get; private set; }

        public int IngredientCount
        {
            get
            {
                return satchel.Count;
            }
        }

        private int energy = 0;
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else if (value > 100)
                {
                    energy = 100;
                }
                else
                {
                    energy = value;
                }
            }
        }

        //constructors
        public Wizard(string name, int maxIngredients, int energy)
        {
            Name = name;
            MaxIngredients = maxIngredients;
            Energy = energy;
        }

        //methods

        //Returns false is satchel is already full
        public bool PickUp(Ingredient ingredient)
        {
            if (satchel.Count >= MaxIngredients)
            {
                return false;
            }
            satchel.Add(ingredient);
            return true;
        }

        //Returns the ingredient, or null if the wizard isn't carrying it
        public Ingredient FindIngredient(string ingredientName)
        {
            foreach (Ingredient ingredient in satchel)
            {
                if (ingredient.Name.ToLower() == ingredientName.ToLower())
                {
                    return ingredient;
                }
            }
            return null;
        }

        //Private: only the wizard spends energy
        //Return false an spend nothing if there is not enough energy
        private bool SpendEnergy(int amount)
        {
            if (amount > Energy)
            {
                return false;
            }

            Energy = Energy - amount;
            return true;
        }

        //The wizard casts the spell, it costs energy
        //Any attempt costs energy, whether the spell works or fizzles
        public string Cast(Spell spell, Ingredient ingredient)
        {
            if (!spell.IsRequested)
            {
                return $"Nobody asked for {spell.Name}";
            }

            if (!SpendEnergy(spell.EnergyCost))
            {
                return $"You are too tired to cast {spell.Name}. It requires {spell.EnergyCost} energy";
            }

            return spell.Cast(ingredient);
        }

        //Remove an ingredient
        public Ingredient Drop(string ingredientName)
        {
            Ingredient ingredient = FindIngredient(ingredientName);

            if (ingredient != null)
            {
                satchel.Remove(ingredient);
            }
            return ingredient;
        }

        public void Rest(int amount)
        {
            Energy = Energy + amount;
        }

        public void ShowSatchel()
        {
            Console.WriteLine($"{Name}'s satchel ({satchel.Count}/{MaxIngredients}), energy {Energy}");
            foreach (Ingredient ingredient in satchel)
            {
                Console.WriteLine($"  {ingredient}");
            }
        }
    }
}