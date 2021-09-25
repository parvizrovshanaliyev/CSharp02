﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    MessageBox.Show(GlobalConstants.AddSuccess, GlobalConstants.AddSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case (int)ResultCodeEnums.ModelStateNoValid:
                    MessageBox.Show(GlobalConstants.ModelStateNotValid, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}