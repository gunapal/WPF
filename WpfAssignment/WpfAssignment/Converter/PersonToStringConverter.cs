namespace WpfAssignment.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;
    using WpfAssignment.Datamodel;

    /// <summary>
    /// Convertes Person object to string representation by concatinating the Full Name and Age.
    /// </summary>
    public class PersonToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Person person = value as Person;
            string displayString = string.Empty;

            if (person != null)
            {
                displayString = string.Format("{0} {1}", person.FullName, person.Age);
            }

            return displayString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
