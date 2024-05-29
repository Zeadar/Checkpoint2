using System;

namespace Checkpoint2
{
	public class ProductQuery
	{
		Dictionary<QueryType, string> inputs = new Dictionary<QueryType, string>();
        List<ProductItem> products = new List<ProductItem>();
		
        public bool Next(QueryType type, string input)
		{
            switch (type)
			{
				case QueryType.Price:
                    
					if(int.TryParse(input, out int price))
					{
						inputs[type] = price.ToString();
                    } else
					{
                        Console.WriteLine("\"Price\" is not a number.");
						return false;
                    }
                    break;
				default:
					inputs[type] = input;
                    break;
            }

			if (type == QueryCounter.LastType)
			{
				ProductItem prod = new ProductItem(inputs[QueryType.Category], inputs[QueryType.Name], inputs[QueryType.Price]);
                products.Add(prod);
				Console.WriteLine("Entered " + prod);
			}

            return true;
		}

		public void Present() {
			Console.ForegroundColor = ConsoleColor.Green;
			foreach (ProductItem item in products) {
                Console.WriteLine(item);
            }
			Console.ResetColor();
		}
	}

}
