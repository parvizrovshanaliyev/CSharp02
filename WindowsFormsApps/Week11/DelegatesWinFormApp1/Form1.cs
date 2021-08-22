using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesWinFormApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public delegate void AddObjHandler();

        private void addButton_Click(object sender, EventArgs e)
        {
            // v1
            Add(AddChair);
            Add(AddTable);

            // v2 
            //AddObjHandler addObjHandler = null;
            //addObjHandler += AddChair;
            //addObjHandler += AddTable;

            //Add(addObjHandler);
        }


        private void Add(AddObjHandler addObjHandler)
        {
            addObjHandler.Invoke();
            //
            //addObjHandler();
        }

        private void AddChair()
        {
            listBox1.Items.Add("chair");
        }

        private void AddTable()
        {
            listBox1.Items.Add("table");
        }
    }
}
