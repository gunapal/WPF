namespace WpfAssignment.Datamodel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Collections;

    /// <summary>
    /// Represents the Person object.
    /// </summary>
    public class Person : INotifyPropertyChanged, IEquatable<Person>
    {
        #region Properties
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set 
            {
                if (value != _fullName)
                {
                    _fullName = value;
                    RaisePropertyChanged("FullName");
                }
            }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set 
            {
                if (value != _age)
                {
                    _age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        #endregion

        #region Constructor

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion

        #region IEquatable implemenation

        public bool Equals(Person other)
        {
            if (this.Age == other.Age && string.Compare(this.FullName, other.FullName) == 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
