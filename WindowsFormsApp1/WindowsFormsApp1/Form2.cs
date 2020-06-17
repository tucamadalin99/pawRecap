using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Vehicul v2 = new Vehicul();
        public Form2(Vehicul v)
        {
            this.v2 = v;
            InitializeComponent();
        }

           public string getModel
        {
            get
            {
                return tbModel.Text;
            }
        }


        public int getAn
        {
            get
            {
                return Convert.ToInt32(tbAn.Text);
            }
        }

        public float getPret
        {
            get
            {
                return (float)Convert.ToDouble(tbPret.Text);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string model = tbModel.Text;
                int an = Convert.ToInt32(tbAn.Text);
                float price = (float)Convert.ToDouble(tbPret.Text);
                v2.ModelMasina = model;
                v2.AnFabricatie = an;
                v2.Pret = price;
                
                MessageBox.Show("Vehicle added!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
