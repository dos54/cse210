
namespace FinalProject
{
    internal class Item
    {
        public string Id { get; set; }
        public string Tag { get; set; }

        public Item(string id)
        {
            Id = id;
        }

        public Item(string id, string tag)
        {
            Id = id;
            Tag = tag;
        }

    }
}