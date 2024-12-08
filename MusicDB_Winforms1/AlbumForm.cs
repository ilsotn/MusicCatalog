using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusicDB_Winforms1
{
    public partial class AlbumForm : Form
    {
        protected AlbumService albumService;
        public PictureBox pictureBoxAlbumCover;
        public Label label4;
        public Label label3;
        public Label label2;
        public Label label1;
        public TextBox txtReleaseYear;
        public TextBox txtGenreName;
        public TextBox txtArtistName;
        public TextBox txtAlbumName;
        public DataGridView dataGridViewSongs;
        public Button btnAddSong;
        public Label label7;
        public Label label6;
        public Button btnSelectCover;
        public TextBox txtSongName;
        public Button button1;
        public TextBox txtSongDuration;
        public Button button2;
        protected byte[] albumCoverData;

        public AlbumForm()
        {
            InitializeComponent();
            // Common initialization for both forms
            pictureBoxAlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected void InitializeAlbumService(string connectionString)
        {
            albumService = new AlbumService(connectionString);
        }



        private void InitializeComponent()
        {
            this.pictureBoxAlbumCover = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.txtGenreName = new System.Windows.Forms.TextBox();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.txtAlbumName = new System.Windows.Forms.TextBox();
            this.dataGridViewSongs = new System.Windows.Forms.DataGridView();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectCover = new System.Windows.Forms.Button();
            this.txtSongName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSongDuration = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSongs)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAlbumCover
            // 
            this.pictureBoxAlbumCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxAlbumCover.Location = new System.Drawing.Point(13, 12);
            this.pictureBoxAlbumCover.Name = "pictureBoxAlbumCover";
            this.pictureBoxAlbumCover.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAlbumCover.TabIndex = 55;
            this.pictureBoxAlbumCover.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(220, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 25);
            this.label4.TabIndex = 63;
            this.label4.Text = "Release Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(220, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 62;
            this.label3.Text = "Album Genre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(220, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "Artist Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(220, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "Album Name:";
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtReleaseYear.Location = new System.Drawing.Point(393, 140);
            this.txtReleaseYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(148, 30);
            this.txtReleaseYear.TabIndex = 59;
            this.txtReleaseYear.Text = "2024";
            // 
            // txtGenreName
            // 
            this.txtGenreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtGenreName.Location = new System.Drawing.Point(393, 96);
            this.txtGenreName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGenreName.Name = "txtGenreName";
            this.txtGenreName.Size = new System.Drawing.Size(148, 30);
            this.txtGenreName.TabIndex = 58;
            this.txtGenreName.Text = "No Genre";
            // 
            // txtArtistName
            // 
            this.txtArtistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtArtistName.Location = new System.Drawing.Point(393, 53);
            this.txtArtistName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(148, 30);
            this.txtArtistName.TabIndex = 57;
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAlbumName.Location = new System.Drawing.Point(393, 9);
            this.txtAlbumName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAlbumName.Name = "txtAlbumName";
            this.txtAlbumName.Size = new System.Drawing.Size(148, 30);
            this.txtAlbumName.TabIndex = 56;
            // 
            // dataGridViewSongs
            // 
            this.dataGridViewSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSongs.Location = new System.Drawing.Point(548, 90);
            this.dataGridViewSongs.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSongs.Name = "dataGridViewSongs";
            this.dataGridViewSongs.RowHeadersWidth = 51;
            this.dataGridViewSongs.Size = new System.Drawing.Size(299, 122);
            this.dataGridViewSongs.TabIndex = 69;
            // 
            // btnAddSong
            // 
            this.btnAddSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddSong.Location = new System.Drawing.Point(548, 219);
            this.btnAddSong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(144, 37);
            this.btnAddSong.TabIndex = 68;
            this.btnAddSong.Text = "Add Song";
            this.btnAddSong.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(551, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 25);
            this.label7.TabIndex = 67;
            this.label7.Text = "Duration (sec):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(622, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 66;
            this.label6.Text = "Name:";
            // 
            // btnSelectCover
            // 
            this.btnSelectCover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectCover.Location = new System.Drawing.Point(12, 217);
            this.btnSelectCover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectCover.Name = "btnSelectCover";
            this.btnSelectCover.Size = new System.Drawing.Size(201, 39);
            this.btnSelectCover.TabIndex = 70;
            this.btnSelectCover.Text = "Choose Image";
            this.btnSelectCover.UseVisualStyleBackColor = true;
            this.btnSelectCover.Click += new System.EventHandler(this.btnSelectCover_Click_1);
            // 
            // txtSongName
            // 
            this.txtSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSongName.Location = new System.Drawing.Point(700, 11);
            this.txtSongName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.Size = new System.Drawing.Size(148, 30);
            this.txtSongName.TabIndex = 71;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(13, 260);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(836, 49);
            this.button1.TabIndex = 72;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtSongDuration
            // 
            this.txtSongDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSongDuration.Location = new System.Drawing.Point(700, 52);
            this.txtSongDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSongDuration.Name = "txtSongDuration";
            this.txtSongDuration.Size = new System.Drawing.Size(148, 30);
            this.txtSongDuration.TabIndex = 73;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(698, 217);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 37);
            this.button2.TabIndex = 74;
            this.button2.Text = "Delete Song";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AlbumForm
            // 
            this.ClientSize = new System.Drawing.Size(858, 316);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSongDuration);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSongName);
            this.Controls.Add(this.btnSelectCover);
            this.Controls.Add(this.dataGridViewSongs);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.txtGenreName);
            this.Controls.Add(this.txtArtistName);
            this.Controls.Add(this.txtAlbumName);
            this.Controls.Add(this.pictureBoxAlbumCover);
            this.Name = "AlbumForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSongs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectCover_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
