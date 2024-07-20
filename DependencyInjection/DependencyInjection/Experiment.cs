namespace DependencyInjection
{
    public class MyOwnServiceProvider : IServiceProvider
    {
        public object GetService(Type a)
        {
            return new ServiceDescriptor();
        }
    }


    // i am thinking why don't we just provide an object of service provider to framework
}
