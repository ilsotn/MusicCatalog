using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MusicDB_Winforms1
{
    public partial class ConnectionSettingsForm : Form
    {
        public string ServerName 
        {
            get
            {
                if (string.IsNullOrEmpty(txtServerName.Text))
                {
                    MessageBox.Show("Please fill in all fields (Server Name, Database Name, Username, and Password).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
                return txtServerName.Text;
            }
        }
        public string DatabaseName
        {
            get
            {
                if (string.IsNullOrEmpty(txtDatabaseName.Text))
                {
                    MessageBox.Show("Please fill in all fields (Server Name, Database Name, Username, and Password).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
                return txtDatabaseName.Text;
            }
        }
        public string Username
        {
            get
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Please fill in all fields (Server Name, Database Name, Username, and Password).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
                return txtUsername.Text;
            }
        }
        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please fill in all fields (Server Name, Database Name, Username, and Password).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
                return txtPassword.Text;
            }
        }

        public string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = ServerName,
                    InitialCatalog = DatabaseName,
                    UserID = Username,
                    Password = Password
                };

                return sqlConnectionStringBuilder.ConnectionString;
            }
        }

        public ConnectionSettingsForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void txtServerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
