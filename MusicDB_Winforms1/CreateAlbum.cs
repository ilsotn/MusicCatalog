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
    public partial class CreateAlbum : Form
    {
        private AlbumService albumService;

        public CreateAlbum(string connectionString)
        {
            InitializeComponent();
            albumService = new AlbumService(connectionString); 
        }

        private void btnCreateAlbum_Click(object sender, EventArgs e)
        {
            Confirmation confirmationForm = new Confirmation();
            if (confirmationForm.ShowDialog() == DialogResult.OK && confirmationForm.EnteredPassword == "123456")
            {
                string albumName = txtAlbumName.Text;
                string artistName = txtArtistName.Text;
                string genreName = txtGenreName.Text;
                int releaseYear = string.IsNullOrEmpty(txtReleaseYear.Text) ? DateTime.Now.Year : int.Parse(txtReleaseYear.Text);

                albumService.CreateAlbum(albumName, artistName, genreName, releaseYear, 0); 
                this.Close();
            }
        }
    }
}
