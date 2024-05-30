namespace Checkpoint2
{
	public class ProductQuery
	{
		Dictionary<QueryType, string> inputs = new Dictionary<QueryType, string>();
        List<ProductItem> products = new List<ProductItem>();
		
        public bool Enter(QueryType type, string input)
		{

            if (input.Length > 20)
            {
                ColorWriter.RedLine($"{type} field can not have more than 20 characters");
                return false;
            }

            if (input.Length == 0)
            {
                ColorWriter.RedLine($"{type} field can not be empty");
                return false;
            }

            switch (type)
			{
				case QueryType.Price:
					if(int.TryParse(input, out int price))
					{
						inputs[type] = price.ToString();
                    } else
					{
                        ColorWriter.RedLine($"\"{input}\" is not a number.");
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
				ColorWriter.GreenLine("Entered\n" + prod);
			}

            return true;
		}

		public void Present(string highlight) {
			if (products.Count == 0)
			{
				ColorWriter.RedLine("No products entered");
				return;
			}

            products.Sort((a, b) => int.Parse(a.Price).CompareTo(int.Parse(b.Price)));
			int sum = products.Select((prod) => int.Parse(prod.Price)).Sum();

			ColorWriter.GreenLine("Category".PadRight(25) + "Name".PadRight(25) + "Price".PadRight(25));

            foreach (ProductItem item in products) {
				string line = item.ToString();
				if (highlight.Length != 0 && line.ToUpper().Contains(highlight.ToUpper()))
				{
					int start = line.ToUpper().IndexOf(highlight.ToUpper());
					int end = start + highlight.Length;

					for (int i = 0; i != line.Length; ++i)
					{
						if (i >= start && i < end)
						{
							Console.BackgroundColor = ConsoleColor.White;
							Console.ForegroundColor = ConsoleColor.DarkBlue;
						} else
						{
							Console.BackgroundColor = ConsoleColor.DarkBlue;
							Console.ForegroundColor = ConsoleColor.White;
						}
						Console.Write(line[i]);
                        Console.ResetColor();
                    }
                    Console.ResetColor();
                    Console.Write("\n");
				} else
				{
					ColorWriter.MatrixLine(line);
                }
            }
			ColorWriter.GreenLine("Sum: ".PadLeft(50) + sum);

            if (highlight.Length != 0)
            {
                string everything = products.Select(p => p.ToString()).Aggregate(string.Concat);
                if (!everything.ToUpper().Contains(highlight.ToUpper()))
                {
                    ColorWriter.RedLine("Your search term was not found.");
                }
            }
        }

		public void Present()
		{
			Present("");
		}
	}

}
