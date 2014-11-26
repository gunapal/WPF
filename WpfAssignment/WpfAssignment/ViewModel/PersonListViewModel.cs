namespace WpfAssignment.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using WpfAssignment.Commands;
    using WpfAssignment.Datamodel;
    using WpfAssignment.ViewController;
    

    /// <summary>
    /// Represets the main window.
    /// </summary>
    public class PersonListViewModel : INotifyPropertyChanged
    {
        #region Properties

        ObservableCollection<Person> _personList;

        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set 
            { 
                _personList = value; 
            }
        }

        private Person _personSelected;

        public Person PersonSelected 
        { 
            get
            {
                return _personSelected;
            }
            set
            {
                _personSelected = value;
                RaisePropertyChangedEvent("PersonSelected");
            }
        }

        private IEditPersonContoller _editPerson;

        #endregion

        #region Command

        public ICommand EditCommand
        {
            get;
            set;
        }

        public ICommand WindowLoaded { get; set; }

        #endregion

        #region Constructor
        
        public PersonListViewModel(IEditPersonContoller editPersonController )
        {
            InitializeViewModel(editPersonController);
        }

        #endregion

        #region Initialization

        private void InitializeViewModel(IEditPersonContoller editPersonController)
        {
            PopulateDefaultPersonList();
            
            EditCommand = new CustomCommand(EditClickedHandler);
            WindowLoaded = new CustomCommand(SetPersonSelected);
            _editPerson = editPersonController;
        }

        private void PopulateDefaultPersonList()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person("Alex Lee", 25));
            list.Add(new Person("Jim Green", 26));
            list.Add(new Person("Larry king", 27));

            PersonList = new ObservableCollection<Person>(list);
        }

        #endregion

        #region Handler

        private void EditClickedHandler(object param)
        {
            PersonSelected = _editPerson.EditPerson(PersonSelected);
        }

        private void SetPersonSelected(object param)
        {
            PersonSelected = PersonSelected = PersonList[0];
        }

        #endregion

        #region INotifyPropertyChanged Implementation.

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
