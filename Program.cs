using Checkpoint2;

var query = new ProductQuery();
var queryCounter = new QueryCounter();

ProductItem productItem = new ProductItem("Category", "Name", 100) ;
Console.WriteLine(productItem);

while (true)
{
    if (query.QueryNext(queryCounter.NextType))
    {

    }
}
