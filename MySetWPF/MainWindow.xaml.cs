using MySetProj;
using System.Windows;
using System.Windows.Controls;

namespace MySetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Set<Student> _math =  new Set<Student>();
        Set<Student> _phys =  new Set<Student>();
        Set<Student> _hist =  new Set<Student>();

        Set<Student> _men =   new Set<Student>();
        Set<Student> _women = new Set<Student>();

        Dictionary<string, Set<Student>> allSets = new Dictionary<string, Set<Student>>();
        public MainWindow()
        {
            Student armen =    new Student(1, "Armen", Gender.Male);
            Student jon =      new Student(4, "Jon", Gender.Male);
            Student tom =      new Student(5, "Tom", Gender.Male);
            Student bob =      new Student(7, "Bob", Gender.Male);
            _men.AddRange(new Student[] { armen, jon, tom, bob });
            Student armenuhi = new Student(2, "Armenuhi", Gender.Female);
            Student marieta =   new Student(3, "Marieta", Gender.Female);
            Student sara =     new Student(6, "Sara", Gender.Female);
            Student jenifer =  new Student(8, "Jenifer", Gender.Female);
            _women.AddRange(new Student[] { armenuhi, marieta, sara, jenifer });

            //ավելացնել dictionary

            InitializeComponent();
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            //ավելացնել խմբերը, որ կլիկ անենք խմբերը բերի
        }

        private void leftSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rightSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}