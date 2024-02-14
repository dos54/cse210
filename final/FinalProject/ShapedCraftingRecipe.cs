
using System.Text.Json.Nodes;

namespace FinalProject
{
    internal class ShapedCraftingRecipe : Recipe
    {
        public ShapedCraftingRecipe(string pattern, List<Key> keys, Item resultItem, int resultAmount) : base(resultItem, resultAmount)
        {
            Pattern = pattern;
            Keys = keys;
        }

        private string _pattern;
        public override string Type { get; } = "crafting_shaped";
        public string Pattern
        { 
            get => _pattern; 
            set 
            {
                if (value.Length != 9)
                {
                    throw new ArgumentException("Pattern must contain exactly 9 characters");
                }
                _pattern = value;
            } 
        }
        public List<Key> Keys { get; set; }

        public override string GetJsonString()
        {
            // Format the pattern and turn it into a JSON array
            List<string> parsedPattern = new()
            {
                $"{Pattern[0]}{Pattern[1]}{Pattern[2]}",
                $"{Pattern[3]}{Pattern[4]}{Pattern[5]}",
                $"{Pattern[6]}{Pattern[7]}{Pattern[8]}"
            };
            
            var patternJsonArray = new JsonArray();
            foreach (string line in parsedPattern)
            {
                patternJsonArray.Add(line);
            }

            // Format the key
            var keyJsonObject = new JsonObject();
            foreach (Key key in Keys)
            {
                if (key.Ingredient.HasSubstitutes)
                {
                    var substitutesArray = new JsonArray();
                    foreach (var substitute in key.Ingredient.Substitutes)
                    {
                        var substituteObject = new JsonObject() 
                        {
                            ["item"] = JsonValue.Create(substitute.Id)
                        };
                        substitutesArray.Add(substituteObject);
                    }
                    keyJsonObject.Add(key.Id.ToString(), substitutesArray);
                }
                else
                {
                    keyJsonObject.Add(key.Id.ToString(), new JsonObject
                    {
                        { "item", key.Ingredient.Item.Id }
                    });
                }
            }

            // Create the JSON object
            var jsonObject = new JsonObject
            {
                { "type", Type },
                { "pattern", patternJsonArray },
                { "key", keyJsonObject},
                { "result", new JsonObject
                {
                    { "item", ResultItem.Id },
                    { "count", ResultAmount }
                }}
            };
            return jsonObject.ToString();
        }
    }
}