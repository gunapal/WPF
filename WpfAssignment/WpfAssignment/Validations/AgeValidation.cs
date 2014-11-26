
namespace WpfAssignment.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;

    /// <summary>
    /// Validates the age, should be in the range of 1-99
    /// </summary>
    public class AgeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int age;
            if ( ! int.TryParse(value.ToString(), out age))
            {
                return new ValidationResult(false, "Age should be a numeric value");
            }

            if (age < 1 || age > 99)
            {
                return new ValidationResult(false, "Age should be between 1 and 99");
            }

            return new ValidationResult(true, null);
        }
    }
}
