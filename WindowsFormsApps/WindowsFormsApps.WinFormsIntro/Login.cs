using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApps.WinFormsIntro.Context;

namespace WindowsFormsApps.WinFormsIntro
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //var text=loginBtn.Text;

            //Button button = (Button)sender;

            //var text2=button.Text;

            //MessageBox.Show(text,"xeta",MessageBoxButtons.OK,MessageBoxIcon.Error);



            //Home home = new Home(username);

            //home.Show();

            #region login
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;


            var user = VirtualDatabase.dataList.Find(i => i.Username == username && i.Password == password);

            if (user != null)
            {
                Home home = new Home(user);

                home.Show();
            }
            else
            {
                MessageBox.Show("daxil edilen melumatlar dogru deyil", "Xeta", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            #endregion
        }
    }
}
