using System;
using System.Drawing;
using System.Windows.Forms;
using PhoneBook.Business.Constants;
using PhoneBook.Business.Enums;
using PhoneBook.Business.Services;
using PhoneBook.Core.Repository;
using PhoneBook.Entities;

namespace PhoneBook.UI.WinFormsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            textBox.BackColor = Color.DarkGray;
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxUsername.Text)&& !string.IsNullOrEmpty(txtBoxPassword.Text))
            {

                IUserService userService = new UserService(new UserRepository());

                var user = new User()
                {
                    Username = txtBoxUsername.Text,
                    Password = txtBoxPassword.Text
                };
                var result = userService.Login(user);

                switch (result)
                {
                    case > 0:
                        PhoneBookForm form = new PhoneBookForm();
                        form.Show();
                        break;
                    case (int)ResultCodeEnums.ModelStateNoValid:
                        MessageBox.Show(GlobalConstants.Required, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        MessageBox.Show(GlobalConstants.InvalidAttempt, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

            }
            else
            {
                MessageBox.Show(GlobalConstants.Required, GlobalConstants.CaptionInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
