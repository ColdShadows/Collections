using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Product
    {
        static int productNum;
        string description;
        double cost;
        string manufacturer;

        public Product()
        {
            productNum++;
            description = "No Description";
            cost = 0;
            manufacturer = "No Manufacturer";
        }
        public Product(string d, double c, string m)
        {
            productNum++;
            description = d;
            cost = c;
            manufacturer = m;
        }
        public int ProductNum
        {
            get { return productNum; }
        }
        public string Description
        {
            get { return description; }
        }
        public double Cost
        {
            get { return cost; }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
        }
        public void displayProduct()
        {
            Console.WriteLine("The product's description is: " + this.Description + ", the cost is " + this.Cost.ToString("c2") + ", and the Manufacturer is " + this.Manufacturer);
        }

    }
}
