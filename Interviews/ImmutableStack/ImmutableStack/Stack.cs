using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableStack
{
    /*
     * Steven
         * Brianna +1
         * Abenezer
         * Bright
         * Kalin + 1
         * Sam
         * Ethan
         * Josh
         * Michael
         * Clark +1
         * John
         * Darby
         * Matthew + 1
         */
    public class Stack
    {
        private object? Value { get;} 
        private Stack? Next { get; }

        internal Stack(object? value, Stack? next)
        {
            this.Value = value;
            this.Next = next;
        }

        protected Stack()
        {

        }
        
        public virtual Stack Push(object? obj)
        {
            return new Stack(obj, this);
        }

        public virtual Stack? Pop()
        {
            if (this.Next == null)
            {
                return EmptyStack.Instance;
            }
            return Next;
        }

        public virtual object? Peek()
        {
            return Value;
        }

        public virtual bool IsEmpty
        {
            get { return false; }
        }
       
    }
}
