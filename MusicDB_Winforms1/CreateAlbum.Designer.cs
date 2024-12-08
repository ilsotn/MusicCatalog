namespace MusicDB_Winforms1
{
    partial class CreateAlbum
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
            this.txtDuration = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(220, 145);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(222, 98);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(232, 58);
            // 
            // txtGenreName
            // 
            this.txtGenreName.Location = new System.Drawing.Point(393, 93);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click_1);
            // 
            // btnSelectCover
            // 
            this.btnSelectCover.Click += new System.EventHandler(this.btnSelectCover_Click);
            // 
            // button1
            // 
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(0, 0);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 22);
            this.txtDuration.TabIndex = 0;
            // 
            // CreateAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 321);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateAlbum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new album";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSongName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnSelectCover;
    }
}