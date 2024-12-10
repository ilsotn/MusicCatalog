using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace MusicDB_Winforms1
{
    public partial class UpdateAlbum : AlbumForm
    {
        private int albumID;
        private DataTable songsTable;

        public UpdateAlbum(
            int albumID, string albumName, string artistName, string genreName,
            int releaseYear, int monthlyListeners, string connectionString, DataTable songsTable)
        {
            InitializeComponent();
            InitializeAlbumService(connectionString);

            this.albumID = albumID;
            txtAlbumName.Text = albumName;
            txtArtistName.Text = artistName;
            txtGenreName.Text = genreName;
            txtReleaseYear.Text = releaseYear.ToString();
            txtMonthlyListeners.Text = monthlyListeners.ToString();

            this.songsTable = songsTable;

            ConfigureSongsTable(songsTable); // Use the new helper function
        }

        private void ConfigureSongsTable(DataTable songsTable)
        {
            dataGridViewSongs.DataSource = songsTable;

            if (songsTable.Columns.Contains("SongID"))
            {
                songsTable.Columns["SongID"].ColumnMapping = MappingType.Hidden;
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string albumName = txtAlbumName.Text;
                string artistName = txtArtistName.Text;
                string genreName = txtGenreName.Text;
                int releaseYear = albumService.ParseIntOrDefault(txtReleaseYear.Text, DateTime.Now.Year);
                int monthlyListeners = albumService.ParseIntOrDefault(txtMonthlyListeners.Text, 0);

                // Update album using AlbumService
                albumService.UpdateAlbum(albumID, albumName, artistName, genreName, releaseYear, monthlyListeners, albumCoverData);

                MessageBox.Show("Album updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating album: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnSelectCover_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    // DONE: exceptions
                    try
                    {
                        Image albumCover = Image.FromFile(openFileDialog.FileName);
                        pictureBoxAlbumCover.Image = albumCover;
                        albumCoverData = albumService.ConvertImageToByteArray(albumCover);
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("The file does not have a valid image format or is corrupted.", "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("The specified file could not be found. Please select a valid file.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("The file path is invalid or is a URI. Please select a valid local image file.", "Invalid File Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnAddSong_Click(object sender, EventArgs e)
        {
            try
            {
                string songName = txtSongName.Text;
                if (string.IsNullOrWhiteSpace(songName))
                {
                    MessageBox.Show("Please enter a valid song name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSongDuration.Text, out int duration) || duration <= 0)
                {
                    MessageBox.Show("Please enter a valid duration in seconds.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add song to the database and update the table
                albumService.AddSongToAlbum(albumID, songName, duration);
                albumService.AddSongToTable(songsTable, songName, duration);

                txtSongName.Clear();
                txtSongDuration.Clear();

                MessageBox.Show("Song added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error adding song: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewSongs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a song to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // DONE tryparse
                var selectedValue = dataGridViewSongs.SelectedRows[0].Cells["SongID"].Value;
                if (selectedValue == null || !int.TryParse(selectedValue.ToString(), out int songID))
                {
                    MessageBox.Show("Invalid Song ID. Please select a valid song.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this song?",
                                                     "Confirm Deletion",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Delete song from the database and update the table
                    albumService.DeleteSongFromAlbum(songID, albumID);
                    albumService.RemoveSongFromTable(songsTable, songID);

                    MessageBox.Show("Song deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting song: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
