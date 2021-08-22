using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemIOWinForms
{
    public partial class SystemIOFakeDataForm : Form
    {
        private Data data;
        private List<Employer> employers;
        public SystemIOFakeDataForm()
        {
            InitializeComponent();

            data = new Data();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            employers = data.GetAll(150);
            listBox1.DataSource = employers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            data.SaveData(@"c:\test",employers);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Employer employer = (Employer) listBox1.SelectedItem;
            textBoxName.Text = employer.Name;
            textBoxSurname.Text = employer.Surname;
            textBoxCountry.Text = employer.Country;
            textBoxCompany.Text = employer.Company;
            textBoxEmail.Text = employer.Email;
        }
    }
}
