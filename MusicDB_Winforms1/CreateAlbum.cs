using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MusicDB_Winforms1
{
    public partial class CreateAlbum : AlbumForm
    {
        private List<(string SongName, int Duration)> songsList = new List<(string SongName, int Duration)>();
        public event Action AlbumCreated;

        public CreateAlbum(string connectionString)
        {
            InitializeComponent();
            InitializeAlbumService(connectionString);

            dataGridViewSongs.Columns.Add("SongName", "Song Name");
            dataGridViewSongs.Columns.Add("Duration", "Duration (sec)");
        }

        private void btnCreateAlbum_Click(object sender, EventArgs e)
        {
            Confirmation confirmationForm = new Confirmation();
            if (confirmationForm.ShowDialog() == DialogResult.OK && confirmationForm.EnteredPassword == "123456")
            {
                try
                {
                    string albumName = txtAlbumName.Text;
                    string artistName = txtArtistName.Text;
                    string genreName = txtGenreName.Text;
                    int releaseYear = string.IsNullOrEmpty(txtReleaseYear.Text) ? DateTime.Now.Year : int.Parse(txtReleaseYear.Text);

                    albumService.CreateAlbumWithSongs(albumName, artistName, genreName, releaseYear, 0, songsList, albumCoverData);
                    AlbumCreated?.Invoke(); 
                    MessageBox.Show("Album created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating album: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            try
            {
                string songName = txtSongName.Text;

                if (int.TryParse(txtDuration.Text, out int duration) && !string.IsNullOrWhiteSpace(songName))
                {
                    int minutes = duration / 60;
                    int seconds = duration % 60;
                    string formattedDuration = $"{minutes}:{seconds:D2}";

                    songsList.Add((songName, duration));
                    dataGridViewSongs.Rows.Add(songName, formattedDuration);

                    txtSongName.Clear();
                    txtDuration.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter a valid song name and duration (in seconds).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding song: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnSelectCover_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddSong_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
