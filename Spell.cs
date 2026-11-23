using System.Text;

namespace SpellShop
{
    internal class Spell
    {
        //properties
        private string requiredIngredient; //hidden from player

        public string Name { get; private set; }
        public int EnergyCost { get; private set; }
        public bool IsRequested { get; set; }

        //constructors
        public Spell(string name, string requiredIngredient, int energyCost)
        {
            Name = name;
            this.requiredIngredient = requiredIngredient;
            EnergyCost = energyCost;
            IsRequested = false;
        }

        //methods
        public string Request()
        {
            IsRequested = true;
            return $"A customer wants {Name}";
        }

        public string Cast(Ingredient ingredient)
        {
            if (!IsRequested)
            {
                return $"Nobody asked for {Name}";
            }

            if (ingredient.Name.ToLower() == requiredIngredient.ToLower())
            {
                IsRequested = false;
                return $"You cast {Name} with {ingredient.Name}. The customer left happy";
            }

            return $"The {ingredient.Name} does nothing useful. {Name} fizzles.";
        }

        public override string ToString()
        {
            string state = "-";
            if (IsRequested)
            {
                state = "WANTED";
            }
            return $"{Name, -16} {state, -8} {EnergyCost} energy";
        }
    }
}