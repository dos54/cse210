namespace FinalProject
{
    public class RecipeManager
    {

        public MCMeta MCMeta { get; set; } = new(26, "A data pack");
        public PackBuilder packBuilder = new();

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Please name your data pack");
            Console.Write("> ");
            string packName = Console.ReadLine();
            packBuilder.DataPackName = packName;
            packBuilder.MCMeta = new MCMeta(26, "A data pack");
            packBuilder.BuildPack();
            Menu menu = new();
            menu.AddOption("Add shapeless crafting recipe", AddShapelessCraftingRecipe);

            menu.Run();
        }

        public void AddShapelessCraftingRecipe()
        {
            List<Ingredient> ingredients = new();
            
            Console.WriteLine("-- Shapeless Crafting Recipe --");
            Console.WriteLine("Please enter the name of this recipe");
            Console.Write("> ");
            string recipeName = Console.ReadLine();

            while (true)
            {
                //Get any ingredients
                Console.Clear();
                Console.WriteLine("-- Shapeless Crafting Recipe --");
                Console.WriteLine("Please enter the item ID of your ingredient");
                Console.WriteLine("Leave input empty to finish inputting ingredients");
                Console.Write("> ");
                string input = Console.ReadLine();
                
                if (input.Trim() == "")
                {
                    break;
                }
                Item newItem = new(input);
                List<Item> substitutes = new();
                //Ask about any substitutes
                while (true)
                {
                    //On each loop, get substitutes, turn them into items, then add it to the substitutes list.
                    Console.WriteLine("Please input any substitutes");
                    Console.WriteLine("Once you are done inputting subsitutes, leave line empty and press enter");
                    Console.Write("> ");
                    string substituesInput = Console.ReadLine();
                    if (substituesInput.Trim() == "")
                    {
                        break;
                    }
                    substitutes.Add(new Item(substituesInput));
                }

                Ingredient ingredient = new(newItem)
                {
                    Substitutes = substitutes
                };
                ingredients.Add(ingredient);
            }
            Console.WriteLine("Please input the item that is crafted");
            Console.Write("> ");
            string resultItemInput = Console.ReadLine();
            Item resultItem = new(resultItemInput);
            Console.WriteLine("Please input the number of items created");
            Console.Write("> ");
            int resultItemAmount = int.Parse(Console.ReadLine());

            ShapelessCraftingRecipe shapelessCraftingRecipe = new(ingredients: ingredients, resultItem: resultItem, resultAmount: resultItemAmount);

            packBuilder.AddRecipe(recipeName, shapelessCraftingRecipe.GetJsonString());

        }

    }

}