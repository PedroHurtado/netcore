namespace api.Controllers;
public interface IFooService{
    public Foo Add(Foo foo);
    public void Update(string id,FooUpdate fooUpdate);
    public void Remove(string id);

    public Foo Get(string id);

    public IEnumerable<Foo> GetAll(Query query);
}