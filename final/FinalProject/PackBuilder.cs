namespace FinalProject
{
    public class PackBuilder
    {
        private string _path = Directory.GetCurrentDirectory();
        public string DataPackName { get; set; }
        public MCMeta MCMeta { get; set; }
        public void BuildPack()
        {
            string rootDirectory = $"{_path}\\{DataPackName}";
            Directory.CreateDirectory(rootDirectory);
            File.WriteAllText($"{rootDirectory}\\pack.mcmeta", MCMeta.GetJsonString());
            Directory.CreateDirectory($"{rootDirectory}\\data");
            string namespaceDir = $"{rootDirectory}\\data\\{DataPackName}";
            Directory.CreateDirectory(namespaceDir);
            string recipesDir = $"{namespaceDir}\\recipes";
            Directory.CreateDirectory(recipesDir);
            Directory.CreateDirectory($"{namespaceDir}\\tags");


        }

        public void AddRecipe(string fileName, string recipeAsJson) 
        {
            string recipesDir = $"{_path}\\{DataPackName}\\data\\{DataPackName}\\recipes";
            File.WriteAllText($"{recipesDir}\\{fileName}.json", recipeAsJson);
        }
    }
}