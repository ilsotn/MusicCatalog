using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDB_Winforms1
{
    public partial class Confirmation : Form
    {
        public string EnteredPassword { get; private set; }

        public Confirmation()
        {
            InitializeComponent();
        }

        private void btnProceed_Click_Click(object sender, EventArgs e)
        {
            EnteredPassword = txtConfirm.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void ChangeLabel(string label)
        {
            label1.Text = label;
        }
    }
}
