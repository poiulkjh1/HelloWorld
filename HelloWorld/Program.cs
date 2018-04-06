using HelloWorldCore.com.learning.model;
using HelloWorldCore.com.learning.manager;
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PersonFactory();
            
            Console.Write("Enter an id: ");
            var input = Console.ReadKey(true);

            var key = input.KeyChar.ToString();

            int id;

            if (int.TryParse(key, out id)) {
                Person person = factory.GetPersonById(id);

                if (person != null)
                {
                    Console.WriteLine("Hello World! " + String.Format("This is {0} {1}", person.FirstName, person.LastName));
                }
                else {
                    Console.WriteLine("Person doesn't exist");
                }
            }
            else {
                Console.WriteLine("id is not correct");
            }

            Console.ReadKey(true);
        }
    }
}
