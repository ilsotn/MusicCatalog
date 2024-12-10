using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;  
using System.Net;
using System.Drawing;
using System.IO;

namespace MusicDB_Winforms1
{
    public partial class Form1 : Form
    {
        private bool _isAdminMode;
        private AlbumService albumService;
        private string _connectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged; 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (ConnectionSettingsForm settingsForm = new ConnectionSettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    _connectionString = settingsForm.ConnectionString;
                    _isAdminMode = settingsForm.IsAdminMode; 
                }
                else
                {
                    MessageBox.Show("Connection settings are required to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            try
            {
                albumService = new AlbumService(_connectionString);
                ReadAlbums();
            }
            catch (SqlException)
            {
                MessageBox.Show("Invalid credentials. Unable to connect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            btnCreate.Enabled = _isAdminMode;
            btnUpdate.Enabled = _isAdminMode;
            btnDelete.Enabled = _isAdminMode;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int albumID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlbumID"].Value);
                string albumName = albumService.GetAlbumName(albumID);
                albumLabel.Text = albumName ?? "Unknown Album";

                Image albumImage = albumService.GetAlbumCoverAsImage(albumID); 
                pictureBox1.Image = albumImage;

                DataTable songsTable = albumService.GetPreparedSongsTable(albumID); 
                dataGridView2.DataSource = songsTable;
            }
        }



        private void ReadAlbums(bool showDeleted = false, string artistName = null, string genreName = null, int? startYear = null, int? endYear = null, int? minListeners = null, int? maxListeners = null)
        {
            DataTable albumsTable = albumService.GetAlbums(showDeleted, artistName, genreName, startYear, endYear, minListeners, maxListeners);
            dataGridView1.DataSource = albumsTable;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateAlbum createAlbumForm = new CreateAlbum(_connectionString);
            createAlbumForm.AlbumCreated += OnAlbumCreated; 
            createAlbumForm.ShowDialog();
        }

        private void OnAlbumCreated()
        {
            ReadAlbums();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No albums to delete.");
                return;
            }

            Confirmation confirmationForm = new Confirmation("Are you sure you want to delete? If so type YES");

            if (confirmationForm.ShowDialog() == DialogResult.OK && albumService.ConfirmDeletion(confirmationForm.EnteredPassword))
            {
                int albumID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlbumID"].Value);
                albumService.DeleteAlbum(albumID);
                ReadAlbums();
            }
            else
            {
                MessageBox.Show("Deletion canceled.");
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int albumID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlbumID"].Value);
                string albumName = dataGridView1.SelectedRows[0].Cells["AlbumName"].Value.ToString();
                string artistName = dataGridView1.SelectedRows[0].Cells["ArtistName"].Value.ToString();
                string genreName = dataGridView1.SelectedRows[0].Cells["GenreName"].Value.ToString();
                int releaseYear = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReleaseYear"].Value);
                int monthlyListeners = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MonthlyListeners"].Value);
                byte[] albumCoverData = dataGridView1.SelectedRows[0].Cells["AlbumCover"].Value as byte[];

                DataTable songsTable = albumService.GetSongsByAlbumID(albumID);
                UpdateAlbum updateForm = new UpdateAlbum(
                    albumID,
                    albumName,
                    artistName,
                    genreName,
                    releaseYear,
                    monthlyListeners,
                    _connectionString,
                    songsTable
                );

                updateForm.ShowDialog();
                ReadAlbums();
            }
            else
            {
                MessageBox.Show("Please select an album to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
