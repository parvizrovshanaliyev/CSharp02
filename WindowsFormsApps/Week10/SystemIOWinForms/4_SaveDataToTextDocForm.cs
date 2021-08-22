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
    public partial class SaveDataToTextDocForm : Form
    {
        public SaveDataToTextDocForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Tex Docments|*txt";
            saveFileDialog1.Title = "Save Data To Text Document";
            saveFileDialog1.ShowDialog();
            StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
            streamWriter.WriteLine(richTextBox1.Text);
            streamWriter.Close();
            MessageBox.Show("Created");

        }
    }
}
