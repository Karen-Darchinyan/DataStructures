using MyQueueLib;
using System.Windows;

namespace WpfQueueApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    MyQueue<int> _queue = new MyQueue<int>();
    Random rnd = new Random();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnEnqueue_Click(object sender, RoutedEventArgs e)
    {
        _queue.Enqueue(rnd.Next(1, 100));
        Update();
    }

    private void btnDequeue_Click(object sender, RoutedEventArgs e)
    {
        if(_queue.Count > 0)
        {
            lstBox.Items.Add(_queue.Dequeue().ToString());
            Update();
        }
            
    }

    private void Update()
    {
        lblNode1.Content = string.Empty;
        lblNode2.Content = string.Empty;
        lblNode3.Content = string.Empty;
        lblNode4.Content = string.Empty;
        lblNode5.Content = string.Empty;
        lblNode6.Content = string.Empty;

        int index = 0;

        foreach(var item in _queue)
        {
            switch(index)
            {
                case 0:
                    lblNode1.Content = item.ToString();
                    break;
                case 1:
                    lblNode2.Content = item.ToString();
                    break;
                case 2:
                    lblNode3.Content = item.ToString();
                    break;
                case 3:
                    lblNode4.Content = item.ToString();
                    break;
                case 4:
                    lblNode5.Content = item.ToString();
                    break;
                case 5:
                    lblNode6.Content = item.ToString();
                    break;
                default:
                    break;
            }
            index++;

            if(index > 5)
                break;
        }
    }
}