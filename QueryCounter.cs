namespace Checkpoint2
{
    enum QueryType
    {
        Category,
        Name,
        Price,
    }
    class QueryCounter
    {
        QueryType[] queryTypes = [QueryType.Category, QueryType.Name, QueryType.Price];
        int index = -1;

        public QueryType NextType { get
            {
                index = (index + 1) % queryTypes.Length;
                return queryTypes[index];
            } 
        }

        public QueryType LastType { get
            {
                return queryTypes.Last();
            } 
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
