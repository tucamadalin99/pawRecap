using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Category
    {
        private int id;
        protected string name;

        public Category(int id, string name)
        {
            this.Id = id;
            this.name = name;
        }

       
        
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return name;
        }
    }
}
