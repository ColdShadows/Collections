using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Person
    {
        string name;

        public string Name
        {
            get { return name; }
        }
        public Person()
        {
            name = "Blank";
        }
        public Person(string _name)
        {
            name = _name;
        }

    }
}
