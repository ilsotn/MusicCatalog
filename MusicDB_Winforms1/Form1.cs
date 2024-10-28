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
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string albumName = dataGridView1.SelectedRows[0].Cells["AlbumName"].Value.ToString();
                albumLabel.Text = albumName;

                var albumCoverData = dataGridView1.SelectedRows[0].Cells["AlbumCover"].Value as byte[];

                if (albumCoverData != null && albumCoverData.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(albumCoverData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }

                int albumID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlbumID"].Value);
                DataTable songsTable = albumService.GetSongsByAlbumID(albumID);
                dataGridView2.DataSource = songsTable;

                if (songsTable.Columns.Contains("SongID"))
                {
                    dataGridView2.Columns["SongID"].Visible = false;
                }
            }
        }


        private void ReadAlbums(bool showDeleted = false, string artistName = null, string genreName = null, int? startYear = null, int? endYear = null, int? minListeners = null, int? maxListeners = null)
        {
            DataTable albumsTable = albumService.GetAlbums(showDeleted, artistName, genreName, startYear, endYear, minListeners, maxListeners);
            dataGridView1.DataSource = albumsTable;

            if (albumsTable.Columns.Contains("AlbumCover"))
            {
                dataGridView1.Columns["AlbumCover"].Visible = false;
            }

            dataGridView1.Columns["AlbumID"].Visible = false; 
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateAlbum createAlbumForm = new CreateAlbum(_connectionString);
            createAlbumForm.ShowDialog();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Confirmation confirmationForm = new Confirmation();
                if (confirmationForm.ShowDialog() == DialogResult.OK && confirmationForm.EnteredPassword == "123456")
                {
                    int albumID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AlbumID"].Value);
                    albumService.DeleteAlbum(albumID); 
                    ReadAlbums();
                }
                else
                {
                    MessageBox.Show("Incorrect password. Deletion canceled.");
                }
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

                UpdateAlbum updateForm = new UpdateAlbum(albumID, albumName, artistName, genreName, releaseYear, monthlyListeners, _connectionString);
                updateForm.ShowDialog();
                ReadAlbums();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        /*        
                int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
                DataTable dataTable = (DataTable)dataGridView1.DataSource;

                DataRow currentRow = dataTable.Rows[currentRowIndex];
        */
    }
}
