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
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Rows.Add();
            }
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
            string webData = Program.getWebData(yfi);         
            dataGridView1.Rows[0].SetValues(webData.Split('|')[0]);
            int p = printData(webData.Split('|')[1], webData.Split('|')[2], 2, dataGridView1);
        }

        public static int printData(string data1, string data2, int j, DataGridView dgv)
        {
            for (int i = 0; i <=6; i++)
            {
                string s1 = data1.Split(';')[i];
                string s2 = data2.Split(';')[i];
                dgv.Rows[j].Cells[0].Value = s1.Split(':')[0];
                dgv.Rows[j].Cells[1].Value = s1.Split(':')[1];
                dgv.Rows[j].Cells[2].Value = s2.Split(':')[0];
                dgv.Rows[j].Cells[3].Value = s2.Split(':')[1];
                j++;
            }
            /***
            dgv.Rows[j].Cells[2].Value = data2.Split(';')[7].Split('&')[0] + '&' + data2.Split(';')[8].Split(':')[0];
            dgv.Rows[j].Cells[3].Value = data2.Split(';')[8].Split(':')[1];
            j++;
            ***/
            return j;
        }

    }
}
