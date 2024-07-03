using Microsoft.AspNetCore.Mvc;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
public class GoodsApiController
{
    [HttpGet(nameof(Get))]
    public int Get(int id)
    {
        return id;
    }
}