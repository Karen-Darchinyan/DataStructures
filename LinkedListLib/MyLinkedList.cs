using System.Collections;
using System.Xml.Linq;

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
        if (Head.Value.Equals(item))
        {
            RemoveFirst();
            return true;
        }

        MyLinkedListNode<T> temp = Head;

        while(temp.Next  != null)
        {
            if(temp.Next.Value.Equals(item))
            {
                if (temp.Next == Tail)
                {
                    RemoveLast();
                    return true;
                }

                temp.Next = temp.Next.Next;
                Count--;
                return true;
            }
            temp = temp.Next;
        }

        return false;
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
    public void RemoveFirst()
    {
        if (Count == 0)
            throw new InvalidOperationException("The list is empty.");

        Head = Head.Next;
        Count--;

        if(Count == 1)
            Tail = Head;
    }

    public void RemoveLast()
    {
        if(Count == 0)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        if(Count == 1)
        {
            Head = null;
            Tail = null;
            Count = 0;
            return;
        }

        MyLinkedListNode<T> node = Head;
        while(node.Next != Tail )
        {
            node = node.Next;
        }
        node.Next = null;
        Tail = node;
        Count--;
    }
    #endregion
}
