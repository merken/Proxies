namespace LoggerProxy.App
{
    public interface IFooService
    {
        string Foo();
    }

    public class FooService : IFooService
    {
        public string Foo()
        {
            return "bar";
        }
    }
}