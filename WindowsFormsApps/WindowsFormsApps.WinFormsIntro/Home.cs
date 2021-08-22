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
using WindowsFormsApps.WinFormsIntro.Models;

namespace WindowsFormsApps.WinFormsIntro
{
    public partial class Home : Form
    {
        public Home(User user)
        {
            InitializeComponent();

            usernameTxt.Text = user.Username;
            usernameTxt.Enabled = false;
            passwordtxt.Text = user.Password;
            nameTxt.Text = user.Name;
            surnameTxt.Text = user.Surname;
            descTextArea.Text = user.Desc;
            updateBtn.Tag = user.Id;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Button updateBtn = (Button) sender;

            int userId = (int) updateBtn.Tag;

            var userIndex = VirtualDatabase.dataList.FindIndex(i => i.Id == userId);

            VirtualDatabase.dataList[userIndex].Password=passwordtxt.Text;
            VirtualDatabase.dataList[userIndex].Name=nameTxt.Text;
            VirtualDatabase.dataList[userIndex].Surname=surnameTxt.Text;
            VirtualDatabase.dataList[userIndex].Desc = descTextArea.Text;
            MessageBox.Show("Ugurla redakte edildi gelen goruslere dek");
        }
    }
}
