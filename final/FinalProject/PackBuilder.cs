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
            Directory.CreateDirectory($"{namespaceDir}\\recipes");
            Directory.CreateDirectory($"{namespaceDir}\\tags");


        }
    }
}