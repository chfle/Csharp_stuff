using System.Collections.Generic;

// Hier wird ein Deque nachgebaut 
namespace DualRechner
{
    public class CppDeque<T>
    {
        // als basis wird eine Linked List verwendet
        LinkedList<T> list = new();
        
        // der tut nix
        public CppDeque() {}

        // gibt die size vom Deque
        public int count()
        {
            return list.Count;
        }

        public void push_font(T val)
        {
            list.AddFirst(val);
        }

        public void push_back(T val)
        {
            list.AddLast(val);
        }

        public void pop_back()
        {
            list.RemoveLast();
        }

        public void pop_font()
        {
            list.RemoveFirst();
        }

        public T front()
        {
            try
            {
                return list.First.Value;
            }
            catch
            {
                throw new KeyNotFoundException("Check your Deque size");
            }
        }

        public T back()
        {
            try
            {
                return list.Last.Value;
            }
            catch
            {
                throw new KeyNotFoundException("Check your Deque size");
            }
        }
    }
}