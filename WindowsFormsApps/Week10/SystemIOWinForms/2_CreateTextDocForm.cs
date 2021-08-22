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
    public partial class CreateTextDocForm : Form
    {
        public CreateTextDocForm()
        {
            InitializeComponent();
        }

        private string directory, fileName;
        private StreamWriter streamWriter;
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            fileName = textBoxFileName.Text;
            streamWriter = File.CreateText(directory + "\\" + fileName + ".txt");
            streamWriter.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                directory = folderBrowserDialog1.SelectedPath;
                textBoxDirectory.Text = directory;
                
            }
        }
    }
}
