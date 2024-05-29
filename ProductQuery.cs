using System;

namespace Checkpoint2
{
	public class ProductQuery
	{
		public static readonly Dictionary<QueryType, string> messages = new Dictionary<QueryType, string>()
		{
			{ QueryType.Category,  "Enter Category: > "},
			{ QueryType.Name, "Enter Product Name: > " },
			{ QueryType.Price, "Enter Price: > " },
		};
		Dictionary<QueryType, string> inputs = new Dictionary<QueryType, string>();
        List<ProductItem> products = new List<ProductItem>();
		
        public bool QueryNext(QueryType type, string input)
		{
			if (input.Trim().ToUpper() == "Q")
			{
				return false;
			}

            switch (type)
			{
				case QueryType.Price:
                    
					if(int.TryParse(input, out int price))
					{
                        inputs.Add(type, price.ToString());
                    } else
					{
                        Console.WriteLine("\"Price\" is not a number.");
						return false;
                    }
                    break;
				default:
                    inputs.Add(type, input);
					break;
            }

            return true;
		}

		public void Present() {
			foreach (ProductItem item in products) {
                Console.WriteLine(item);
            }
		}
	}

}
