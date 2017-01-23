using HauteLook.Shared.IOC.Types;

namespace ConsoleApplication1
{
    public static class IoC
    {
        public static void Register(IContainer container)
        {
            container.For<IContainer>().Use(container);
            container.For<IHelloWorld>().Use<HelloWorld>();
        }
    }
}