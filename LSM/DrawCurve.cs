using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSM
{
    public partial class DrawCurve : Form
    {

        public DrawCurve(Bitmap bmp)
        {
            InitializeComponent();
            //展示曲线图
            Drawcurve_pictureBox.Image = bmp;
        }

        private void AUCimagesave_Click(object sender, EventArgs e)
        {
            SaveFileDialog pjjgimage;
            pjjgimage = new SaveFileDialog();
            pjjgimage.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            pjjgimage.Title = "保存图片";
            pjjgimage.ShowDialog();
            if (pjjgimage.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)pjjgimage.OpenFile();
                switch (pjjgimage.FilterIndex)
                {
                    case 1:
                        this.Drawcurve_pictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.Drawcurve_pictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.Drawcurve_pictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        this.Drawcurve_pictureBox.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                }
                fs.Close();

            }
        }
    }
}
