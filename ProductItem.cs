namespace Checkpoint2
{
    class ProductItem(string category, string name, string price)
    {
        public string Category { get; set; } = category;
        public string Name { get; set; } = name;
        public string Price { get; set; } = price;

        public override string ToString()
        {
            //Price padding is need for consistency in background color
            //when presenting the table.
            return Category.PadRight(25) + Name.PadRight(25) + Price.PadRight(25);
        }
    }
}
