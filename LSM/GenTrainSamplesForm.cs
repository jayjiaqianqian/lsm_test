using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;

namespace LSM
{
    public partial class GenTrainSamplesForm : Form
    {
        //保存当前地图对象
        private IMap mMap;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="map">当前地图对象</param>
        public GenTrainSamplesForm(IMap map)
        {
            InitializeComponent();
            mMap = map;
        }

        /// <summary>
        /// 装载窗口的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenTrainSamplesForm_Load(object sender, EventArgs e)
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
                    //图层操作对象
                    LayerOperator layerOperator = new LayerOperator(mMap);
                    //对地图对象中的所有图层进行遍历。根据图层类型，将图层名放入相应的控件中
                    for (int i = 0; i < mMap.LayerCount; i++)
                    {
                        ILayer layer = mMap.get_Layer(i);

                        IFeatureLayer featLayer = layer as IFeatureLayer;
                        IRasterLayer rasLayer = layer as IRasterLayer;
                        //若是点要素层，则将图层名放入灾害点、非灾害点图层中
                        if (featLayer != null)
                        {
                            //获取图层的第一个要素
                            IFeatureClass featClass = featLayer.FeatureClass;
                            IFeature feature = featClass.GetFeature(0);
                            //判断是否是点要素图层
                            IField field;
                            for (int j = 0; j < feature.Fields.FieldCount; j++)
                            {
                                field = feature.Fields.get_Field(j);
                                //如果字段是Geometry的类型的，则判断其是否是“point”类型的
                                if (field.Type == esriFieldType.esriFieldTypeGeometry)
                                {
                                    if (layerOperator.getGeometryType(field.GeometryDef) == "Point")
                                    {
                                        hazardCmBox.Items.Add(featLayer.Name);
                                        nohazardCmBox.Items.Add(featLayer.Name);
                                    }
 
                                }
                            }
 
                        }

                        ////将影响因子栅格图层名加入“可选影响因子图层”的listbox中
                        if (rasLayer != null)
                        {
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
        /// 灾害点图层ComBox的SelectedIndexChanged响应事件函数，
        /// 根据所选图层有无时间字段从而决定是否灰化时间控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hazardCmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sLayerName = hazardCmBox.SelectedItem.ToString();
            
            LayerOperator layerOperator = new LayerOperator(mMap);
            ControlOperator controlOperator = new ControlOperator();
            //根据图层名获取相应的图层对象
            ILayer layer = layerOperator.GetLayerByName(sLayerName);
            //调用控件操作对象的函数判断该图层是否有时间字段属性，从而决定是否禁用与时间相关的控件
            controlOperator.EnOrDisableTmControl(layer,startDateTimePicker,endDateTimePicker,allHazardPtRaBt,partHazardPtRaBt,tmRaBt);
        }


        /// <summary>
        /// “使用全部”radiobutton点击事件响应函数，判断是否灰化输入随机数及选择时间的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allHazardPtRaBt_CheckedChanged(object sender, EventArgs e)
        {
            //根据“随机取样”radiobutton是否被选择，决定是否灰化输入随机数的控件
            if (partHazardPtRaBt.Checked == true)
            {
                samPercentTxtBox.Enabled = true;
            }
            else
            {
                samPercentTxtBox.Enabled = false;
            }
            //根据“按发生时间选取”radiobutton是否被选择，决定是否灰化时间选择控件
            if (tmRaBt.Checked == true)
            {
                startDateTimePicker.Enabled = true;
                endDateTimePicker.Enabled = true;
            }
            else 
            {
                startDateTimePicker.Enabled = false;
                endDateTimePicker.Enabled = false;
            }

        }

        /// <summary>
        /// “随机取样”radiobutton点击事件响应函数，判断是否灰化输入随机数及选择时间的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partHazardPtRaBt_CheckedChanged(object sender, EventArgs e)
        {
            //根据“随机取样”radiobutton是否被选择，决定是否灰化输入随机数的控件
            if (partHazardPtRaBt.Checked == true)
            {
                samPercentTxtBox.Enabled = true;
            }
            else
            {
                samPercentTxtBox.Enabled = false;
            }
            //根据“按发生时间选取”radiobutton是否被选择，决定是否灰化时间选择控件
            if (tmRaBt.Checked == true)
            {
                startDateTimePicker.Enabled = true;
                endDateTimePicker.Enabled = true;
            }
            else
            {
                startDateTimePicker.Enabled = false;
                endDateTimePicker.Enabled = false;
            }
        }

        /// <summary>
        /// “按发生时间选取”radiobutton点击事件响应函数，判断是否灰化输入随机数及选择时间的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmRaBt_CheckedChanged(object sender, EventArgs e)
        {
            //根据“随机取样”radiobutton是否被选择，决定是否灰化输入随机数的控件
            if (partHazardPtRaBt.Checked == true)
            {
                samPercentTxtBox.Enabled = true;
            }
            else
            {
                samPercentTxtBox.Enabled = false;
            }
            //根据“按发生时间选取”radiobutton是否被选择，决定是否灰化时间选择控件
            if (tmRaBt.Checked == true)
            {
                startDateTimePicker.Enabled = true;
                endDateTimePicker.Enabled = true;
            }
            else
            {
                startDateTimePicker.Enabled = false;
                endDateTimePicker.Enabled = false;
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

            //使保存按钮获得焦点
            this.saveBt.Focus();

        }

        
        /// <summary>
        /// “保存”按钮点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBt_Click(object sender, EventArgs e)
        {

            try 
            {
                string localFilePath,sHzLayerName,sNoHzLayerName,sRasLayerName,firstLine="";
                LayerOperator layerOperator = new LayerOperator(mMap);//图层操作对象
                Samples samples = new Samples();//实例化样本类
                List<IRaster> rasterList = new List<IRaster>();//存储选中的影响因子图层的栅格数据
                List<CPoint> pointList = new List<CPoint>();//存储灾害点和非灾害点
                List<int> pList = new List<int>();//存储概率值
                //遍历被选中的影响因子图层时要用的变量
                IRasterLayer rasLayer;
                IRaster raster;
                // 存储每个点要素
                IFeature pFeature;
                IPoint pPoint;
                CPoint cPoint = new CPoint();//自定义的点类 

                //获得文件保存路径
                localFilePath = savePathTxtBox.Text.Trim().ToString();

                //判断用户是否有选择灾害点、非灾害点、影响因子图层,保存路径
                sHzLayerName = hazardCmBox.Text.ToString();
                sNoHzLayerName = nohazardCmBox.Text.ToString();
                if (sHzLayerName == "")
                {
                    MessageBox.Show("请选择灾害点图层!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sNoHzLayerName == "")
                {
                    MessageBox.Show("请选择非灾害点图层!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                //获取灾害点图层及其要素集
                IFeatureLayer hzFeatLayer = layerOperator.GetLayerByName(sHzLayerName) as IFeatureLayer;
                IFeatureClass hzFeatClass = hzFeatLayer.FeatureClass;
                //获取非灾害点图层及其要素集
                IFeatureLayer noHzFeatLayer = layerOperator.GetLayerByName(sNoHzLayerName) as IFeatureLayer;
                IFeatureClass noHzFeatClass = noHzFeatLayer.FeatureClass;

                //根据图层名获取被选中的影响因子图层及栅格数据
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    sRasLayerName = listBox2.Items[i].ToString();
                    //文本文件的首行，显示字段名
                    firstLine = firstLine + sRasLayerName.Substring(0, sRasLayerName.IndexOf("."))+ "\t";
                    rasLayer = layerOperator.GetLayerByName(sRasLayerName) as IRasterLayer;
                    raster = rasLayer.Raster;
                    rasterList.Add(raster);
                }

                //文本文件的首行，显示字段名
                firstLine = firstLine + "发生概率";
    

                //用户选中使用全部灾害点
                if (allHazardPtRaBt.Checked == true)
                {
                    //遍历全部的灾害点要素，将点加入pointlist中
                    for (int i = 0; i < hzFeatClass.FeatureCount(null); i++)
                    {
                        pFeature = hzFeatClass.GetFeature(i);
                        pPoint = pFeature.Shape as IPoint;
                        cPoint.X = pPoint.X;
                        cPoint.Y = pPoint.Y;

                        pointList.Add(cPoint);
                        pList.Add(1);//概率值
                    }

                }

                //用户选则随机取样,利用产生随机数的方法获取灾害点要素的下标，遍历这些下标，从而实现随机取样
                if (partHazardPtRaBt.Checked == true)
                {
                    //得到样本数
                    int hzFeatCount = hzFeatClass.FeatureCount(null);
                    double iPercent = System.Int32.Parse(samPercentTxtBox.Text.Trim().ToString()) / 100.00;
                    int iSamplesNum =(int)Math.Round(iPercent * hzFeatCount,0);//四舍五入

                    //得到的随机数数据集，即为随机样本的下标
                    SortedSet<int> featIndexsSet = samples.getRandomNum(iSamplesNum, 0, hzFeatCount-1);

                    //遍历随机样本，将点加入pointlist中
                    foreach (var featIndex in featIndexsSet)
                    {
                        pFeature = hzFeatClass.GetFeature(featIndex);
                        pPoint = pFeature.Shape as IPoint;
                        cPoint.X = pPoint.X;
                        cPoint.Y = pPoint.Y;

                        pointList.Add(cPoint);
                        pList.Add(1);//概率值
                    }

                }

                //用户选择了按发生时间选取
                if (tmRaBt.Checked == true)
                {   
                    //获取起始时间
                    string sStartTm = startDateTimePicker.Text.Trim().ToString();
                    string sEndTm = endDateTimePicker.Text.Trim().ToString();
                    string tmFiledName="";

                    //获取图层的第一个要素
                    pFeature= hzFeatClass.GetFeature(0);
                    //获取时间字段的字段名
                    IField field;
                    int i;
                    for (i = 0; i < pFeature.Fields.FieldCount; i++)
                    {
                        field = pFeature.Fields.get_Field(i);
                        if (field.Type == esriFieldType.esriFieldTypeDate || field.Name == "发生时间")
                        {   
                            tmFiledName = field.Name;
                            break;
                        }
                    }

                    //根据用户选择的起始时间筛选相应的灾害点要素
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = tmFiledName+" >= date '"+sStartTm+"' AND "+tmFiledName+" <= date '"+sEndTm+"'";//查询条件
                    IFeatureCursor pFeatureCursor = hzFeatClass.Search(queryFilter, false);
                    //获取选择集中的第一个灾害点要素
                    pFeature = pFeatureCursor.NextFeature();
                    //遍历选择集中的灾害点要素,将点加入pointlist中
                    while (pFeature != null)
                    {
                        pPoint = pFeature.Shape as IPoint;
                        cPoint.X = pPoint.X;
                        cPoint.Y = pPoint.Y;

                        pointList.Add(cPoint);
                        pList.Add(1);//概率值
                        pFeature = pFeatureCursor.NextFeature();//获取下一个点要素
                    }
               
                }

                //遍历全部的非灾害点要素，将点加入pointlist中
                for (int i = 0; i < noHzFeatClass.FeatureCount(null); i++)
                {
                    pFeature = noHzFeatClass.GetFeature(i);
                    pPoint = pFeature.Shape as IPoint;
                    cPoint.X = pPoint.X;
                    cPoint.Y = pPoint.Y;

                    pointList.Add(cPoint);
                    pList.Add(0);//概率值
                }

                //生成训练样本文件
                Boolean flag = samples.genSampleFile(pointList, rasterList, firstLine, localFilePath, pList);
                if (flag == true)
                {
                    MessageBox.Show("训练样本文件生成成功!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
 
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message,"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
           
           
        }

      
    }
}

