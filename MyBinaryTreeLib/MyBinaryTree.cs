using MyStackLib;
using System.Collections;

namespace MyBinaryTreeLib;

public class MyBinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private MyBinaryTreeNode<T> _root;
    private int _count;

    public MyBinaryTree(MyBinaryTreeNode<T> root)
    {
        _root = root;
    }

    #region Contains
    public bool Contains(T item)
    {
        return FindWithParent(item, out MyBinaryTreeNode<T> parent) != null;
    }

    private MyBinaryTreeNode<T> FindWithParent(T value, out MyBinaryTreeNode<T> parent)
    {
        MyBinaryTreeNode<T> current = _root;
        parent = null;

        while (current != null)
        {
            int result = current.CompareTo(value);

            parent = current;

            if (result > 0)
                current = current.Left;
            else if (result < 0)
                current = current.Right;
            else
                break;
        }
        return current;
    }
    #endregion

    #region Pre-Order Traversal
    //public delegate void Action<in T>(T obj);
    public void PreOrderTraversal(Action<T> action) // Action-ը delegate է
    {
        PreOrderTraversal(action, _root);
    }

    private void PreOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
    {
        if(node != null)
        {
            action(node.Value);
            PreOrderTraversal(action, node.Left);
            PreOrderTraversal(action, node.Right);
        }
    }
    #endregion

    #region In-Order Traversal
    public void InOrderTraversal(Action<T> action)
    {
        InOrderTraversal(action, _root);
    }

    private void InOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
    {
        if (node != null)
        {
            InOrderTraversal(action, node.Left);
            action(node.Value);
            InOrderTraversal(action, node.Right); 
        }
    }
    #endregion

    #region Post-Order Traversal
    public void PostOrderTraversal(Action<T> action)
    {
        PostOrderTraversal(action, _root);
    }

    private void PostOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
    {
        if (node != null)
        {
            PostOrderTraversal(action, node.Left);
            PostOrderTraversal(action, node.Right);
            action(node.Value);
        }
    }
    #endregion

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(_root).GetEnumerator(); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal(MyBinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var left in InOrderTraversal(node.Left))
                yield return left;

            yield return node.Value;

            foreach (var right in InOrderTraversal(node.Right))
                yield return right;
        }
    }
    public IEnumerable<T> InOrderTraversal()
    {
        if (_root != null)
        {
            MyStack<MyBinaryTreeNode<T>> stack = new MyStack<MyBinaryTreeNode<T>>();

            MyBinaryTreeNode<T> current = _root;

            bool goLeftNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                if (current.Right != null)
                {
                    current = current.Right;

                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }
    }

    public MyBinaryTree<T> Add(T value)
    {
        if (_root == null)
            return new MyBinaryTree<T>(new MyBinaryTreeNode<T>(value));

        List<T> items = new List<T>();

        InOrderTraversal(item =>
        {
            items.Add(item);
        });

        items.Add(value);
        items.Sort();

        var root = BuildTree(items, 0, items.Count - 1);

        return new MyBinaryTree<T>(root);
    }

    public MyBinaryTree<T> Remove(T value)
    {
        if (_root == null)
            throw new Exception("Root is empty");

        List<T> items = new List<T>();

        bool found = false;

        InOrderTraversal(item =>
        {
            if (item.Equals(value))
            {
                found = true;
                return;
            }

            items.Add(item);
        });

        if (!found)
            throw new Exception("Value does not exist in tree");

        var root = BuildTree(items, 0, items.Count - 1);

        return new MyBinaryTree<T>(root);
    }

    private MyBinaryTreeNode<T> BuildTree(List<T> items, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;

        var node = new MyBinaryTreeNode<T>(items[mid]);

        node.Left = BuildTree(items, start, mid - 1);
        node.Right = BuildTree(items, mid + 1, end);

        return node;
    }

}


//public void Add(T value)
//{
//    if(_root == null)
//    {
//        _root = new MyBinaryTreeNode<T>(value);
//    }
//    else
//    {
//        AddTo(_root, value);
//    }
//    _count++;
//}

//public void AddTo(MyBinaryTreeNode<T> node, T value)
//{
//    if (value.CompareTo(node.Value) < 0)
//    {
//        if (node.Left == null)
//        {
//            node.Left = new MyBinaryTreeNode<T>(value);
//        }
//        else
//        {
//            AddTo(node.Left, value);
//        }
//    }
//    else
//    {
//        if (node.Right == null)
//        {
//            node = new MyBinaryTreeNode<T>(value);
//        }
//        else
//        {
//            AddTo(node.Right, value);
//        }
//    }
//}