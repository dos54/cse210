using System.Text.Json.Nodes;

namespace FinalProject
{
    public class MCMeta
    {
        public MCMeta(int packFormat, string description)
        {
            PackFormat = packFormat;
            Description = description;
        }
        public int PackFormat { get; set; }
        public string Description { get; set; }

        public string GetJsonString()
        {
            var jsonObject = new JsonObject
            {
                ["pack"] = new JsonObject
                    {
                        ["pack_format"] = PackFormat,
                        ["description"] = Description
                    }
            };
            return jsonObject.ToString();
        }
    }
}