using System.Collections;

namespace LinkedListLib;

public class MyLinkedList<T> : ICollection<T>
{
    public MyLinkedListNode<T> Head { get; private set; }
    public MyLinkedListNode<T> Tail { get; private set; }

    

    #region ICollection
    public int Count { get; private set; }

    public bool IsReadOnly { get => false; }
    public void Add(T item)
    {
        AddFirst(item);
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < array.Length; i++)
        {
            AddFirst(array[i]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        var node = Find(item);
        if (node == null)
            return false;

        return RemoveItem(node);
    }

    private MyLinkedListNode<T> Find(T? item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
    #endregion

    #region Add
    public void AddFirst(T item)
    {
        AddFirst(new MyLinkedListNode<T>(item));
    }

    private void AddFirst(MyLinkedListNode<T> node)
    {
        MyLinkedListNode<T> temp = Head; // Temp = |3|->5
        Head = node; // Head = |1|->Null
        Head.Next = temp; // Head = |1|->3->5
        Count++;
        if (Count == 1);
        Tail = Head;
    }

    public void AddLast(T item)
    {
        AddLast(new MyLinkedListNode<T>(item));
    }

    public void AddLast(MyLinkedListNode<T> node)
    {
        if (Count == 0)
            Head = node;
        else
            Tail.Next = node;

        Tail = node;

        Count++;
    }
    #endregion

    #region Remove
    public bool RemoveItem(MyLinkedListNode<T> node)
    {
        if (node == null || Head == null)
            return false;

        if (Head == node && Head == Tail)
        {
            Clear();
            return true;
        }

        if (node == Head)
        {
            Head = Head.Next;
            Count--;

            if (Count == 1)
                Tail = Head;

            return true;
        }

        MyLinkedListNode<T> temp = Head;

        while (temp.Next != null && temp.Next != node)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
            return false;

        if (node == Tail)
        {
            Tail = temp;
        }

        temp.Next = node.Next;

        Count--;

        if (Count == 1)
            Tail = Head;

        return true;
    }
    #endregion
}
