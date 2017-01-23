using HauteLook.Shared.IOC;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ContainerFactory().Create();
            IoC.Register(container);

            var hw = container.Resolve<IHelloWorld>();
            hw.DisplayMessage();
        }
    }
}
