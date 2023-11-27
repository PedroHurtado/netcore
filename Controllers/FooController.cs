using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class FooController : ControllerBase
{


    
    
    private readonly IFooService service;

    public FooController(IFooService service){
        this.service = service;
    }   


    [HttpGet]
    public IActionResult GetAll([FromQuery] Query query)
    {        
        return Ok(service.GetAll(query));
    }
    [HttpPost()]
    public IActionResult Post([FromBody()] Foo foo)
    {        
        return Created("", service.Add(foo));
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id, [FromHeader(Name = "x-dni")] string dni)
    {
        return Ok(service.Get(id));
    }
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody()] FooUpdate foo)
    {
        service.Update(id, foo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(string id)
    {
        service.Remove(id);
        return NoContent();
    }

    
}
