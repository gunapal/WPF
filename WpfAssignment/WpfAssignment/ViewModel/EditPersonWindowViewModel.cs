namespace WpfAssignment.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using WpfAssignment.Commands;
    using WpfAssignment.Datamodel;

    
    public class EditPersonWindowViewModel : INotifyPropertyChanged
    {
        #region Properties
        
        private Person _personSelected;

        public Person PersonSelected 
        { 
            get
            {
                return _personSelected;
            }
            set
            {
                if (value != _personSelected)
                {
                    _personSelected = value;
                    RaisePropertyChangedEvent("PersonSelected");
                }
            }
        }

        private Person _personToEdit;
        
        #endregion

        #region Constructor
        
        public EditPersonWindowViewModel(Person personToEdit, Action closeWindowDelegate)
        {
            _personToEdit = personToEdit;
            PersonSelected = new Person(_personToEdit.FullName, _personToEdit.Age);

            SaveCommand = new CustomCommand(SaveHandler);
            CancelCommand = new CustomCommand(CancelHandler);

            CloseWindow = closeWindowDelegate;
        }
        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public Action CloseWindow { get; set; }

        #endregion

        #region Event Handlers

        public void SaveHandler(object parameter)
        {
            if (PersonSelected != null)
            {
                _personToEdit.FullName = PersonSelected.FullName;
                _personToEdit.Age = PersonSelected.Age;
            }

            CloseWindow();
        }

        public void CancelHandler(object parameter)
        {
            CloseWindow();
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
