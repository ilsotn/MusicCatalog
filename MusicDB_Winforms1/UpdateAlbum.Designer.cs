namespace MusicDB_Winforms1
{
    partial class UpdateAlbum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonthlyListeners = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAlbumCover
            // 
            this.pictureBoxAlbumCover.Location = new System.Drawing.Point(19, 30);
            this.pictureBoxAlbumCover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxAlbumCover.Size = new System.Drawing.Size(200, 199);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(225, 162);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(228, 114);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 74);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(225, 30);
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Location = new System.Drawing.Point(395, 162);
            // 
            // txtGenreName
            // 
            this.txtGenreName.Location = new System.Drawing.Point(395, 117);
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(395, 74);
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.Location = new System.Drawing.Point(395, 30);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(548, 228);
            this.btnAddSong.Size = new System.Drawing.Size(151, 46);
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(621, 14);
            // 
            // btnSelectCover
            // 
            this.btnSelectCover.Location = new System.Drawing.Point(17, 235);
            this.btnSelectCover.Click += new System.EventHandler(this.btnSelectCover_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 278);
            this.button1.Size = new System.Drawing.Size(829, 49);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(700, 228);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Size = new System.Drawing.Size(148, 46);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(225, 206);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 25);
            this.label5.TabIndex = 72;
            this.label5.Text = "Monthly Listeners:";
            // 
            // txtMonthlyListeners
            // 
            this.txtMonthlyListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMonthlyListeners.Location = new System.Drawing.Point(395, 202);
            this.txtMonthlyListeners.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMonthlyListeners.Name = "txtMonthlyListeners";
            this.txtMonthlyListeners.Size = new System.Drawing.Size(148, 30);
            this.txtMonthlyListeners.TabIndex = 71;
            this.txtMonthlyListeners.Text = "0";
            // 
            // UpdateAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 336);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMonthlyListeners);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UpdateAlbum";
            this.Text = "Update Album";
            this.Controls.SetChildIndex(this.txtMonthlyListeners, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.txtSongName, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.txtSongDuration, 0);
            this.Controls.SetChildIndex(this.pictureBoxAlbumCover, 0);
            this.Controls.SetChildIndex(this.txtAlbumName, 0);
            this.Controls.SetChildIndex(this.txtArtistName, 0);
            this.Controls.SetChildIndex(this.txtGenreName, 0);
            this.Controls.SetChildIndex(this.txtReleaseYear, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnAddSong, 0);
            this.Controls.SetChildIndex(this.btnSelectCover, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtMonthlyListeners;
    }
}