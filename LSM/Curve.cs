using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LSM
{
    /// <summary>
    /// 绘制曲线统计图类，参数name,key,value为曲线名，曲线x值，曲线y值
    /// 曲线的其它参数如标题、坐标最小刻度值等可通过属性进行设置，默认有缺省值
    /// 属性title、XUnit、YUnit、XText、YText分别表示是曲线标题、X轴单位、Y轴单位、X轴刻度数值、Y轴刻度数值
    /// 属性XSlice、YSlice、colors分别表示X轴最小刻度数值、Y轴最小刻度数值、曲线颜色
    /// </summary>
    public class Curve
    {
        public string title = "AUC结果评价图";   //曲线坐标
        public string XUnit = "面积百分比(%)";                //x轴单位
        public string YUnit = "灾害点百分比(%)";              //y轴单位
        public string[] XText = { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };//x轴刻度值
        public string[] YText = { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };//y轴刻度值
        public double XSlice = 2.0;//x轴最小数值间距
        public double YSlice = 2.0;//x轴最小数值间距
        public Color[] colors = { Color.Red, Color.Green, Color.Pink, Color.Yellow, Color.Purple, Color.Gold };
        private double[][] value;
        private double[][] key;
        private string[] curvename;
        private double[] area;

        public Curve(string[] name, double[][] val, double[][] k, double[] ar)
        {
            value = val;
            key = k;
            curvename = new string[name.Length];
            curvename = name;
            area = ar;
        }

        public Bitmap CreateImage()
        {
            int height = 620, width = 850;
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //清空图片背景色
                g.Clear(Color.White);

                Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
                Font font1 = new System.Drawing.Font("宋体", 20, FontStyle.Regular);
                Font font2 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
                LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
                g.FillRectangle(Brushes.AliceBlue, 0, 0, width, height);
                Brush brush1 = new SolidBrush(Color.Blue);
                Brush brush2 = new SolidBrush(Color.SaddleBrown);
                Brush[] brushs = new SolidBrush[curvename.Length];
                for (int i = 0; i < curvename.Length; i++)
                {
                    brushs[i] = new SolidBrush(colors[i]);
                }

                g.DrawString(title, font1, brush1, new PointF(250, 30));
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);

                Pen mypen = new Pen(brush, 1);
                Pen mypen2 = new Pen(Color.Red, 2);


                //绘制线条
                //绘制x轴及其坐标值
                Pen xypen = new Pen(Color.Blue, 3);
                g.DrawLine(xypen, 80, 570, 590, 570);
                int x = 80, count = 1;
                g.DrawString(XText[0], font, Brushes.Red, x + 3, 575);
                for (int i = 1; i <= (XText.Length - 1) * 5; i++)
                {
                    x += 10;
                    if (count == 5)
                    {
                        g.DrawLine(mypen, x, 570, x, 70);
                        g.DrawString(XText[i / 5], font, Brushes.Red, x + 3, 575);
                        count = 1;
                    }
                    else
                    {
                        g.DrawLine(mypen, x, 570, x, 565);
                        count++;
                    }

                }
                Font text = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
                g.DrawString(XUnit, text, brush1, 500, 590);


                //绘制Y轴及其坐标值
                g.DrawLine(xypen, 78, 572, 78, 60);
                int y = 570; count = 1;
                g.DrawString(YText[0], font, Brushes.Red, 60, y - 3);
                for (int i = 1; i <= (YText.Length - 1) * 5; i++)
                {
                    y = y - 10;
                    if (count == 5)
                    {
                        g.DrawLine(mypen, 80, y, 580, y);
                        g.DrawString(YText[i / 5], font, Brushes.Red, 40, y - 3);
                        count = 1;
                    }
                    else
                    {
                        g.DrawLine(mypen, 80, y, 85, y);
                        count++;
                    }
                }
                int yindex = YUnit.IndexOf("(");
                int j = 0;
                if (yindex != -1)
                {
                    for (; j <= yindex; j++)
                    {
                        g.DrawString(Convert.ToString(YUnit[j]), text, brush1, 10, 60 + 20 * j);
                    }
                    for (j = 0; j < 2; j++)
                    {
                        g.DrawString(Convert.ToString(YUnit[j + yindex + 1]), text, brush1, 15 + 15 * j, 60 + 20 * yindex);
                    }
                }
                else
                {
                    for (; j < YUnit.Length; j++)
                    {
                        g.DrawString(Convert.ToString(YUnit[j]), text, brush1, 10, 60 + 20 * j);
                    }
                }


                //绘制曲线+说明框
                double xslice = 10.0 / XSlice;
                double yslice = 10.0 / YSlice;
                if (key.Length == value.Length)
                {
                    j = curvename.Length;
                    g.DrawRectangle(new Pen(Brushes.Red), 600, 250, 220, 25 * (j + 1));
                    g.DrawString("曲线", font2, Brushes.Blue, 605, 255);
                    g.DrawString("名称", font2, Brushes.Blue, 670, 255);
                    g.DrawString("曲线下的面积", font2, Brushes.Blue, 735, 255);
                    for (j = 0; j < curvename.Length; j++)
                    {
                        if (key[j].Length == value[j].Length)
                        {
                            g.FillRectangle(brushs[j], 607, 275 + 20 * j, 20, 10);
                            g.DrawString(curvename[j], font2, brushs[j], 650, 275 + 20 * j);
                            g.DrawString(Convert.ToString(area[j]), font2, brushs[j], 750, 275 + 20 * j);

                            //画曲线
                            PointF[] points = new PointF[key[j].Length + 1];
                            points[0].X = 80;
                            points[0].Y = 570;
                            //count = 1;
                            for (int z = 0; z < 100; z++)
                            {
                                points[z + 1].X = (float)(80 + key[j][z] * xslice);
                                points[z + 1].Y = (float)(570 - value[j][z] * yslice);
                                //if (count == 10)
                                //{
                                //    g.DrawString(Convert.ToString(value[j][z]), font2, brushs[j], points[z + 1].X, points[z + 1].Y - 25);
                                //    count = 1;
                                //}
                                //else
                                //{
                                //    count++;
                                //}
                            }
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.DrawCurve(new Pen(brushs[j], 2), points, (float)0.1);

                        }
                        else
                        {
                            g.DrawString("曲线" + curvename[j] + "输入的键值个数不等", font1, Brushes.Red, j * 100, j * 100);
                        }
                    }
                }
                else
                {
                    g.DrawString("输入的键值个数不等", font1, Brushes.Red, 300, 300);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return image;
        }
    }

}