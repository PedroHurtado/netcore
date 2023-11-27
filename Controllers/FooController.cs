using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class FooController : ControllerBase
{
    
    
    private static readonly List<Foo> records = new List<Foo>();
    public  record struct Foo(string id, string name);
    public readonly record struct FooUpdate(string name);
    
    public class Query{
        public string Name {get;set;} = "";
        public int Page {get;set;} =1;
        public int Size {get;set;} =25;
    };
    

    [HttpGet]
    public IActionResult GetAll([FromQuery] Query query){
        return Ok(records);
    }    
    [HttpPost()]        
    public IActionResult Post([FromBody()] Foo foo){
        records.Add(foo);
        return Created("",foo);        
    }

    [HttpGet("{id}")]        
    public IActionResult Get(string id, [FromHeader(Name ="x-dni")] string dni)
    {      
        return Ok(Read(id)); 
    }       
    [HttpPut("{id}")]
    public IActionResult Put(string id,[FromBody()] FooUpdate foo){  
        var result = Read(id);
        var index=  records.IndexOf(result);
        records[index] = new Foo(id, foo.name);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(string id){        
       var result = Read(id);
       records.Remove(result);
       return NoContent();
    }

    private Foo Read(string id){
        return records.First(v=>v.id == id,new NotFoundException());
    }
}
