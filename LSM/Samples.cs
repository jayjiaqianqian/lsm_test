using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesRaster;
using System.IO;

namespace LSM
{
    /// <summary>
    /// 样本类，用于训练样本、待评估样本的计算
    /// </summary>
    class Samples
    {
        public Samples()
        { 
        }


        /// <summary>
        /// 在区间[minValue,maxValue]取出num个互不相同的随机数，返回的SortedSet包含着结果
        /// </summary>
        /// <param name="num">随机数的数目</param>
        /// <param name="minValue">随机数的下限</param>
        /// <param name="maxValue">随机数的上限</param>
        /// <returns></returns>
        public SortedSet<int> getRandomNum(int num, int minValue, int maxValue)
        {
            //存放随机数 SortedSet可保证数的唯一性和有序性
            SortedSet<int> ranValSet = new SortedSet<int>();
            //将当前时间的计时周期数作为种子，每次都可得到不同的随机种子，保证随机数的随机性
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int tmp;
            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    tmp = ra.Next(minValue, maxValue); //得到随机取数
                    //往SortedSet对象中添加数
                    //若添加成功,则表示取出来的数字和已取得的数字没有重复，跳出while循环，获取下个数
                    //若添加失败，就重新随机获取
                    if (ranValSet.Add(tmp))
                    {
                        break;
                    }
                }

            }
            return ranValSet;
        }



        /// <summary>
        /// 生成样本数据的第一种方法，用raster2.ToPixelColumn、.ToPixelRow判断点所在的行列号
        /// 代码较简洁些，所用时间比第二种方法多1s左右
        /// 遍历点数据集，获取与点相交的格网的像元值，并根据保存路径，生成训练/待评估样本文件
        /// </summary>
        /// <param name="pointList">点数据集（可能是灾害点+非灾害点，也可能是基准图层网格中心点）</param>
        /// <param name="rasterList">栅格数据集</param>
        /// <param name="firstline">文件的第一行信息，显示字段名</param>
        /// <param name="localFilePath">文件保存路径</param>
        /// <param name="pList">各点发生灾害的概率值</param>
        public Boolean genSampleFile(List<CPoint> pointList, List<IRaster> rasterList, string firstline, string localFilePath, List<int> pList)
        {
            string sPixelValue, lineMsg = "";//存储像元值和每行数据
            int x, y;//记录点要素所在的网格的行列号

            try
            {
                List<System.Array> pSafeArrayList = new List<System.Array>();//存储像元值
                List<IRaster2> raster2List = new List<IRaster2>();//存储栅格
                List<string> noDataValueList = new List<string>();///存储每个栅格数据用于标识无效数据的数值
                //记录栅格数组的界限 也可认为是行列号的上下界
                int[] xMin = new int[rasterList.Count];
                int[] xMax = new int[rasterList.Count];
                int[] yMin = new int[rasterList.Count];
                int[] yMax = new int[rasterList.Count];
                IRaster raster;
                IRaster2 raster2;
                IRasterProps pRasterProps;
                IPnt pBlockSize = new Pnt();
                IPixelBlock pPixelBlock;
                IRasterBandCollection pRasterBands;
                IRasterBand pRasterBand;
                IRawPixels pRawRixels;

                //遍历栅格数据，获取其参数信息及像元值
                //像元值放入pSafeArrayList中
                //可避免每次获取值时的都重复raster.read操作，从而提高效率
                for (int i = 0; i < rasterList.Count; i++)
                {
                    raster = rasterList[i]; 
                    raster2 = raster as IRaster2;
                    raster2List.Add(raster2);

                    //获取栅格数据的参数信息
                    pRasterProps = raster as IRasterProps;
                    byte[] noDataValueByte = ((byte[])(pRasterProps.NoDataValue));
                    noDataValueList.Add(Convert.ToString(noDataValueByte[0]));//用于标识无效数据的数值
                
                    //选取整个范围 
                    pBlockSize.SetCoords(pRasterProps.Width, pRasterProps.Height);
                    pPixelBlock = raster.CreatePixelBlock(pBlockSize);
                    //左上点坐标  
                    IPnt tlp = new Pnt();
                    tlp.SetCoords(0, 0);
                    //读入栅格  
                    pRasterBands = raster as IRasterBandCollection;
                    pRasterBand = pRasterBands.Item(0);
                    pRawRixels = pRasterBands.Item(0) as IRawPixels;
                    pRawRixels.Read(tlp, pPixelBlock);

                    //将PixBlock的值组成数组,放入pSafeArrayList中
                    pSafeArrayList.Add(pPixelBlock.get_SafeArray(0) as System.Array);
                    //获取数组的界限 也可认为是行列号的上下界
                    xMin[i] = pSafeArrayList[i].GetLowerBound(0);
                    yMin[i] = pSafeArrayList[i].GetLowerBound(1);
                    xMax[i] = pSafeArrayList[i].GetUpperBound(0);
                    yMax[i] = pSafeArrayList[i].GetUpperBound(1);

                }


                //实例化一个StreamWriter对象，如果该文件存在，则将其覆盖
                StreamWriter sw = new StreamWriter(localFilePath, false);
                //将首行数据写入训练样本文件中
                sw.WriteLine(firstline);

                //遍历点数据集，获取与点相交的格网的像元值，将数据读入txt文件
                for (int i = 0; i < pointList.Count; i++)
                {
                    //点要素的x、y坐标
                    double px = pointList[i].X;
                    double py = pointList[i].Y;

                    //遍历栅格数据集 
                    //pSafeArrayList中每个元素存储一个栅格数据的所有像元值
                    for (int j = 0; j < raster2List.Count; j++)
                    {

                        raster2 = raster2List[j];
                        //记录点要素所在的网格的行列号
                        x = raster2.ToPixelColumn(px); 
                        y = raster2.ToPixelRow(py);

                        //xMin[j]、xMax[j]、yMin[j]、yMax[j]是行列号的上下界
                        if ((x >= xMin[j] && x <= xMax[j]) && (y >= yMin[j] && y <= yMax[j]))//点在栅格数据内
                        {
                            sPixelValue = Convert.ToString(pSafeArrayList[j].GetValue(x, y));//获取像元值

                            if (sPixelValue == noDataValueList[j])//获取的值是无效的值
                            {
                                sPixelValue = "";
                            }
                        }
                        else//点在栅格数据外
                        {
                            sPixelValue = "";
                        }
                       

                        lineMsg = lineMsg + sPixelValue + "\t";


                    }

                    //若有概率值（针对训练样本），则将概率放入lineMsg中
                    if (pList != null)
                    {
                        lineMsg = lineMsg + pList[i];
                    }

                    //将该行数据写入待评估样本文件中
                    sw.WriteLine(lineMsg);
                    lineMsg = "";//置为空，为下一行数据做准备

                }//遍历点集结束

                sw.Close();
                return true;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        /// <summary>
        /// 生成样本数据的第二种方法，自行写代码判断点所在的行列号，已测试可用
        /// 代码较复杂些，所用时间比第一种方法少1s左右
        /// 遍历点数据集，获取与点相交的格网的像元值，并根据保存路径，生成训练/待评估样本文件
        /// </summary>
        /// <param name="pointList">点数据集（可能是灾害点+非灾害点，也可能是基准图层网格中心点）</param>
        /// <param name="rasterList">栅格数据集</param>
        /// <param name="firstline">文件的第一行信息，显示字段名</param>
        /// <param name="localFilePath">文件保存路径</param>
        /// <param name="pList">各点发生灾害的概率值</param>
        public Boolean genSampleFile2(List<CPoint> pointList, List<IRaster> rasterList, string firstline, string localFilePath, List<int> pList)
        {
            string sPixelValue, lineMsg = "";//存储像元值和每行数据
            int x, y;//记录点要素所在的网格的行列号

            try
            {
                List<System.Array> pSafeArrayList = new List<System.Array>();//存储像元值
                List<RasterProperties> rasterPropsList = new List<RasterProperties>();//存储栅格数据的参数信息
                IRaster raster;
                IRasterProps pRasterProps;
                IEnvelope extent;
                IPnt pBlockSize = new Pnt();
                IPixelBlock pPixelBlock;
                IRasterBandCollection pRasterBands;
                IRasterBand pRasterBand;
                IRawPixels pRawRixels;

                //遍历栅格数据，获取其参数信息，并放入rasterPropsList中，
                //这些参数信息在判断点落在哪个网格内时会用到，
                //放入rasterPropsList中，可避免每次获取参数时的都重复下面的步骤，从而提高效率
                for (int i = 0; i < rasterList.Count; i++)
                {
                    raster = rasterList[i];
                    //获取栅格数据的参数信息
                    pRasterProps = raster as IRasterProps;
                    RasterProperties rasterProperties = new RasterProperties();//自定义的存储参数信息的结构
                    rasterProperties.dX = pRasterProps.MeanCellSize().X; //网格的宽度
                    rasterProperties.dY = pRasterProps.MeanCellSize().Y; //网格的高度
                    rasterProperties.dHeight = pRasterProps.Height;//栅格数据的行数
                    rasterProperties.dWidth = pRasterProps.Width;//栅格数据的列数
                    byte[] noDataValueByte = ((byte[])(pRasterProps.NoDataValue));
                    rasterProperties.NoDataValue = Convert.ToString(noDataValueByte[0]);//用于标识无效数据的数值

                    extent = pRasterProps.Extent; //栅格数据的范围
                    //取范围的xMin、yMin、xMax和yMax
                    rasterProperties.xMin = extent.XMin;
                    rasterProperties.yMin = extent.YMin;
                    rasterProperties.xMax = extent.XMax;
                    rasterProperties.yMax = extent.YMax;
                    //将设置好的参数对象放入list中
                    rasterPropsList.Add(rasterProperties);

                    //选取整个范围 
                    pBlockSize.SetCoords(pRasterProps.Width, pRasterProps.Height);
                    pPixelBlock = raster.CreatePixelBlock(pBlockSize);
                    //左上点坐标  
                    IPnt tlp = new Pnt();
                    tlp.SetCoords(0, 0);
                    //读入栅格  
                    pRasterBands = raster as IRasterBandCollection;
                    pRasterBand = pRasterBands.Item(0);
                    pRawRixels = pRasterBands.Item(0) as IRawPixels;
                    pRawRixels.Read(tlp, pPixelBlock);

                    //将PixBlock的值组成数组,放入pSafeArrayList中
                    pSafeArrayList.Add(pPixelBlock.get_SafeArray(0) as System.Array);

                }


                //实例化一个StreamWriter对象，如果该文件存在，则将其覆盖
                StreamWriter sw = new StreamWriter(localFilePath, false);
                //将首行数据写入训练样本文件中
                sw.WriteLine(firstline);
                lineMsg = "";//置为空，为下一行数据做准备

                //遍历点数据集，获取与点相交的格网的像元值，将数据读入txt文件
                for (int i = 0; i < pointList.Count; i++)
                {
                    //点要素的x、y坐标
                    double px = pointList[i].X;
                    double py = pointList[i].Y;

                    //遍历栅格数据集 
                    //pSafeArrayList中每个元素存储一个栅格数据的所有像元值
                    for (int j = 0; j < pSafeArrayList.Count; j++)
                    {
                        double dX = rasterPropsList[j].dX; //网格的宽度
                        double dY = rasterPropsList[j].dY;  //网格的高度

                        //取范围的xMin、yMin、xMax和yMax，从而为后续判断点落在哪个网格内作准备
                        double xMin = rasterPropsList[j].xMin;
                        double yMin = rasterPropsList[j].yMin;
                        double xMax = rasterPropsList[j].xMax;
                        double yMax = rasterPropsList[j].yMax;
                        //Data value used to indicate invalid or excluded data
                        string sNoDataValue = rasterPropsList[j].NoDataValue;

                        if ((px >= xMin && px <= xMax) && (py >= yMin && py <= yMax))//点落在栅格数据内
                        {
                            //计算点要素所在的行列号 
                            //栅格数据的行列号是从左上角起算的,
                            //栅格和矢量数据所在的地理坐标是从左下角起算
                            x = (int)((px - xMin) / dX); //取左不取右
                            y = (int)((yMax - py) / dY); //取上不取下

                            if (py == yMin)//对落在最下边的点进行处理
                            {
                                y = rasterPropsList[j].dHeight - 1;
                            }

                            if (px == xMax)//对落在最右边的点进行处理
                            {
                                x = rasterPropsList[j].dWidth - 1;
                            }

                            sPixelValue = Convert.ToString(pSafeArrayList[j].GetValue(x, y));

                            if (sPixelValue == sNoDataValue)//获取的值是无效的值
                            {
                                sPixelValue = "";
                            }


                        }
                        else
                        {
                            sPixelValue = "";//点落在栅格数据外

                        }

                        lineMsg = lineMsg + sPixelValue + "\t";


                    }////遍历栅格数据集结束

                    //若有概率值（针对训练样本），则将概率放入lineMsg中
                    if (pList != null)
                    {
                        lineMsg = lineMsg + pList[i];
                    }

                    //将该行数据写入待评估样本文件中
                    sw.WriteLine(lineMsg);
                    lineMsg = "";//置为空，为下一行数据做准备

                }//遍历点集结束

                sw.Close();
                return true;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


    }
}
