
using System.Text.Json.Nodes;

namespace FinalProject
{
    internal class ShapelessCraftingRecipe : Recipe
    {
        public override string Type { get; } = "crafting_shapeless";
        public List<Ingredient> Ingredients { get; set; }

        public ShapelessCraftingRecipe(List<Ingredient> ingredients, Item resultItem, int resultAmount) : base(resultItem, resultAmount)
        {
            Ingredients = ingredients;
        } 

        public override string GetJsonString()
        {
            var ingredientsJsonArray = new JsonArray();
            foreach (Ingredient ingredient in Ingredients)
            {
                if (ingredient.HasSubstitutes)
                {
                    var substitutesArray = new JsonArray();
                    foreach (var substitute in ingredient.Substitutes)
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
                        ["item"] = JsonValue.Create(ingredient.Item.Id)
                    };
                    ingredientsJsonArray.Add(itemObject);
                }
            }

            var jsonObject = new JsonObject
            {
                { "type", Type },
                { "ingredients", ingredientsJsonArray},
                { "result", new JsonObject{
                    {"item", ResultItem.Id},
                    {"count", ResultAmount}
                }}
                
            };
            

            return jsonObject.ToString();
        }
    }
}