using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace MusicDB_Winforms1
{
    public partial class UpdateAlbum : AlbumForm
    {
        private int albumID;
        private DataTable songsTable;
        public event Action AlbumUpdated;

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

            dataGridViewSongs.DataSource = songsTable;

            if (songsTable.Columns.Contains("SongID"))
            {
                dataGridViewSongs.Columns["SongID"].Visible = false;
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string albumName = txtAlbumName.Text;
                string artistName = txtArtistName.Text;
                string genreName = txtGenreName.Text;
                int releaseYear = string.IsNullOrEmpty(txtReleaseYear.Text) ? DateTime.Now.Year : int.Parse(txtReleaseYear.Text);
                int monthlyListeners = string.IsNullOrEmpty(txtMonthlyListeners.Text) ? 0 : int.Parse(txtMonthlyListeners.Text);

                albumService.UpdateAlbum(albumID, albumName, artistName, genreName, releaseYear, monthlyListeners, albumCoverData);

                MessageBox.Show("Album updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlbumUpdated?.Invoke();
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
                    try
                    {
                        Image albumCover = Image.FromFile(openFileDialog.FileName);
                        pictureBoxAlbumCover.Image = albumCover;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            albumCover.Save(ms, albumCover.RawFormat);
                            albumCoverData = ms.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading cover image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                albumService.AddSongToAlbum(albumID, songName, duration);

                DataRow newRow = songsTable.NewRow();
                newRow["SongName"] = songName;
                newRow["Duration"] = duration;
                songsTable.Rows.Add(newRow);

                txtSongName.Clear();
                txtSongDuration.Clear();

                MessageBox.Show("Song added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding song: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewSongs.SelectedRows.Count > 0)
            {
                try
                {
                    int songID = Convert.ToInt32(dataGridViewSongs.SelectedRows[0].Cells["SongID"].Value);

                    var confirmResult = MessageBox.Show("Are you sure you want to delete this song?",
                                                        "Confirm Deletion",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        albumService.DeleteSongFromAlbum(songID, albumID);

                        foreach (DataRow row in songsTable.Rows)
                        {
                            if (Convert.ToInt32(row["SongID"]) == songID)
                            {
                                songsTable.Rows.Remove(row);
                                break;
                            }
                        }


                        MessageBox.Show("Song deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting song: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a song to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
