using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawImages
{
    public partial class Form1 : Form
    {
        private Graphics z;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            z = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select and insert image
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "C:\\Temp",
                Title = "Select Image",
                Filter = "Bild - Dateien(*.jpg; *.gif)| *.jpg; *.gif"
            };

            Image bild;

            z.Clear(BackColor);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bild = Image.FromFile(ofd.FileName);
                z.DrawImage(bild, 20, 60);
            }
        }
    }
}
