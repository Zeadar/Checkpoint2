namespace Checkpoint2
{
    class ProductItem(string category, string name, string price)
    {
        public string Category { get; set; } = category;
        public string Name { get; set; } = name;
        public String Price { get; set; } = price;

        public override string ToString()
        {
            return Category.PadRight(10) + Name.PadRight(10) + Price;
        }
    }
}
