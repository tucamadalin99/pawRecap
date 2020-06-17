using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Product : IComparable<Product>
    {
        private int id;
        private string name;
        private int units;
        private double price;
        private int categoryId;
        

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Units { get => units; set => units = value; }
        public double Price { get => price; set => price = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }

        public Product(int id, string name, int units, double price, int categoryId)
        {
            this.Id = id;
            this.Name = name;
            this.Units = units;
            this.Price = price;
            this.CategoryId = categoryId;
        }

        public Product()
        {
            this.id = 0;
            this.name = "";
            this.units = 0;
            this.price = 0.0f;
            this.categoryId = 0;
        }


        public override string ToString()
        {
            return "ID: " + Id + " Name: " + Name + " Units: " + Units + " Price: " + Price + "Category id: " + CategoryId;
        }

        public int CompareTo(Product p)
        {
            return Name.CompareTo(p.name);
        }

        public static explicit operator double(Product p)
        {
            return p.units * p.price;
        }
    }
}
