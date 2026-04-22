using System.Collections;

namespace MyBinaryTreeLib;

internal class MyBinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private MyBinaryTreeNode<T> _root;
    private int _count;

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

    private IEnumerable<T> InOrderTraversal(MyBinaryTreeNode<T> node)
    {
        if(node != null)
        {
            foreach(var left in InOrderTraversal(node.Left))
                yield return left;

            yield return node.Value;

            foreach(var right in InOrderTraversal(node.Right))
                yield return right;
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
}