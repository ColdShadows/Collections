using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            
            

             
            
            try
            {

                //fileProcessing();
                productCatalog();
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void productCatalog()
        {
            int choice = 0;
            Dictionary<int, Product> productCatalog = new Dictionary<int, Product>();

            Product shampoo = new Product("Shampoo: LoReal, you matter.", 15, "LoReal");
            productCatalog.Add(shampoo.ProductNum, shampoo);
            Product mouthwash = new Product("Mouth wash: mmmmmmm, minty.", 10, "Listerine");
            productCatalog.Add(mouthwash.ProductNum, mouthwash);
            Product toothbrush = new Product("Tooth brush: clean your teeth", 8, "Crest");
            productCatalog.Add(toothbrush.ProductNum, toothbrush);
            
            
            

            bool done = false;
            bool isValid = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Hello, enter a product number to find the associated product details");
                Console.WriteLine("1: Shampoo");
                Console.WriteLine("2: Mouth wash");
                Console.WriteLine("3: Tooth brush");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        productCatalog[1].displayProduct();
                        isValid = true;
                        break;
                    case 2:
                        productCatalog[2].displayProduct();
                        isValid = true;
                        break;
                    case 3:
                        productCatalog[3].displayProduct();
                        isValid = true;
                        break;
                    default:
                        isValid = false;
                        Console.WriteLine("That is not a valid product number");
                        break;

                }

                Console.WriteLine("Enter a 0 if you are done viewing the catalog");
                int.TryParse(Console.ReadLine(), out choice);
                if(choice == 0)
                {
                    done = true;
                }

            } while (!done && !isValid || !done);

            
            Console.ReadLine();
        }
        public static void fileProcessing()
        {
            bool validSelection = false;
            string choiceString = "";
            int choice = 1;
            List<string> nameList = new List<string>();
            List<Person> personList = new List<Person>();
            Console.WriteLine("-----------List of Customers-----------");

            while (choice != 0)
            {
                Console.WriteLine("Hello, to display the current list of VIP members enter 1. If you wish to add a name to the list enter 2. Exit by entering 0.");
                choiceString = Console.ReadLine();
                validSelection = Int32.TryParse(choiceString, out choice);
                if (choice == 1)
                {
                    displayVIP(nameList, personList);
                }
                else if (choice == 2)
                {
                    addVIP(nameList, personList);

                }
                /*else if (choice == 3)
                {
                        
                }*/






                //Console.ReadLine();
            }

        }
        public static void displayVIP(List<string> nl, List<Person> pl)
        {
            List<string> nameList = new List<string>();
            nameList = nl;
            List<Person> personList = new List<Person>();
            personList = pl;

            using (StreamReader input = new StreamReader("ListOfNames.txt"))
            {
                Console.Clear();
                nameList.Clear();
                personList.Clear();
                while (!input.EndOfStream)
                {
                    nameList.Add(input.ReadLine());

                }

                foreach (string n in nameList)
                {
                    Person p = new Person(n);
                    personList.Add(p);
                }

                foreach (Person p in personList)
                {
                    Console.WriteLine("The VIP member's name is: " + p.Name);
                }
                input.Close();
            }
        }
        public static void addVIP(List<string> nl, List<Person> pl)
        {
            List<string> nameList = new List<string>();
            nameList = nl;
            List<Person> personList = new List<Person>();
            personList = pl;
            string name = "";
            string[] namePart = { "First", "Last" };

            using (StreamWriter output = new StreamWriter("ListOfNames.txt", true))
            {
                Console.WriteLine("Hello, enter only the first and last name seperated by a space for the person you wish to add to the VIP section");
                name = Console.ReadLine();
                namePart = name.Split();
                output.WriteLine(namePart[0] + " " + namePart[1]);
                output.Close();
            }
        }
        public static void removeVIP(List<string> nl, List<Person> pl)
        {
            List<string> nameList = new List<string>();
            nameList = nl;
            List<Person> personList = new List<Person>();
            personList = pl;
            string name = "";
            using (StreamReader input = new StreamReader("ListOfNames.txt"))
            {
                Console.Clear();
                nameList.Clear();
                personList.Clear();
                while (!input.EndOfStream)
                {
                    nameList.Add(input.ReadLine());

                }

                foreach (string n in nameList)
                {
                    Person p = new Person(n);
                    personList.Add(p);
                }

                input.Close();
            }
            using (StreamWriter output = new StreamWriter("ListOfNames.txt"))
            {
                Console.WriteLine("Enter a name that you want removed from the list");
                name = Console.ReadLine();
                foreach (string n in nameList)
                {
                    if (n.ToLower() == name.ToLower())
                    {
                        Console.WriteLine(n + " has been removed from the VIP list.");
                        nameList.Remove(n);
                    }

                }
                foreach (string n in nameList)
                {
                    Person p = new Person(n);
                    personList.Add(p);

                }                
                foreach (Person p in personList)
                {
                    output.WriteLine(p.Name);
                }

            }

        }
    }
}
