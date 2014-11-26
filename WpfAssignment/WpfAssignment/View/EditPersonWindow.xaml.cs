using System;
using System.Windows;
using WpfAssignment.Datamodel;
using WpfAssignment.ViewModel;

namespace WpfAssignment.View
{
    /// <summary>
    /// Interaction logic for EditPersonWindow.xaml
    /// </summary>
    public partial class EditPersonWindow : Window
    {

        public EditPersonWindow(Person personToEdit)
        {
            InitializeComponent();
            this.DataContext = new EditPersonWindowViewModel(personToEdit
                                                             , new Action(() => this.Close())
                                                             );
        }
    }
}
