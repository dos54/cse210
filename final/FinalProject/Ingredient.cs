
namespace FinalProject
{
    internal class Ingredient
    {
        public Item Item { get; set; }
        public List<Item> Substitutes { get; set; } = new List<Item>();

        // IsSingleItem returns true if Substitutes == null or 0
        public bool HasSubstitutes => !(Substitutes == null || Substitutes.Count == 0);

        public Ingredient(Item item)
        {
            Item = item;
        }

        public Ingredient(List<Item> substitutes)
        {
            if (substitutes != null && substitutes.Count > 0)
            {
                Item = substitutes[0];
                Substitutes = substitutes;
            }
        } 
    }
}