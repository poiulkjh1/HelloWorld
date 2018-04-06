using HelloWorldCore.com.learning.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HelloWorldCore.com.learning.manager{
    public class PersonFactory{
        private List<Person> allPerson = null;

        public PersonFactory() {
            allPerson = new List<Person>();
        }

        public Person GetPersonById(int id) {
            var everybody = GetAll();
            return everybody.Find(c => c.Id == id);
        }

        public void UpsertPerson(Person person) {
            var existing = allPerson.Where(c => c.Id.Equals(person.Id)).FirstOrDefault();

            if (existing != null){
                allPerson.Remove(existing);
            }   
             
            allPerson.Add(person);
        }

        public List<Person> GetAll() {
            return allPerson;
        }
    }
}