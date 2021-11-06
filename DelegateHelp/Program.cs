using System;

namespace DelegateHelp
{
    class Program
    {
        // Help to understand delegates.
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates


        // Creates a delegate with a parameter type of string.
        public delegate void Del(string message);

        // Creates a method with a parameter of type string, and prints out the string in the console.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        // Creates a method with two int parameter and a parameter withe the type of Del and is a delegate with a strin parameter.
        // The method executes/invokes the callback delegate with the int parameters in.
        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }

        static void Main(string[] args)
        {

            // Instantiate the Del delegate.
            Del handler = DelegateMethod;

            // Executes MethodWithCallback method.
            MethodWithCallback(1, 2, handler);

            Console.WriteLine("Hello World!");
        }
    }
}
