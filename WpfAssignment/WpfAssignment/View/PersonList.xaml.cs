using System.Windows;
using WpfAssignment.ViewController;
using WpfAssignment.ViewModel;

namespace WpfAssignment.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonList : Window
    {
        public PersonList()
        {
            InitializeComponent();
            IEditPersonContoller editContoller = new EditViewController();
            this.DataContext = new PersonListViewModel(editContoller);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
