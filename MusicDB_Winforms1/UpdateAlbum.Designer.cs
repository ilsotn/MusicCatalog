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
            this.btnConfirm_Click = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.txtGenreName = new System.Windows.Forms.TextBox();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.txtAlbumName = new System.Windows.Forms.TextBox();
            this.txtMonthlyListeners = new System.Windows.Forms.TextBox();
            this.dads = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBoxAlbumCover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm_Click
            // 
            this.btnConfirm_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirm_Click.Location = new System.Drawing.Point(203, 228);
            this.btnConfirm_Click.Name = "btnConfirm_Click";
            this.btnConfirm_Click.Size = new System.Drawing.Size(145, 37);
            this.btnConfirm_Click.TabIndex = 49;
            this.btnConfirm_Click.Text = "Confirm";
            this.btnConfirm_Click.UseVisualStyleBackColor = true;
            this.btnConfirm_Click.Click += new System.EventHandler(this.btnConfirm_Click_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(50, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 25);
            this.label4.TabIndex = 47;
            this.label4.Text = "Release Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(53, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "Album Genre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(66, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "Artist Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Album Name:";
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtReleaseYear.Location = new System.Drawing.Point(199, 151);
            this.txtReleaseYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(148, 30);
            this.txtReleaseYear.TabIndex = 42;
            this.txtReleaseYear.Text = "2024";
            // 
            // txtGenreName
            // 
            this.txtGenreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtGenreName.Location = new System.Drawing.Point(199, 107);
            this.txtGenreName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGenreName.Name = "txtGenreName";
            this.txtGenreName.Size = new System.Drawing.Size(148, 30);
            this.txtGenreName.TabIndex = 41;
            this.txtGenreName.Text = "No Genre";
            // 
            // txtArtistName
            // 
            this.txtArtistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtArtistName.Location = new System.Drawing.Point(199, 64);
            this.txtArtistName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(148, 30);
            this.txtArtistName.TabIndex = 40;
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAlbumName.Location = new System.Drawing.Point(199, 20);
            this.txtAlbumName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAlbumName.Name = "txtAlbumName";
            this.txtAlbumName.Size = new System.Drawing.Size(148, 30);
            this.txtAlbumName.TabIndex = 39;
            // 
            // txtMonthlyListeners
            // 
            this.txtMonthlyListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMonthlyListeners.Location = new System.Drawing.Point(198, 194);
            this.txtMonthlyListeners.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMonthlyListeners.Name = "txtMonthlyListeners";
            this.txtMonthlyListeners.Size = new System.Drawing.Size(148, 30);
            this.txtMonthlyListeners.TabIndex = 50;
            this.txtMonthlyListeners.Text = "0";
            // 
            // dads
            // 
            this.dads.AutoSize = true;
            this.dads.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dads.Location = new System.Drawing.Point(15, 197);
            this.dads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dads.Name = "dads";
            this.dads.Size = new System.Drawing.Size(171, 25);
            this.dads.TabIndex = 51;
            this.dads.Text = "Monthly Listeners:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(354, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 53;
            this.button1.Text = "Choose Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxAlbumCover
            // 
            this.pictureBoxAlbumCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxAlbumCover.Location = new System.Drawing.Point(354, 20);
            this.pictureBoxAlbumCover.Name = "pictureBoxAlbumCover";
            this.pictureBoxAlbumCover.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAlbumCover.TabIndex = 54;
            this.pictureBoxAlbumCover.TabStop = false;
            // 
            // UpdateAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 278);
            this.Controls.Add(this.pictureBoxAlbumCover);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dads);
            this.Controls.Add(this.txtMonthlyListeners);
            this.Controls.Add(this.btnConfirm_Click);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.txtGenreName);
            this.Controls.Add(this.txtArtistName);
            this.Controls.Add(this.txtAlbumName);
            this.Name = "UpdateAlbum";
            this.Text = "UpdateAlbum";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm_Click;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.TextBox txtGenreName;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.TextBox txtAlbumName;
        private System.Windows.Forms.TextBox txtMonthlyListeners;
        private System.Windows.Forms.Label dads;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBoxAlbumCover;
    }
}