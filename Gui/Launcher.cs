using HttpApp;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Bbuu20_s_Recoil_Handler_V2
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Process.Start(Bbuu20Api.DOMAIN + "/signup");
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username = UsernameBox.Text;
            String password = PasswordBox.Text;
            MainApp.isUserValid = Bbuu20Api.DoesUserExist(username, password);
            MainApp.isUserOnline = Bbuu20Api.IsUserOnline(username);
            MainApp.isUserAuthorized = Bbuu20Api.IsUserAuthorized(username);
            if (MainApp.isUserValid && !MainApp.isUserOnline && MainApp.isUserAuthorized)
            {
                Bbuu20Api.ChangeLoginStatus(username, password);
                MainApp.username = username;
                MainApp.password = password;
                this.Close();
            }
            else if (!MainApp.isUserValid)
            {
                MessageBox.Show("Invalid username and/or password.\n\nIf you forgot your username/password, or think your account may have been hacked, contact bbuu20. Contact info can be found at bbuu20.com/contact", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MainApp.isUserOnline)
            {
                Bbuu20Api.ChangeLoginStatus(username, password);
                MessageBox.Show("More than one user logged in under username " + username + ". All other instances will be suspended, try login again.\n\nNote: This is probably because the script was closed incorrectly. To avoid this message in the future, please close the script using the X button in the top right.", "Multiple Instances", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("User is unauthorized. You can purchase authorization at bbuu20.com", "User unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Launcher_Load(object sender, EventArgs e)
        {

        }
    }
}
