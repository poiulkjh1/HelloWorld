using System;
using System.Collections.Generic;
using HelloWorldCore.com.learning.manager;
using HelloWorldCore.com.learning.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldTests{
    [TestClass]
    public class UnitTest1{
        private PersonFactory factory = null;

        [TestInitialize]
        public void Init() {
            factory = new PersonFactory();

            factory.UpsertPerson(new Person { Id = 1, FirstName = "James", LastName = "White" });
            factory.UpsertPerson(new Person { Id = 2, FirstName = "Malcolm", LastName = "Turnbull" });
            factory.UpsertPerson(new Person { Id = 3, FirstName = "Rebecca", LastName = "Black" });
            factory.UpsertPerson(new Person { Id = 4, FirstName = "Jessica", LastName = "Brown" });
        }

        [TestCleanup]
        public void CleanUp() { }

        [TestMethod]
        public void GetAllReturnSomethingTest(){
            var everybody = factory.GetAll();

            Assert.IsNotNull(everybody);
            Assert.IsTrue(everybody.Count > 0);

            //CollectionAssert
        }

        [TestMethod]
        public void GetByIdTest() {
            var person = factory.GetPersonById(1);

            Assert.IsNotNull(person);
            Assert.IsTrue(person.FirstName.Equals("James"));
        }

        [TestMethod]
        public void UpsertTest(){
            var all = factory.GetAll();

            Assert.IsTrue(all.Count == 4);

            var person = factory.GetPersonById(1);

            Assert.IsNotNull(person);
            Assert.IsTrue(person.FirstName.Equals("James"));

            var updatedPerson = new Person { Id = 1, FirstName = "Tracy", LastName = "Yap" };

            factory.UpsertPerson(updatedPerson);

            var afterUpdatedPerson = factory.GetPersonById(1);

            Assert.IsNotNull(afterUpdatedPerson);
            Assert.IsTrue(afterUpdatedPerson.FirstName.Equals("Tracy"), "FirstName does not match " + person.FirstName);

            var afterUpdatedAll = factory.GetAll();

            Assert.IsTrue(afterUpdatedAll.Count == 4);
        }

        [TestMethod]
        public void InsertNewPersonTest() {
            var abc = new List<Person> {
                new Person{ Id = 6, FirstName = "Adam", LastName = "Austin" },
                new Person{ Id = 7, FirstName = "Joyce", LastName = "Koh" }
            };

            abc.ForEach(x => factory.UpsertPerson(x));

            var all = factory.GetAll();

            Assert.IsTrue(all.Count == 6);

            CollectionAssert.AllItemsAreUnique(all);
        }
    }
}
