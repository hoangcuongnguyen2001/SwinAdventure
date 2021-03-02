using System.Windows;
using SwinAdventure;

namespace GUISwinAdventure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // help from Jimmy Trac.
        ProgramReference _newProgram;
        public MainWindow()
        {
            InitializeComponent();
            _newProgram = new ProgramReference();
            Console.Text = _newProgram.Output;
        }
        private void EnterClick(object sender, RoutedEventArgs e)
        {
            Console.Text = "\n" + _newProgram.InputCommand(commandBox.Text);
            commandBox.Clear();
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
