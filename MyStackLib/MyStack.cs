using LinkedListLib;
using System.Collections;

namespace MyStackLib
{
    public class MyStack<T> : IEnumerable<T>
    {
        private MyLinkedList<T> _list = new MyLinkedList<T>();

        public int Count { get { return _list.Count; } }
        public void Push(T item)
        {
            _list.AddFirst(item);
        }
        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("The Stak is empty");
            return _list.Head.Value;
        }
        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("The Stak is empty");
            T top = _list.Head.Value;
            _list.RemoveFirst();
            return top;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
