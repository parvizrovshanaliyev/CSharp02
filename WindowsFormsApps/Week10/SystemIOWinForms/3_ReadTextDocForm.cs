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

namespace SystemIOWinForms
{
    public partial class ReadTextDocForm : Form
    {
        public ReadTextDocForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                string row = streamReader.ReadLine();
                while (row != null)
                {
                    listBox1.Items.Add(row);
                    row = streamReader.ReadLine();
                }
            }
        }
    }
}
