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
    public partial class DeleteAlbum : Form
    {
        private int albumID;
        private AlbumService albumService;

        public DeleteAlbum(int albumID, string connectionString)
        {
            InitializeComponent();
            this.albumID = albumID;
            albumService = new AlbumService(connectionString);
        }
        private void btnConfirm_Click_Click(object sender, EventArgs e)
        {
            Confirmation confirmationForm = new Confirmation();

            if (confirmationForm.ShowDialog() == DialogResult.OK && confirmationForm.EnteredPassword == "123456")
            {
                try
                {
                    albumService.DeleteAlbum(albumID);
                    MessageBox.Show("Album deleted (soft delete) successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the album: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Incorrect password. Deletion canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}