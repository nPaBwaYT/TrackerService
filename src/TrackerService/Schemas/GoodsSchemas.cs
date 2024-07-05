namespace TrackerService.Schemas;

public class GoodsSchema
{
    public int Id { set; get; }
    public string Name { set; get; }

    public GoodsSchema(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class GoodsAddSchema
{
    public string Name { set; get; }
    
    public GoodsAddSchema(string name)
    {
        Name = name;
    }
}

public class GoodsInfoSchema
{
    public string Name { set; get; }

    public GoodsInfoSchema(string name)
    {
        Name = name;
    }
}