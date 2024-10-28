using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDB_Winforms1
{
    public partial class UpdateAlbum : Form
    {
        private int albumID;
        private AlbumService albumService;
        private byte[] albumCoverData;  


        public UpdateAlbum(int albumID, string albumName, string artistName, string genreName, int releaseYear, int monthlyListeners, string connectionString)
        {
            InitializeComponent();
            this.albumID = albumID;
            albumService = new AlbumService(connectionString);

            txtAlbumName.Text = albumName;
            txtArtistName.Text = artistName;
            txtGenreName.Text = genreName;
            txtReleaseYear.Text = releaseYear.ToString();
            txtMonthlyListeners.Text = monthlyListeners.ToString();
        }

        private void btnConfirm_Click_Click(object sender, EventArgs e)
        {
            Confirmation confirmationForm = new Confirmation();
            if (confirmationForm.ShowDialog() == DialogResult.OK && confirmationForm.EnteredPassword == "123456")
            {
                string albumName = txtAlbumName.Text;
                string artistName = txtArtistName.Text;
                string genreName = txtGenreName.Text;
                int releaseYear = string.IsNullOrEmpty(txtReleaseYear.Text) ? DateTime.Now.Year : int.Parse(txtReleaseYear.Text);
                int monthlyListeners = string.IsNullOrEmpty(txtMonthlyListeners.Text) ? 0 : int.Parse(txtMonthlyListeners.Text);

                albumService.UpdateAlbum(albumID, albumName, artistName, genreName, releaseYear, monthlyListeners, albumCoverData);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBoxAlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxAlbumCover.Image = Image.FromFile(openFileDialog.FileName);

                    albumCoverData = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
        }
    }
}