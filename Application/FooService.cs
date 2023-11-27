
namespace api.Controllers;
public class FooService :IFooService{

    private static readonly List<Foo> records = new List<Foo>();
    public FooService(){

    }

    public Foo Add(Foo foo)
    {
        records.Add(foo);
        return foo;
    }

    public Foo Get(string id)
    {
        return Read(id);
    }

    public IEnumerable<Foo> GetAll(Query query)
    {
        return records;
    }

    public void Remove(string id)
    {
        var foo = Read(id);
        records.Remove(foo);
    }

    public void Update(string id,FooUpdate fooUpdate)
    {
         var result = Read(id);
        var index = records.IndexOf(result);
        records[index] = new Foo(id, fooUpdate.name);
    }

    private Foo Read(string id){
        return records.First(v=>v.id==id, new NotFoundException());
    }
}