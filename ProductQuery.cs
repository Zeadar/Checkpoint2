using System;

namespace Checkpoint2
{
	public class ProductQuery
	{
		List<ProductItem> products = new List<ProductItem>();
		QueryCounter queryCounter = new QueryCounter();
        string? currentCategory;
        string? currentName;
        int? currentPrice;
        public void QueryNext()
		{

            QueryType type = queryCounter.NextType;
            switch (type)
			{
				case QueryType.Category:
					Console.Write("Enter Category: > ");
					currentCategory = Console.ReadLine() ?? "";
					break;
				case QueryType.Name:
                    Console.Write("Enter Product Name: > ");
					currentName = Console.ReadLine() ?? "";
					break;
				case QueryType.Price:
                    Console.Write("Enter Price: > ");
					if(int.TryParse(Console.ReadLine() ?? "0", out int price))
					{
                        currentPrice = price;
                    } else
					{
                        Console.WriteLine("\"Price\" is not a number.");
                        queryCounter.Reset();
                    }
                    break;
					
			}

			if (type == queryCounter.LastType)
			{
				products.Add(new ProductItem(currentCategory, currentName, (int)currentPrice));
			}
		}

		public void Present() {
			foreach (ProductItem item in products) {
                Console.WriteLine(item);
            }
		}
	}

}
