namespace LSM
{
    partial class DrawCurve
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
            this.AUCimagesave = new System.Windows.Forms.Button();
            this.Drawcurve_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Drawcurve_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AUCimagesave
            // 
            this.AUCimagesave.Location = new System.Drawing.Point(642, 12);
            this.AUCimagesave.Name = "AUCimagesave";
            this.AUCimagesave.Size = new System.Drawing.Size(50, 23);
            this.AUCimagesave.TabIndex = 4;
            this.AUCimagesave.Text = "保存";
            this.AUCimagesave.UseVisualStyleBackColor = true;
            this.AUCimagesave.Click += new System.EventHandler(this.AUCimagesave_Click);
            // 
            // Drawcurve_pictureBox
            // 
            this.Drawcurve_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawcurve_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.Drawcurve_pictureBox.Name = "Drawcurve_pictureBox";
            this.Drawcurve_pictureBox.Size = new System.Drawing.Size(703, 513);
            this.Drawcurve_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Drawcurve_pictureBox.TabIndex = 3;
            this.Drawcurve_pictureBox.TabStop = false;
            // 
            // DrawCurve
            // 
            this.AcceptButton = this.AUCimagesave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 513);
            this.Controls.Add(this.AUCimagesave);
            this.Controls.Add(this.Drawcurve_pictureBox);
            this.Name = "DrawCurve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUC结果评价曲线图";
            ((System.ComponentModel.ISupportInitialize)(this.Drawcurve_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AUCimagesave;
        private System.Windows.Forms.PictureBox Drawcurve_pictureBox;
    }
}