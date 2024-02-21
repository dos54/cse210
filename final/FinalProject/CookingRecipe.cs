using System;
using System.Text.Json.Nodes;

namespace FinalProject
{
    internal class CookingRecipe : Recipe
    {
        public CookingRecipe(Ingredient ingredient, Item resultItem, int resultAmount, float experience) : base(resultItem, resultAmount)
        {
            Ingredient = ingredient;
            Experience = experience;
        }

        public override string Type { get; } = "smelting";
        public Ingredient Ingredient { get; set; }
        public Item Result { get; set; }
        public float Experience { get; set; }
        public virtual int CookingTime { get; set; } = 200;

        public override string GetJsonString()
        {
            var ingredientsJsonArray = new JsonArray();
            
            
            if (Ingredient.HasSubstitutes)
            {
                foreach (var substitute in Ingredient.Substitutes)
                {
                    var substituteObject = new JsonObject
                    {
                        ["item"] = JsonValue.Create(substitute.Id)
                    };
                    ingredientsJsonArray.Add(substituteObject);
                }
            }
            else
            {
                var itemObject = new JsonObject
                {
                    ["item"] = JsonValue.Create(Ingredient.Item.Id)
                };
                ingredientsJsonArray.Add(itemObject);
            }
            
            var jsonObject = new JsonObject()
            {
                { "type", Type },
                { "ingredient", ingredientsJsonArray},
                { "result", new JsonObject{
                    {"item", ResultItem.Id},
                    {"count", ResultAmount}
                }},
                { "experience", Experience},
                {"cookingtime", CookingTime}
            };
            return jsonObject.ToString();
        }
    }
}