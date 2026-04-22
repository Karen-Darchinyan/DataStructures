using LinkedListLib;

MyLinkedList<int> list = new MyLinkedList<int>();

list.Add(6);
list.Add(8);
list.Add(10);
list.Add(12);

Console.WriteLine("Initial linked list is:  ");
foreach(var item in list)
{
    Console.WriteLine(item);
}

list.Add(14);
Console.WriteLine("Linked list after adding 14:");
foreach(var item in list)
{
    Console.WriteLine(item);
}

list.Remove(6);
Console.WriteLine("Linked list after removing 4:");
foreach (var item in list)
{
    Console.WriteLine(item);
}

Console.WriteLine("LinkedList containts 10?  " + list.Contains(10));
Console.WriteLine("LinkedList containts 13?  " + list.Contains(13));
Console.WriteLine("Count of LinkedList is: " + list.Count);

Console.WriteLine("Copying LinkedList to array: ");
int[] array = new int[list.Count];
list.CopyTo(array, 0);
Console.Write("[");

for (int i = 0; i < array.Length; i++)
{
    Console.Write(array[i]);

    if (i < array.Length - 1)
        Console.Write(", ");
}

Console.WriteLine("]");

list.Clear();
Console.WriteLine("After Clear:");
foreach (var item in list)
{
    Console.WriteLine(item);
}

MyLinkedList<int> list1 = new MyLinkedList<int>();

list1.Add(8);
list1.Add(6);
list1.Add(2);
list1.Add(5);
list1.Add(7);
list1.Add(9);
list1.Add(8);

RemoveKthNodeFromEnd(list1, 3);
foreach (var item in list1)
{
    Console.WriteLine(item);
}

static MyLinkedList<int> RemoveKthNodeFromEnd(MyLinkedList<int> linkedList, int k)
    {
        // 8 9 7 5 6 2 6 8
        // k = 3

        if (linkedList == null || linkedList.Count == 0)
            return linkedList;

        if (k > linkedList.Count)
            throw new ArgumentException("k is greater than list size");

        // Head case
        if (k == linkedList.Count)
        {
            linkedList.RemoveFirst();
            return linkedList;
        }

        MyLinkedListNode<int> node = linkedList.Head;
        int count = linkedList.Count;
        int remuvedKth = linkedList.Count - k;
        
        for (int i = 1; i < remuvedKth; i++)
        {
            node = node.Next;
        }
        MyLinkedListNode<int> remuvedNode = node.Next;
        node = remuvedNode.Next;

        return linkedList;
    }



