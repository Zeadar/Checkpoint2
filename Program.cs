using Checkpoint2;

var query = new ProductQuery();

ProductItem productItem = new ProductItem("Category", "Name", 100) ;
Console.WriteLine(productItem);

while (true)
{
    query.QueryNext();
}
