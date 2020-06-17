using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<Category> categories;
        public List<Product> produse;
        public Form1()
        {
            categories = new List<Category>();
            produse = new List<Product>();
            InitializeComponent();
        }

        private void displayProds()
        {
            dgvProd.Rows.Clear();
            produse.Sort();
            foreach (var p in produse)
            {
                var category = categories.First(x => x.Id == p.CategoryId);
                var rowIndex = dgvProd.Rows.Add(new object[]
                   {
                    p.Name,p.Units,p.Price,category.Name
                   });
                dgvProd.Rows[rowIndex].Tag = p;
                
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            Form2 frm2 = new Form2(categories, p);
            frm2.ShowDialog();
                produse.Add(p);
                displayProds();
            
           
            
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if(dgvProd.SelectedRows.Count == 1)
            {
                var selectedRow = dgvProd.SelectedRows[0];
                var prod = (Product)selectedRow.Tag;
                produse.Remove(prod);
                displayProds();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if(dgvProd.SelectedRows.Count == 1)
            {
                var selectedRow = dgvProd.SelectedRows[0];
                var prod = (Product)selectedRow.Tag;
                Form2 frm2 = new Form2(categories, prod);
                frm2.ShowDialog();
                displayProds();
            }
        }

        private void cmptBtn_Click(object sender, EventArgs e)
        {
            double sum = 0;
            foreach(Product p in produse)
            {
                sum += (double)p;
            }
            MessageBox.Show("Sum is: " + sum.ToString());
        }
    }
}
