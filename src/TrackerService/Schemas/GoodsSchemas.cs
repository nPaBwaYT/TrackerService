namespace TrackerService.Schemas;

public class GoodsSchema
{
    public int id { set; get; }
    public string name { set; get; }

    public GoodsSchema(int _id, string _name)
    {
        id = _id;
        name = _name;
    }
}

public class GoodsAddSchema
{
    public string name { set; get; }
    
    public GoodsAddSchema(string _name)
    {
        name = _name;
    }
}

public class GoodsInfoSchema
{
    public string name { set; get; }

    public GoodsInfoSchema(string _name)
    {
        name = _name;
    }
}