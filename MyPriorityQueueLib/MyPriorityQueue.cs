using LinkedListLib;
using System.Collections;

namespace MyPriorityQueueLib;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> _items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The Stak is empty");
        
        T value = _items.Head.Value;

        _items.RemoveFirst();

        return value;
    }

    public T Peak()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The Stak is empty");
        return _items.Head.Value;
    }

    public int Count
    {  
        get
        { 
            return _items.Count; 
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
