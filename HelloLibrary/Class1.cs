using System;

namespace HelloLibrary
{
    public class HelloClass
    {
        public void WriteHello()
        {
            WriteHello("Hello");
        }

        public void WriteHello(string helloString)
        {
            Console.WriteLine(helloString);
        }

        public string GetHelloString()
        {
            return "Hello";
        }
    }
}
