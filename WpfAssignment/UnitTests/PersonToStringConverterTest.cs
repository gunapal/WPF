using WpfAssignment.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using WpfAssignment.Datamodel;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PersonToStringConverterTest and is intended
    ///to contain all PersonToStringConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonToStringConverterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for PersonToStringConverter Constructor
        ///</summary>
        [TestMethod()]
        public void PersonToStringConverterConstructorTest()
        {
            PersonToStringConverter target = new PersonToStringConverter();
            if (target == null)
            {
                Assert.Fail("Failed to create targe object to test PersonToStringConverter");
            }
        }

       
        [TestMethod()]
        [Description("Person object input, returns a string concatinating name and age.")]
        public void ConvertTest_PersonObject_SuccessfulConversion()
        {
            PersonToStringConverter target = new PersonToStringConverter(); 
            object value = new Person("John Doe", 22); 
            string expected = "John Doe 22"; 
            string actual;
            actual = (string)target.Convert(value, null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [Description("Person object null, should return empty string")]
        public void ConvertTest_NullInput_EmptyString()
        {
            PersonToStringConverter target = new PersonToStringConverter();
            object value = null;
            string expected = string.Empty;
            string actual;
            actual = (string)target.Convert(value, null, null, null);
            Assert.AreEqual(expected, actual);
        }
    }
}
