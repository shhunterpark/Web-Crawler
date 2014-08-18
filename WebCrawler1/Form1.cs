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

namespace WebCrawler1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string webPage = Program.getWebPage(url);
            StreamWriter sw = new StreamWriter("webpage.txt");
            
            sw.Write(webPage);
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string yfi = "https://finance.yahoo.com/q?s="+textBox2.Text+"&ql=1";
            Program.getWebData(yfi);
        }

    }
}
