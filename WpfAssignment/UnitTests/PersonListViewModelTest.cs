using WpfAssignment.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfAssignment.ViewController;
using System.Windows.Input;
using WpfAssignment.Datamodel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for PersonListViewModelTest and is intended
    ///to contain all PersonListViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonListViewModelTest
    {

        private PersonListViewModel target = null;

        public PersonListViewModel Target
        {
            get { return target; }
            set { target = value; }
        }

        IEditPersonContoller editPersonController;

        public IEditPersonContoller EditPersonController
        {
            get { return editPersonController; }
            set { editPersonController = value; }
        }

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
        ///A test for PersonListViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void PersonListViewModelConstructorTest()
        {
            EditPersonController = new EditViewController();
            target = new PersonListViewModel(EditPersonController);
            if (target == null)
            {
                Assert.Fail("Unable to create the PersonListViewModel");
            }
        }

        /// <summary>
        ///A test for EditClickedHandler
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WpfAssignment.exe")]
        public void EditClickedHandlerTest()
        {
            IEditPersonContoller editController = new EditViewController(); 
            PersonListViewModel_Accessor target = new PersonListViewModel_Accessor(editController); 
            target.PersonSelected = target.PersonList[0];
            target.EditClickedHandler(null);
        }

        /// <summary>
        ///A test for InitializeViewModel
        ///</summary>
        [TestMethod()]
        public void InitializeViewModelTest()
        {
            IEditPersonContoller editPersonController = new EditViewController();
            PersonListViewModel_Accessor target = new PersonListViewModel_Accessor(editPersonController); 
            target.InitializeViewModel(editPersonController);
        }

        /// <summary>
        ///A test for PopulateDefaultPersonList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WpfAssignment.exe")]
        public void PopulateDefaultPersonListTest()
        {
            IEditPersonContoller editPersonController = new EditViewController();
            PersonListViewModel_Accessor target = new PersonListViewModel_Accessor(editPersonController); 
            target.PopulateDefaultPersonList();
        }


        /// <summary>
        ///A test for PersonList
        ///</summary>
        [TestMethod()]
        public void PersonListTest()
        {
            IEditPersonContoller editPersonController = new EditViewController(); // TODO: Initialize to an appropriate value
            PersonListViewModel target = new PersonListViewModel(editPersonController); // TODO: Initialize to an appropriate value
            ObservableCollection<Person> expected = GetExpectedPersonList(); // TODO: Initialize to an appropriate value
            ObservableCollection<Person> actual;
            actual = target.PersonList;
            if (actual == null || actual.Count != expected.Count)
            {
                Assert.Fail();
            }

            foreach (var person in expected)
            {
                if (!actual.Contains(person))
                {
                    Assert.Fail();
                    break;
                }
            }
        }

        ObservableCollection<Person> GetExpectedPersonList()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person("Alex Lee", 25));
            list.Add(new Person("Jim Green", 26));
            list.Add(new Person("Larry king", 27));

            return new ObservableCollection<Person>(list);
        }
    }
}
