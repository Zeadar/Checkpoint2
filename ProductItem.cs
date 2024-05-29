﻿namespace Checkpoint2
{
    class ProductItem(string category, string name, int price)
    {
        public string Category { get; set; } = category;
        public string Name { get; set; } = name;
        public int Price { get; set; } = price;

        public override string ToString()
        {
            return Category.PadRight(10) + Name.PadRight(10) + Price;
        }
    }
}