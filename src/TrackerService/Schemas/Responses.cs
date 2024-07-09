using Microsoft.AspNetCore.Mvc;

namespace TrackerService.Schemas;


public class Response : ObjectResult
{
    public Response(string phrase, int code) : base(new { message = phrase }) { StatusCode = code; }
}


public class EntityDoesNotExistResponse: Response
{
    public EntityDoesNotExistResponse() : base("Entity does not exist", 400) {}
}

public class OrderAlreadyCompletedResponse: Response
{
    public OrderAlreadyCompletedResponse() : base("Order is already completed", 400) {}
}

public class InvalidStringInputResponse: Response
{
    public InvalidStringInputResponse() : base("Field of type <string> must not be empty or start with a space", 400) {}
}

public class AuthErrorResponse: Response
{
    public AuthErrorResponse() : base("Incorrect email or password", 400) {}
}
