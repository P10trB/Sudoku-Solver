using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sudoku_Solver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox[,]textBoxes;
        private const int SIZE = 9;
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        SolverHelper _solverHelper;
        public MainWindow()
        {
            InitializeComponent();
            setArrayOfTextBoxes();
            _solverHelper = new SolverHelper();
        }
        private void setArrayOfTextBoxes()
        {
            //textBoxes = new TextBox[SIZE, SIZE];
            textBoxes = new TextBox[,]{
                { textBox00, textBox01, textBox02, textBox03, textBox04, textBox05, textBox06, textBox07, textBox08},
                { textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18},
                { textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28},
                { textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox37, textBox38},
                { textBox40, textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48},
                { textBox50, textBox51, textBox52, textBox53, textBox54, textBox55, textBox56, textBox57, textBox58},
                { textBox60, textBox61, textBox62, textBox63, textBox64, textBox65, textBox66, textBox67, textBox68},
                { textBox70, textBox71, textBox72, textBox73, textBox74, textBox75, textBox76, textBox77, textBox78},
                { textBox80, textBox81, textBox82, textBox83, textBox84, textBox85, textBox86, textBox87, textBox88},
            };
            foreach (var item in textBoxes)
            {
                item.MaxLength = 1;
                resetWindow();
            }
        }

        private void textBox00_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void resetWindow()
        {
            foreach (var item in textBoxes)
            {
                item.Text = "";
            }
        }

        private void solveButton_Click(object sender, RoutedEventArgs e)
        {
            if (solveButton.Content.Equals("RESET"))
            {
                resetWindow();
                solveButton.Content = "Solve sudoku";
            }
            else
            {
                _solverHelper.solveSudoku(ref textBoxes);
                solveButton.Content = "RESET";
            }
        }
    }
}
