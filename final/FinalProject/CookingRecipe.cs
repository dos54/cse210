using System;

namespace FinalProject
{
    internal class CookingRecipe : Recipe
    {
        public CookingRecipe(Ingredient ingredient, Item resultItem, int resultAmount, float experience) : base(resultItem, resultAmount)
        {
            Ingredient = ingredient;
            Experience = experience;
        }

        public override string Type { get; } 
        public Ingredient Ingredient { get; set; }
        public Item Result { get; set; }
        public float Experience { get; set; }
        public virtual int CookingTime { get; set; } = 200;

        public override string GetJsonString()
        {
            throw new NotImplementedException();
        }
    }
}