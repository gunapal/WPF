using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfAssignment.Validations;
using System.Windows.Controls;
namespace UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        #region Age Validation
        
        [TestMethod]
        [Description("Alpha numeric character input should fail age validaiton")]
        public void AgeValdation_InvalidInput_FailedValidation()
        {
            AgeValidation age = new AgeValidation();
            string input = "g9";
            ValidationResult result = age.Validate(input, null);

            if (result.IsValid)
            {
                Assert.Fail("Age Validation failed for input {0}", input);
            }
        }

        [TestMethod]
        [Description("Minimum age limit validation")]
        public void AgeValdation_AgeLessThanOne_FailedValidation()
        {
            AgeValidation age = new AgeValidation();
            string input = "0";
            ValidationResult result = age.Validate(input, null);

            if (result.IsValid)
            {
                Assert.Fail("Age Validation failed for input {0}", input);
            }
        }

        [TestMethod]
        [Description("Maximum age limit validation")]
        public void AgeValdation_AgeMoreThan99_FailedValidation()
        {
            AgeValidation age = new AgeValidation();
            string input = "100";
            ValidationResult result = age.Validate(input, null);

            if (result.IsValid)
            {
                Assert.Fail("Age Validation failed for input {0}", input);
            }
        }

        [TestMethod]
        [Description("Valid input")]
        public void AgeValdation_ValidLimit_SuccessfulValdation()
        {
            AgeValidation age = new AgeValidation();
            string input = "80";
            ValidationResult result = age.Validate(input, null);

            if (! result.IsValid)
            {
                Assert.Fail("Age Validation failed for input {0}", input);
            }
        }

        #endregion

        #region Name Validation

        [TestMethod]
        [Description("Alpha numeric character input should fail name validaiton")]
        public void NameValdation_InvalidInput_FailedValidation()
        {
            NameValidation nameValidation = new NameValidation();
            string input = "Alan Turing 9";
            ValidationResult result = nameValidation.Validate(input, null);

            if (result.IsValid)
            {
                Assert.Fail("Name Validation failed for input {0}", input);
            }
        }

        [TestMethod]
        [Description("Empty string should fail name validaiton")]
        public void NameValdation_EmptyName_FailedValidation()
        {
            NameValidation nameValidation = new NameValidation();
            string input = string.Empty;
            ValidationResult result = nameValidation.Validate(input, null);

            if (result.IsValid)
            {
                Assert.Fail("Name Validation failed for input {0}", input);
            }
        }

        [TestMethod]
        [Description("Name contains special characters, should fail validation")]
        public void NameValdation_SpeicalCharacterInName_FailedValidation()
        {
            NameValidation nameValidation = new NameValidation();
            string input = "John Doe $";
            ValidationResult result = nameValidation.Validate(input, null);

            if (result.IsValid)
            {
                Assert.Fail("Name Validation failed for input {0}", input);
            }
        }

        [TestMethod]
        [Description("Valid input , succesful validation")]
        public void NameValdation_ValidName_SuccessfulValidation()
        {
            NameValidation nameValidation = new NameValidation();
            string input = "John Doe";
            ValidationResult result = nameValidation.Validate(input, null);

            if ( ! result.IsValid)
            {
                Assert.Fail("Name Validation failed for input {0}", input);
            }
        }
        #endregion
    }
}
