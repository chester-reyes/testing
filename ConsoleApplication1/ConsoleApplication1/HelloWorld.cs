using System;

namespace ConsoleApplication1
{
    public class HelloWorld : IHelloWorld
    {
        public void DisplayMessage()
        {
            Console.WriteLine("Hello World!!!");
            Console.ReadKey();
        }
    }
}
