namespace ImmutableStack
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Stack stack = EmptyStack.Instance;
            stack = stack.Push("hi");
            stack = stack.Push("hello");
            stack = stack.Push("hola");
            while (!stack.IsEmpty)
            {
                Console.WriteLine(stack.Peek());
                stack = stack.Pop();
            }
            Console.ReadLine();
        }
    }
}