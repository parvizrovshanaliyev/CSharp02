using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Enter the name of the class you want to get information from", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.BackColor=Color.BurlyWood;
            }
            textBox1.BackColor = Color.White;

            Type type= Type.GetType(textBox1.Text);

            if (type is null)
            {
                MessageBox.Show("not found", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.BackColor = Color.BurlyWood;
            }

            Ctors(type);
            Props(type);
            Methods(type);

        }

        private void Ctors(Type type)
        {
            var list = type.GetConstructors().ToList();

            list.ForEach(i =>
            {
                listBox1.Items.Add(i.DeclaringType?.Name + " " + i.ToString());
            });
        }
        private void Props(Type type)
        {
            var list = type.GetProperties().ToList();

            list.ForEach(i =>
            {
                listBox2.Items.Add(i.DeclaringType?.Name + " " + i.ToString());
            });
        }

        private void Methods(Type type)
        {
            var list = type.GetMethods().ToList();

            list.ForEach(i =>
            {
                listBox3.Items.Add(i.DeclaringType?.Name + " " + i.ToString());
            });
        }
    }
}
