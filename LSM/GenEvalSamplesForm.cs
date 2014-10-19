using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;

namespace LSM
{
    public partial class GenEvalSamplesForm : Form
    {
        //保存当前地图对象
        private IMap mMap;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="map">当前地图对象</param>
        public GenEvalSamplesForm(IMap map)
        {
            InitializeComponent();
            mMap = map;
        }

        /// <summary>
        /// 装载窗口的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenEvalSamplesForm_Load(object sender, EventArgs e)
        {
            try
            {
                //判断地图对象是否为空。若为空，函数返回空
                if (mMap == null)
                {
                    return;
                }
                else
                {
                    //对地图对象中的所有图层进行遍历。若是栅格图层，将图层名放入相应的控件中
                    for (int i = 0; i < mMap.LayerCount; i++)
                    {
                        ILayer layer = mMap.get_Layer(i);
                        IRasterLayer rasLayer = layer as IRasterLayer;

                        ////将影响因子栅格图层名加入“基准图层”combox和“可选影响因子图层”的listbox中
                        if (rasLayer != null)
                        {
                            baseLayerCmBox.Items.Add(rasLayer.Name);
                            listBox1.Items.Add(rasLayer.Name);
                        }

                    }

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// “基准图层”combox的SelectedIndexChanged响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseLayerCmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sBaseLayerName = baseLayerCmBox.SelectedItem.ToString();
            LayerOperator layerOperator = new LayerOperator(mMap);
            //获取用户选择的基准图层
            IRasterLayer baseRasLayer = layerOperator.GetLayerByName(sBaseLayerName) as IRasterLayer;
            //获取栅格数据参数信息
            IRasterProps  rasterProps = baseRasLayer.Raster as IRasterProps;
            double baseLayerdX = rasterProps.MeanCellSize().X; //基准图层像元的宽度
            double baseLayerdY = rasterProps.MeanCellSize().Y; //基准图层像元的高度
            if (baseLayerdX != baseLayerdY)
            {
                DialogResult result;
                result = MessageBox.Show("基准图层像元的高度和宽度不一致,请重新选择图层!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        /// <summary>
        /// “可选影响因子图层”全部移动到“选中影响因子图层”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllToRightBt_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            if (this.listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    list.Add(listBox1.Items[i].ToString());
                }
                //将“可选影响因子图层”listbox的items
                //加入到“选中影响因子图层”的listbox中
                for (int j = 0; j < list.Count; j++)
                {
                    this.listBox2.Items.Add(list[j]);
                }
                //清空“可选影响因子图层”的listbox
                this.listBox1.Items.Clear();
            }

        }


        /// <summary>
        ///  将被选中的“可选影响因子图层”移动到“选中影响因子图层”的listbox中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToRightBt_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                //将部分被选中的“可选影响因子图层”添加到“选中影响因子图层”的listbox中
                foreach (var item in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(item.ToString());
                }
                this.listBox2.SelectedIndex = this.listBox2.Items.Count - 1;
                //移除“可选影响因子图层”listbox中被选中的图层
                for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                    i--;
                }
            }
        }


        /// <summary>
        /// 将被选中的“选中影响因子图层”移动到“可选影响因子图层”的listbox中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToLeftBt_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems != null)
            {
                //将部分被选中的“选中影响因子图层”添加到“可选影响因子图层”的listbox中
                foreach (var item in listBox2.SelectedItems)
                {
                    listBox1.Items.Add(item.ToString());
                }
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                //移除“选中影响因子图层”listbox中被选中的图层
                for (int i = 0; i < listBox2.SelectedIndices.Count; i++)
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndices[i]);
                    i--;
                }
            }
        }


        /// <summary>
        /// “选中影响因子图层”全部移动到“可选影响因子图层”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllToLeftBt_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            if (this.listBox2.Items.Count > 0)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    list.Add(listBox2.Items[i].ToString());
                }
                //将“选中影响因子图层”listbox的items
                //加入到“可选影响因子图层”的listbox中
                for (int j = 0; j < list.Count; j++)
                {
                    this.listBox1.Items.Add(list[j]);
                }
                //清空“选中影响因子图层”的listbox
                this.listBox2.Items.Clear();
            }
        }


        /// <summary>
        /// “浏览”按钮点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseBt_Click(object sender, EventArgs e)
        {
            
            string localFilePath;
            //保存对话框
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件类型
            saveFileDialog.Filter = " txt files(*.txt)|*.txt";
            //保存对话框是否记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;
            //点了保存按钮进入
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径，并写入相应的文本框
                localFilePath = saveFileDialog.FileName.ToString();
                savePathTxtBox.Text = localFilePath;

            }

            this.saveBt.Focus();//使“保存”按钮获得焦点
        }


        /// <summary>
        /// “保存”按钮点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBt_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //stopwatch.Start();//计时

            this.Cursor = Cursors.WaitCursor; //单击时修改鼠标光标形状
            try
            {
                string localFilePath, sRasLayerName, sBaseLayerName, sResampleMethod, firstLine="";
                LayerOperator layerOperator = new LayerOperator(mMap);//实例化图层操作类              
                List<IRaster> rasterList = new List<IRaster>();//存储选中的影响因子图层的栅格数据
                List<CPoint> cPointList = new List<CPoint>();//存储基准图层格网的中心点
                //遍历被选中的影响因子图层时要用的变量
                IRasterLayer rasLayer,baseRasLayer;
                IRaster raster;
                IRasterProps rasterProps;
                IEnvelope extent;
                //重采样要用的变量
                esriGeoAnalysisResampleEnum resampleType=new esriGeoAnalysisResampleEnum();
                ITransformationOp transop = new RasterTransformationOpClass();
                IGeoDataset inDataset, outDataset;
                IRasterDataset outRasterDataset;
                IRaster resampledRaster;
                //存储基准图层网格中心点的X、Y地理坐标值
                double cX,cY;

                //获得文件保存路径
                localFilePath = savePathTxtBox.Text.Trim().ToString();

                //判断用户是否有选择基准图层、影响因子图层,保存路径
                sBaseLayerName = baseLayerCmBox.Text.ToString();
                if (sBaseLayerName == "")
                {
                    MessageBox.Show("请选择基准图层!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (listBox2.Items.Count == 0)
                {
                    MessageBox.Show("请选择影响因子图层!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (localFilePath == "" || localFilePath == null)
                {
                    MessageBox.Show("请选择保存路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //若用户手动输入保存路径，而且不是以.txt结尾,则为其加上后缀
                if (!localFilePath.EndsWith(".txt") && !localFilePath.EndsWith(".TXT"))
                {
                    localFilePath = localFilePath + ".txt";
                }


                //获取用户选择的基准图层
                baseRasLayer = layerOperator.GetLayerByName(sBaseLayerName) as IRasterLayer;
                //获取栅格数据参数信息
                rasterProps = baseRasLayer.Raster as IRasterProps;
                double baseLayerdX = rasterProps.MeanCellSize().X; //基准图层像元的宽度
                double baseLayerdY = rasterProps.MeanCellSize().Y; //基准图层像元的高度
                int baseLayerdHeight = rasterProps.Height;//基准图层栅格数据的行数
                int baseLayerdWidth = rasterProps.Width; //基准图层栅格数据的列数
                extent = rasterProps.Extent; //基准图层栅格数据的范围
                //取基准图层的xMin、yMin、xMax和yMax地理坐标，从而为后续计算格网中心点的坐标作准备
                double baseLayerXMin = extent.XMin;
                double baseLayerYMin = extent.YMin;
                double baseLayerXMax = extent.XMax;
                double baseLayerYMax = extent.YMax;

                if (baseLayerdX != baseLayerdY)
                {
                     DialogResult result;
                     result = MessageBox.Show("基准图层像元的高度和宽度不一致,请重新选择图层!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                }


                //获取用户选择的重采样方法
                sResampleMethod = resampleMethodCmBox.Text.Trim().ToString();
                switch (sResampleMethod)
                {
                    case "最邻近法": resampleType = esriGeoAnalysisResampleEnum.esriGeoAnalysisResampleNearest; break;
                    case "双线性内插法": resampleType = esriGeoAnalysisResampleEnum.esriGeoAnalysisResampleBilinear; break;
                    case "三次卷积插值法": resampleType = esriGeoAnalysisResampleEnum.esriGeoAnalysisResampleCubic; break;
                    default: break;
                }

                //根据图层名获取被选中的影响因子图层及栅格数据
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    sRasLayerName = listBox2.Items[i].ToString();
                    //文本文件的首行，显示字段名
                    firstLine = firstLine + sRasLayerName.Substring(0, sRasLayerName.IndexOf(".")) + "\t";
                    
                    rasLayer =layerOperator.GetLayerByName(sRasLayerName) as IRasterLayer;
                    raster = rasLayer.Raster;
                    rasterProps = raster as IRasterProps;

                    //如果用户选择了采样方法，且图层的cellsize和基准图层的不一致，则进行重采样
                    if (sResampleMethod != "无" && (rasterProps.MeanCellSize().X != baseLayerdX || rasterProps.MeanCellSize().Y != baseLayerdY))
                    {
                        //进行栅格数据重采样
                        inDataset = raster as IGeoDataset;
                        //调用ITransformationOp的Resample方法实现重采样
                        outDataset = transop.Resample(inDataset, baseLayerdX, resampleType);
                        outRasterDataset = (IRasterDataset)outDataset;
                        //获得重采样后的栅格数据,并加入rasterList中
                        resampledRaster = outRasterDataset.CreateDefaultRaster();
                    }
                    else//否则直接将raster值赋给resampledRaster
                    {
                        resampledRaster = raster;
                    }

                    rasterList.Add(resampledRaster);

                }


                Samples samples = new Samples();//实例化样本类
                cX = baseLayerXMin + baseLayerdX / 2;//第一个格网（位于左上角）的中心的X地理坐标
                cY = baseLayerYMax - baseLayerdY / 2;//第一个格网（位于左上角）的中心的Y地理坐标
               
                //遍历基准图层格网，获取格网的中心点
                CPoint cPoint = new CPoint();//自定义的点类 
                for (int row = 0; row < baseLayerdHeight; row++)
                {
                    
                    for (int col = 0; col < baseLayerdWidth; col++)
                    {             
                        cPoint.X = cX;
                        cPoint.Y = cY;
                        cPointList.Add(cPoint);
                        cX = cX + baseLayerdX;//该行下一格网的中心点X地理坐标
                  
                    }

                    cX = baseLayerXMin + baseLayerdX / 2;//下一行第一格网的中心点X地理坐标
                    cY = cY - baseLayerdY;//下一行第一格网的中心点Y地理坐标

                }

                //生成待评估样本文件
                Boolean flag=samples.genSampleFile(cPointList,rasterList,firstLine,localFilePath,null);

                
                if (flag==true)
                {
                    //stopwatch.Stop();
                    //MessageBox.Show(stopwatch.ElapsedMilliseconds + "");
                    MessageBox.Show("待评估样本文件生成成功!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }        

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally //最后再将鼠标光标设置成默认形状
            {
                this.Cursor = Cursors.Default;
            }
           
        }

        
    }
}
