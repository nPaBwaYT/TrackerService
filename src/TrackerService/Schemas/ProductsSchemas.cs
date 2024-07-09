using System.ComponentModel.DataAnnotations;
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
    [Required]
    public string Name { set; get; }
    
    public ProductAddSchema(string name)
    {
        Name = name;
    }
    public Product ToModel()
    {
        Product _product = new Product();
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