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
using System.Net;
using HtmlAgilityPack;

namespace ShapeFit
{
    public partial class Form1 : Form
    {
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
           
        }
      
        private void InitTable()
        {
            dataTable = new DataTable("ShapeFitDataTable");
            dataTable.Columns.Add("Menu Item", typeof(string));
            dataTable.Columns.Add("Size", typeof(string));
            dataTable.Columns.Add("Calories", typeof(string));
            dataTable.Columns.Add("Total Fat", typeof(string));
            dataTable.Columns.Add("Sat-Fat", typeof(string));
            dataTable.Columns.Add("Fiber", typeof(string));
            dataTable.Columns.Add("Protein", typeof(string));
            dataTable.Columns.Add("Carbs", typeof(string));
            dataTable.Columns.Add("Sodium", typeof(string));

            dataGridView1.DataSource = dataTable;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            InitTable();   
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Uri url = new Uri("https://www.shapefit.com/restaurants/atlanta-bread-company-calories.html");
            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//table/tbody/tr");

            foreach (var baslik in basliklar)
            {
                HtmlNodeCollection tds = baslik.SelectNodes("td");
                dataTable.Rows.Add(
                    tds[0].InnerText, 
                    tds[1].InnerText, 
                    tds[2].InnerText,
                    tds[3].InnerText, 
                    tds[4].InnerText, 
                    tds[5].InnerText,
                    tds[6].InnerText,
                    tds[7].InnerText,
                    tds[8].InnerText

                    );
               

            }
        }
    }
}
