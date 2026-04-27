using LinkedListLib;
using System.Collections;

namespace MyQueueLib;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> _items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    public T[] ArrayEnqueue(T[] array, T item)
    {
        int lenght = 4;
        while (array.Length >= lenght)
            lenght *= 4;
        T[] newArray = new T[lenght];
        
        for(int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[array.Length] = item; 

        return newArray;
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The Stak is empty");
        
        T value = _items.Head.Value;

        _items.RemoveFirst();

        return value;
    }

    // այստեղ կարելի է օգտագործել նաև tuple
    public T ArrayDequeue(T[] array, out T[] newArray)
    {
        if (array.Length == 0)
            throw new InvalidOperationException("Queue is empty");

        int lenght = 4;
        while (array.Length - 1 >= lenght)
            lenght *= 4;

        T item = array[0];
        newArray = new T[lenght];

        for (int i = 1; i < array.Length; i++)
        {
            newArray[i - 1] = array[i];
        }

        return (item);
    }

    public T Peak()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The Stak is empty");
        return _items.Head.Value;
    }

    public T ArrayPeak(T[] array)
    {
        if(array.Length == 0)
            throw new InvalidOperationException("Queue is empty");
        return array[0];
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
