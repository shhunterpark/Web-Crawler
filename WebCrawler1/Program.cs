using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace WebCrawler1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //get WebPage content
        public static string getWebPage(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string webPage = sr.ReadToEnd();
            sr.Close();
            resp.Close();

            return webPage;
        }

        //get WebPage data
        public static string getWebData(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            var name = doc.DocumentNode.SelectSingleNode("//div[@id='yfi_rt_quote_summary']//h2").InnerText;
            HtmlNode t1 = doc.DocumentNode.SelectSingleNode("//div[@id='yfi_quote_summary_data']//table[@id='table1']");
            HtmlNode t2 = doc.DocumentNode.SelectSingleNode("//div[@id='yfi_quote_summary_data']//table[@id='table2']");
            var t1_data = getTable(t1);
            var t2_data = getTable(t2);
            var img = doc.DocumentNode.SelectSingleNode("//div[@id='yfi_summary_chart']//img").GetAttributeValue("src", null);

            string webData = name + '|' + t1_data + '|' + t2_data + '|' + img;

            /***
            StreamWriter sw = new StreamWriter("webdata.txt");
            sw.Write(webData);
            sw.Close();
            ***/

            return webData;
        }

        public static string getTable(HtmlNode table)
        {
            var data = "";
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                data += row.InnerText + ";";
            }
            return data;
        }
    }
}
