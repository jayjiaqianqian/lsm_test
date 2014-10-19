using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;

namespace LSM
{
    /// <summary>
    /// 
    /// </summary>
    class AUC
    {
        private ILayer layer;
        private IMap map;
        private LayerOperator layeroperator;
        public AUC(IMap imap)
        {
            map = imap;
            layeroperator = new LayerOperator(imap);
        }

        /// <summary>
        /// 获取栅格图像像素值，统计每个像素的灾害点数，排序
        /// 按1%面积递增求得灾害点百分比，输出文本文件和AUC曲线
        /// </summary>
        /// <param name="zhdcursor">灾害点矢量要素指针，用于统计灾害点数</param>
        /// <param name="jgtcname">结果图层名，作为每种方法的名称</param>
        /// <param name="saveroute">评价结果文件路径</param>
        public void AUCpingjiafun(List<IPoint> points, string[] jgtcname, string saveroute)
        {
            int l = jgtcname.Length;//表示评价方法个数
            IRasterLayer rasterlayer;
            int height, width;
            double[] area = new Double[l];//记录曲线面积
            double[][] zhdpercent = new double[l][];//记录各百分比面积下的灾害点百分比
            double[][] key = new double[l][];//zhdpercent对应的键
            for (int i = 0; i < l; i++)
            {
                zhdpercent[i] = new double[100];
                key[i] = new double[100];
            }

            //求每种方法的AUC评价结果
            for (int i = 0; i < l; i++)
            {
                layer = null;
                layer = layeroperator.GetLayerByName(jgtcname[i]);
                //   MessageBox.Show(jgtcname[i]);
                if (layer != null)
                {
                    //获取栅格图层的行列数、起点、像素大小、遍历栅格图层获取像素值
                    rasterlayer = layer as IRasterLayer;
                    IRaster raster = rasterlayer.Raster;
                    IRasterProps rasterprops = (IRasterProps)raster;
                    IRaster2 raster2 = raster as IRaster2;
                    //获取图层行列值
                    height = rasterprops.Height;
                    width = rasterprops.Width;
                    //初始化数组用于记录像素值
                    Grid[] Grids = new Grid[height * width];
                    for (int n = 0; n < height * width; n++)
                    {
                        Grids[n] = new Grid(0);
                    }

                    //统计每个像素的灾害点数
                    int zhdSum = StatisticZHDnumber(points, raster2, width, Grids);

                    //遍历栅格图像获取像素值
                    List<Grid> al = GetpixelvalueByTraversal(raster2, width, Grids);

                    if (zhdSum != 0)
                    {
                        //根据危险值概率由高到低对像素进行排序
                        al.Sort(new Gcompare());

                        //按照1%的面积递增，统计对应的灾害点百分比
                        int gl, gm,        //gl表示n%的像素个数，gm表示（n+1）%的像素个数 
                            sum = 0,      //sum表示n%像素内灾害点数
                            len = al.Count;//len表示实际有效的像素个数
                        for (int n = 0; n < 100; n++)
                        {

                            gm = Convert.ToInt32(len * 0.01 * (n + 1));
                            gl = Convert.ToInt32(len * 0.01 * n);
                            for (int g = 0; g < gm - gl; g++)
                            {
                                sum += al[g + gl].zhdnum;
                            }
                            //灾害点百分比计算
                            zhdpercent[i][n] = 1.00 * sum / zhdSum;
                            key[i][n] = n + 1;
                            //  取小数点后四位
                            zhdpercent[i][n] = GetFourDemiacalPlace(zhdpercent[i][n]);


                            //计算曲线面积
                            if (n == 0)
                            {
                                area[i] += 0.01 * zhdpercent[i][n];
                            }
                            else
                            {
                                area[i] += 0.5 * 0.01 * (zhdpercent[i][n] + zhdpercent[i][n - 1]);
                            }

                        }
                        //  取小数点后四位
                        area[i] = GetFourDemiacalPlace(area[i]);

                    }
                    else
                    {
                        MessageBox.Show("图层" + jgtcname[i] + "不存在灾害点！可能是时间未设置正确！");
                    }
                }
            }

            //将灾害点百分比保存到文本中
            string[] methodname = new String[l];
            methodname = SaveAUCresultAsText(saveroute, l, jgtcname, zhdpercent, area);

            //绘制曲线图
            Curve curve2d = new Curve(methodname, zhdpercent, key, area);
            curve2d.YSlice = 0.02;
            Bitmap bmp = curve2d.CreateImage();
            DrawCurve drawcurve = new DrawCurve(bmp);
            drawcurve.Show();
        }


        /// <summary>
        /// 统计每个像素的灾害点数
        /// </summary>
        /// <param name="zhdcursor">灾害点要素指针</param>
        /// <param name="raster2">栅格图像</param>
        /// <param name="width">栅格图像像素列数</param>
        /// <param name="Grids">记录每个像素的灾害点数</param>
        /// <returns>灾害点总个数</returns>
        private int StatisticZHDnumber(List<IPoint> points, IRaster2 raster2, int width, Grid[] Grids)
        {
            //遍历灾害点矢量，统计栅格中的灾害点数
            int zhdSum = 0;
            try
            {
                int Pnum = points.Count;
                for (int i = 0; i < Pnum; i++)
                {
                    double X = points[i].X;
                    double Y = points[i].Y;
                    //获取灾害点的行列号
                    int column = raster2.ToPixelColumn(X);
                    int row = raster2.ToPixelRow(Y);
                    //在相应的类Grid的灾害点数值+1
                    int index = row * width + column;
                    Grids[index].zhdnum++;
                    zhdSum++;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return zhdSum;
        }

        /// <summary>
        ///  遍历栅格图像获取像素值
        /// </summary>
        /// <param name="raster2">栅格图层</param>
        /// <param name="width">栅格图像像素列数</param>
        /// <param name="Grids">记录每个像素的像素值</param>
        /// <returns>记录去除无像素值点后的每个像素值</returns>
        private List<Grid> GetpixelvalueByTraversal(IRaster2 raster2, int width, Grid[] Grids)
        {
            List<Grid> al = new List<Grid>();
            System.Array pixels;
            //定义RasterCursor初始化，参数设为null，内部自动设置PixelBlock大小
            IRasterCursor rastercursor = raster2.CreateCursorEx(null);
            //用于存储PixelBlock的长宽
            long blockwidth = 0;
            long blockheight = 0;
            IPixelBlock3 pPixelBlock3;
            int index;
            //遍历栅格获取像素值
            try
            {
                do
                {
                    //获取Cursor的左上角坐标
                    int left = (int)rastercursor.TopLeft.X;
                    int top = (int)rastercursor.TopLeft.Y;
                    //获取该Cursor的PixelBlock并获取PixelBlock的长宽
                    pPixelBlock3 = rastercursor.PixelBlock as IPixelBlock3;
                    blockwidth = pPixelBlock3.Width;
                    blockheight = pPixelBlock3.Height;
                    //      MessageBox.Show("blockwidth="+blockwidth+";blockheight="+blockheight);
                    //获取该Cursor的PixelBlock块的像素值数组
                    pixels = (System.Array)pPixelBlock3.get_PixelData(0);
                    //获取该Cursor的PixelBlock中像素的值
                    for (int y = 0; y < blockheight; y++)
                    {
                        for (int x = 0; x < blockwidth; x++)
                        {
                            index = (top + y) * width + (left + x);
                            if (pPixelBlock3.GetVal(0, x, y) != null)
                            {
                                Grids[index].value = Convert.ToDouble(pixels.GetValue(x, y));
                                al.Add(Grids[index]);

                            }
                        }
                    }
                } while (rastercursor.Next() == true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return al;
        }

        /// <summary>
        /// 获取double型数字小数点后四位
        /// </summary>
        /// <param name="area">一个double数字</param>
        /// <returns>只有小数点后四位的数</returns>
        private double GetFourDemiacalPlace(double area)
        {
            string are = area.ToString();
            double a;
            int co = are.IndexOf(".");
            if (are.Length >= 7)
            {
                a = Convert.ToDouble(are.Substring(0, co + 5));
                int v = Convert.ToInt32(are.Substring(co + 5, 1));
                if (v > 5)
                {
                    a += 0.0001;
                }

            }
            else
            {
                a = Convert.ToDouble(are);
            }
            return a;
        }


        /// <summary>
        /// 将AUC评价结果保存到文本中
        /// </summary>
        /// <param name="saveroute">保存路径</param>
        /// <param name="l">结果图层数</param>
        /// <param name="jgtcname">结果图层名</param>
        /// <param name="zhdpercent">记录每种方法的灾害点百分比数组</param>
        /// <param name="area">每种方法下的曲线围城的面积</param>
        /// <returns>结果图层名名字部分</returns>
        private string[] SaveAUCresultAsText(string saveroute, int l, string[] jgtcname, double[][] zhdpercent, double[] area)
        {
            //如果文本不存在，创建文本
            StreamWriter sw = new StreamWriter(saveroute, false);
            //表头
            string[] methodname = new string[l];
            int length;
            sw.Write("面积百分比（%）\t");
            for (int n = 0; n < l - 1; n++)
            {
                length = jgtcname[n].LastIndexOf(".");
                methodname[n] = jgtcname[n].Substring(0, length);
                sw.Write(methodname[n] + "（%）\t");
            }
            length = jgtcname[l - 1].LastIndexOf(".");
            methodname[l - 1] = jgtcname[l - 1].Substring(0, length);
            sw.WriteLine(methodname[l - 1] + "（%）");
            //将按1%面积递增的灾害点百分比写入文本中
            for (int m = 0; m < 100; m++)
            {
                sw.Write(Convert.ToString(m + 1) + "\t\t");
                for (int n = 0; n < l - 1; n++)
                {
                    sw.Write(Convert.ToString(zhdpercent[n][m] * 100) + "\t\t");
                }
                sw.WriteLine(Convert.ToString(zhdpercent[l - 1][m] * 100));
            }
            sw.Write("曲线面积\t");
            for (int n = 0; n < l - 1; n++)
            {
                sw.Write(Convert.ToString(area[n]) + "\t\t");
            }
            sw.WriteLine(Convert.ToString(area[l - 1]));
            sw.Close();

            return methodname;
        }
    }
}
