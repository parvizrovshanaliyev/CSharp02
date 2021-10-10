using System;
using System.Linq;
using System.Windows.Forms;
using PhoneBook.Business.Constants;
using PhoneBook.Business.Enums;
using PhoneBook.Business.Services;
using PhoneBook.Core.Repository;
using PhoneBook.Entities;

namespace PhoneBook.UI.WinFormsApp
{
    public partial class PhoneBookForm : Form
    {
        private readonly IContactService _contactService;
        public PhoneBookForm()
        {
            _contactService = new ContactService(new ContactRepository());
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var entity = new Contact()
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Email = textBoxEmail.Text,
                Website = textBoxWebSite.Text,
                Address = textBoxAddress.Text,
                Description = textBoxDescription.Text,
                Number1 = textBoxNumber1.Text,
                Number2 = textBoxNumber2.Text,
                Number3 = textBoxNumber3.Text
            };
            var result = _contactService.Add(entity);

            switch (result)
            {
                case > 0:
                    FillContactListBox();
                    MessageBox.Show(GlobalConstants.AddSuccess, GlobalConstants.AddSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case (int)ResultCodeEnums.ModelStateNoValid:
                    MessageBox.Show(GlobalConstants.ModelStateNotValid, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var selectedItem = (Contact)listBoxContact.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show(GlobalConstants.ModelStateNotValid, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var entity = new Contact()
            {
                Id = selectedItem.Id,
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Email = textBoxEmail.Text,
                Website = textBoxWebSite.Text,
                Address = textBoxAddress.Text,
                Description = textBoxDescription.Text,
                Number1 = textBoxNumber1.Text,
                Number2 = textBoxNumber2.Text,
                Number3 = textBoxNumber3.Text
            };

            var result = _contactService.Update(entity);

            switch (result)
            {
                case > 0:
                    FillContactListBox();
                    MessageBox.Show(GlobalConstants.UpdateSuccess, GlobalConstants.UpdateSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case (int)ResultCodeEnums.ModelStateNoValid:
                    MessageBox.Show(GlobalConstants.ModelStateNotValid, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void buttonExportXml_Click(object sender, EventArgs e)
        {

        }

        private void buttonExportJson_Click(object sender, EventArgs e)
        {

        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {

        }

        private void buttonImportJson_Click(object sender, EventArgs e)
        {

        }
        private void PhoneBookForm_Load(object sender, EventArgs e)
        {
            FillContactListBox();
        }

        private void listBoxContact_DoubleClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            var selectedItem = (Contact)listBox.SelectedItem;
            textBoxName.Text = selectedItem.Name;
            textBoxSurname.Text = selectedItem.Surname;
            textBoxEmail.Text = selectedItem.Email;
            textBoxWebSite.Text = selectedItem.Website;
            textBoxAddress.Text = selectedItem.Address;
            textBoxDescription.Text = selectedItem.Description;
            textBoxNumber1.Text = selectedItem.Number1;
            textBoxNumber2.Text = selectedItem.Number2;
            textBoxNumber3.Text = selectedItem.Number3;
            groupBoxCreateOrUpdate.Text = "Update Contact";
        }

        private void FillContactListBox()
        {
            listBoxContact.DataSource = null;

            var entities = _contactService.GetAll();

            if (entities.Any())
            {
                listBoxContact.DataSource = entities;
            }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedItem = (Contact)listBoxContact.SelectedItem;

            if (selectedItem != null)
            {
                var result = _contactService.Delete(selectedItem.Id);

                switch (result)
                {
                    case > 0:
                        FillContactListBox();
                        MessageBox.Show(GlobalConstants.DeleteSuccess, GlobalConstants.DeleteSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case (int)ResultCodeEnums.ModelStateNoValid:
                        MessageBox.Show(GlobalConstants.ModelStateNotValid, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
    }
}
