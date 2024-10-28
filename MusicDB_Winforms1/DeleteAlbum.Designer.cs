namespace MusicDB_Winforms1
{
    partial class DeleteAlbum
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlbumID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirm_Click
            // 
            this.btnConfirm_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirm_Click.Location = new System.Drawing.Point(60, 56);
            this.btnConfirm_Click.Name = "btnConfirm_Click";
            this.btnConfirm_Click.Size = new System.Drawing.Size(145, 37);
            this.btnConfirm_Click.TabIndex = 41;
            this.btnConfirm_Click.Text = "Confirm";
            this.btnConfirm_Click.UseVisualStyleBackColor = true;
            this.btnConfirm_Click.Click += new System.EventHandler(this.btnConfirm_Click_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Album ID:";
            // 
            // txtAlbumID
            // 
            this.txtAlbumID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAlbumID.Location = new System.Drawing.Point(113, 18);
            this.txtAlbumID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAlbumID.Name = "txtAlbumID";
            this.txtAlbumID.Size = new System.Drawing.Size(148, 30);
            this.txtAlbumID.TabIndex = 39;
            // 
            // DeleteAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 113);
            this.Controls.Add(this.btnConfirm_Click);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlbumID);
            this.Name = "DeleteAlbum";
            this.Text = "Delete an album";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm_Click;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlbumID;
    }
}