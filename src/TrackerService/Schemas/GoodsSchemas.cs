using TrackerService.Models;

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
    public Goods conv()
    {
        Goods _product = new Goods();
        _product.Name = Name;
        return _product;
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