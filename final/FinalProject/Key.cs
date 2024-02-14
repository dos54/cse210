
namespace FinalProject
{
    internal class Key
    {
        public char Id { get; set; }
        public Ingredient Ingredient { get; set; }

        public Key(char id, Ingredient ingredient)
        {
            Id = id;
            Ingredient = ingredient;
        }
    }
}