using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTest
{
    public partial class Form1 : Form
    {
        public int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Service1 serv = new Service1();
            serv.In();
            i = 0;
        }
        
    }
}
