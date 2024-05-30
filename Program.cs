using Checkpoint2;

var messages = new Dictionary<QueryType, string>()
        {
            { QueryType.Category, "Enter Category: > ".PadLeft(25)},
            { QueryType.Name, "Enter Product Name: > ".PadLeft(25) },
            { QueryType.Price, "Enter Price: > ".PadLeft(25) },
        };
var query = new ProductQuery();
var queryCounter = new QueryCounter();

Start();

void Start()
{
    queryCounter.Reset();
    Console.WriteLine("Enter category, product name and price. Enter \"q\" to view products.");
    while (true)
    {
        var type = queryCounter.NextType;
        ColorWriter.Yellow(messages[type]);
        string input = Console.ReadLine() ?? "";

        if (input.Trim().ToUpper() == "Q")
        {
            break;
        }

        if(!query.Enter(type, input)){
            queryCounter.Reset();
        }
    }

    Console.WriteLine("You have entered the following products:");
    query.Present();
    Quit();
}

void Quit()
{
    Console.WriteLine();
    Console.WriteLine("Enter \"c\" to continue adding products.");
    Console.WriteLine("Enter \"s\" to search in the table.");
    Console.WriteLine("Enter \"q\" again to quit.");
    ColorWriter.Yellow("[c], [s] or [q] > ".PadLeft(25));

    string input = Console.ReadLine() ?? "";
    if (input.Trim().Equals("c", StringComparison.CurrentCultureIgnoreCase))
    {
        Start();
    }
    if (input.Trim().Equals("s", StringComparison.CurrentCultureIgnoreCase))
    {
        Search();
    }
    if (input.Trim().Equals("q", StringComparison.CurrentCultureIgnoreCase))
    {
        Environment.Exit(0);
    }

    Quit();
}

void Search()
{
    ColorWriter.Yellow("Enter search term > ".PadLeft(25));
    string input = Console.ReadLine() ?? "";
    if (input.Length == 0)
    {
        ColorWriter.RedLine("Search term can't be empty.");
        Search();
    }
    if (input.Trim().ToUpper() == "Q")
    {
        Quit();
        return;
    }
    query.Present(input);
    Search();
}