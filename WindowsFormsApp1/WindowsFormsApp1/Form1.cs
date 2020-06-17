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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int margin = 10;
        Parc parc;
        List<Vehicul> vehiculs;
        public Form1()
        {
            InitializeComponent();
            vehiculs = new List<Vehicul>();
            parc = new Parc(vehiculs);

        }

        public Parc getParc
        {
            get
            {
                return parc;
            }
            set
            {
                if (value != null)
                    parc = value;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {   Vehicul v = new Vehicul();
            Form2 frm2 = new Form2(v);
            frm2.ShowDialog();
            parc = parc + v;
            listView1.Items.Clear();
            foreach (Vehicul veh in vehiculs)
            {
                ListViewItem itm = new ListViewItem(veh.ModelMasina);
                
                itm.SubItems.Add(veh.AnFabricatie.ToString());
                itm.SubItems.Add(veh.Pret.ToString());
                listView1.Items.Add(itm);
            }
           
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            panel1.Show();
            
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                    parc.Vehicule.RemoveAt(i);

                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //get the drawing context
            Graphics graphics = e.Graphics;
            //get the drawing area
            Rectangle clipRectangle = e.ClipRectangle;

            //determine the width of the bars
            var barWidth = clipRectangle.Width / parc.Vehicule.Count;
            //compute the maximum bar height
            var maxBarHeight = clipRectangle.Height * 0.9;
            //compute the scaling factor based on the maximum value that we want to represent
            var scalingFactor = maxBarHeight / parc.Vehicule.Max(x => x.Pret);

            Brush redBrush = new SolidBrush(Color.Red);

            for (int i = 0; i < parc.Vehicule.Count; i++)
            {
                var barHeight = parc.Vehicule[i].Pret * scalingFactor;

                graphics.FillRectangle(
                    redBrush,
                    i * barWidth,
                    (float)(clipRectangle.Height - barHeight),
                    (float)(0.8 * barWidth),
                    (float)barHeight);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel1.Hide();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(*.txt)|*.txt";
           if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach(ListViewItem itm in listView1.Items)
                {
                    for(int i = 0; i < itm.SubItems.Count; i++)
                    {
                        sw.Write(itm.SubItems[i].Text + " ");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }
    }
}
