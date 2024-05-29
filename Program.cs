using Checkpoint2;

var messages = new Dictionary<QueryType, string>()
        {
            { QueryType.Category, "Enter Category: > "},
            { QueryType.Name, "Enter Product Name: > " },
            { QueryType.Price, "Enter Price: > " },
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
        Console.Write(value: messages[type]);
        string input = Console.ReadLine() ?? "";

        if (input.Trim().ToUpper() == "Q")
        {
            break;
        }

        if(!query.Next(type, input)){
            queryCounter.Reset();
        }
    }
    Console.WriteLine("You have entered the follow products:");
    Console.WriteLine("Category".PadRight(10) + "Name".PadRight(10) + "Price");
    query.Present();
    Console.WriteLine("Would you like to continue entering products?");
    Console.Write("(y/n) > ");
    string restart = Console.ReadLine() ?? "";
    if (restart.Trim().ToUpper() == "Y")
    {
        Start();
    }
}