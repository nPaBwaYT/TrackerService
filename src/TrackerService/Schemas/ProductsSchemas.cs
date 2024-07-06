using TrackerService.Models;

namespace TrackerService.Schemas;

public class ProductSchema
{
    public long Id { set; get; }
    public string Name { set; get; }

    public ProductSchema(long id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class ProductAddSchema
{
    public string Name { set; get; }
    
    public ProductAddSchema(string name)
    {
        Name = name;
    }
    public Products conv()
    {
        Products _product = new Products();
        _product.Name = Name;
        return _product;
    }
}

public class ProductInfoSchema
{
    public string Name { set; get; }

    public ProductInfoSchema(string name)
    {
        Name = name;
    }
}