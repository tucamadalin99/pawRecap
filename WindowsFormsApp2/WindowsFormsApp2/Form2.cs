using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    
    public partial class Form2 : Form
    {
        
        public List<Category> categs;
        public Product prod;
       public Form2(List<Category>categos, Product p)
        {
            this.prod = p;
            this.categs = categos;
            InitializeComponent();
        }

        public void loadCateg()
        {
            StreamReader sr = new StreamReader("categ.txt");
            try
            {
                string[] lines = System.IO.File.ReadAllLines("categ.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(' ');
                    int id = Convert.ToInt32(values[0]);
                    string name = values[1];
                    categs.Add(new Category(id, name));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.Close();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
           
            try
            {
               
                prod.Name = tbName.Text;
                var selectedCat = (Category)cbCat.SelectedItem;
                prod.CategoryId = selectedCat.Id;
                prod.Units = Convert.ToInt32(tbUnit.Text);
                prod.Price = Convert.ToDouble(tbPrice.Text);
                MessageBox.Show("Product added!");
 

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
           
           // products.Add(name, units, price, cbCat.SelectedIndex);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadCateg();
            cbCat.DataSource = categs;
            tbName.Text = prod.Name;
            tbUnit.Text = prod.Units.ToString();
            tbPrice.Text = prod.Price.ToString();

            if(prod.CategoryId != 0)
            {
                var categ = categs.First(x => x.Id == prod.CategoryId);
                cbCat.SelectedItem = categ;
            }
        }
    }
}
