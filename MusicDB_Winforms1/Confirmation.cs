﻿using System;
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
        public string EnteredPassword
        {
            get
            {
                return txtConfirm.Text;
            }
        }

        public Confirmation() : this("Enter the password.") { }

        public Confirmation(string message)
        {
            label1.Text = message;
            InitializeComponent();
        }
    }
}
