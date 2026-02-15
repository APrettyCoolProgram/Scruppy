// 250214_code
// 250214_documentation

namespace Scruppy.Database;

internal class Traders
{
    public string Name { get; set; }

    public Products Product { get; set; }

    internal class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Rarity { get; set; }

        public int Value { get; set; }

        public int TraderPrice { get; set; }

        public string ItemType { get; set; }

        public string IconUrl { get; set; }
    }
}