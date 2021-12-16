using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        private Graphics z;
        private Pen pen = new Pen(Color.Red, 2);
        private SolidBrush brush = new SolidBrush(Color.Red);
        private Color[] colorFeld = { Color.Red, Color.Green, Color.Blue };
        public Form1()
        {
                        InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            z.Clear(BackColor);
            z.DrawLine(pen, 100, 40, 100, 60);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            z = CreateGraphics();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            z.Clear(BackColor);
            z.DrawRectangle(pen, 10, 10, 180, 180);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            z.Clear(BackColor);
            z.DrawEllipse(pen, 10, 10, 20, 20);
        }
    }
}
