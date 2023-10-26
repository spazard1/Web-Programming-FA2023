using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableStack
{
    public class EmptyStack : Stack
    {

        public static readonly Stack Instance = new EmptyStack();

        private EmptyStack()
        {
            
        }

        public override Stack Push(object? obj)
        {
            return new Stack(obj, null);
        }

        public override Stack? Pop()
        {
            throw new InvalidOperationException("Tried to call pop on an empty stack.");
        }

        public override bool IsEmpty
        {
            get { return true; }
        }

        public override object? Peek()
        {
            throw new InvalidOperationException("Tried to call peek on an empty stack.");
        }

    }
}
