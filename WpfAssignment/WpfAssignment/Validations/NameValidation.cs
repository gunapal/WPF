// -----------------------------------------------------------------------
// <copyright file="NameValidation.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WpfAssignment.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Text.RegularExpressions;
    using System.Configuration;

    /// <summary>
    /// Validates name, should contain only alphabets and a space.
    /// </summary>
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string name = string.Empty;
            string matchingPattern = @"^[a-zA-Z\s]+$";
            RegexStringValidator regexValidator = new RegexStringValidator(matchingPattern);

            if (value != null)
            {
                name = value.ToString();
            }

            try
            {
                regexValidator.Validate(name);
            }
            catch (ArgumentException e)
            {
                return new ValidationResult(false, "Name can consists of Alphabets and space.");
            }

            return new ValidationResult(true, null);
        }

    }
}
