using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapedCraftingRecipe shapedCraftingRecipe = new ShapedCraftingRecipe(
                "TTT#X##R#",
                new List<Key>(){
                    new Key('R', new Ingredient(new Item("minecraft:redstone"))),
                    new Key('T', new Ingredient(new Item("minecraft:oak_planks"))),
                    new Key('X', new Ingredient(new Item("minecraft:iron_ingot"))),
                    // For '#' key, include cobblestone, netherrack, and deepslate as substitutes
                    new Key('#', new Ingredient(new List<Item>{
                        new Item("minecraft:cobblestone"),
                        new Item("minecraft:netherrack"),
                        new Item("minecraft:deepslate")
                    })),
                },
                new Item("minecraft:piston"),
                1
            );

            MCMeta mCMeta = new MCMeta(26, "A data pack");
            PackBuilder packBuilder = new();
            packBuilder.MCMeta = mCMeta;
            packBuilder.DataPackName = "testPack";
            packBuilder.BuildPack();

            File.WriteAllText("test.json", shapedCraftingRecipe.GetJsonString());
        }
    }
}