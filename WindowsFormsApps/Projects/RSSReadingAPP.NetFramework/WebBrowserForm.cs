using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using RSSReadingAPP.NetFramework.Models;

namespace RSSReadingAPP.NetFramework
{
    public partial class WebBrowserForm : Form
    {
        public WebBrowserForm()
        {
            InitializeComponent();
        }

        private void buttonGET_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = SerializeToObj(textBoxURL.Text);
        }

        private List<News> SerializeToObj(string data)
        {
            XDocument xDocument= XDocument.Load(data);

            var news = xDocument.Descendants("item")
                .Select(i => new News()
                {
                    Title = i.Element("title")?.Value,
                    Description = i.Element("description")?.Value,
                    Link = i.Element("link")?.Value
                }).ToList();

            return news;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox) sender;
            News selectedNews = (News) listBox.SelectedItem;
            webBrowser1.Navigate(selectedNews.Link);
        }

        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }
    }
}
