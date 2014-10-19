using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;

namespace LSM
{
    public partial class AUCForm : Form
    {
        //用于保存主窗体对象
        private IMap map;
        private ILayer layer;
        private LayerOperator layeroperator;
        private AUC auc;
       
        
        //构造窗体并传入主窗体对象
        public AUCForm(IMap imap)
        {
            InitializeComponent();
            map = imap;
            layeroperator = new LayerOperator(imap);
            auc = new AUC(imap);
        }

        //AUC结果评价对话框加载事件
        private void AUCForm_Load(object sender, EventArgs e)
        {
            IDataset ds;

            //添加图层名到“灾害点图层”组合框和“可选评价图层列表”中
            for (int i = 0; i < map.LayerCount; i++)
            {
                layer = map.get_Layer(i);
                ds = layer as IDataset;
                //判断图层是否为矢量图层，若是，则将图层名加入“灾害点图层”组合框
                if (ds.Type == esriDatasetType.esriDTFeatureClass)
                {
                    ZHDTC_comboBox.Items.Add(layer.Name);
                }
                //判断图层是否为栅格图层，若是，则将图层名加入“可选评价图层列表”中
                else if (ds.Type == esriDatasetType.esriDTRasterDataset)
                {
                    PJTC_choice_listBox.Items.Add(layer.Name);
                }
            }

            //初始化发生时间单选按钮及组合框
            ZHDTC_time_radioButton1.Enabled = false;
            ZHDTC_time_radioButton2.Enabled = false;
            start_dateTimePicker.Enabled = false;
            end_dateTimePicker.Enabled = false;

        }


        //"灾害点图层"组合框选择事件
        private void ZHDTC_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string sLayerName = ZHDTC_comboBox.SelectedItem.ToString();

            LayerOperator layerOperator = new LayerOperator(map);
            ControlOperator controlOperator = new ControlOperator();
            //根据图层名获取相应的图层对象
            ILayer layer = layerOperator.GetLayerByName(sLayerName);
            //调用控件操作对象的函数判断该图层是否有时间字段属性，从而决定是否禁用与时间相关的控件
            controlOperator.EnOrDisableTmControl(layer, start_dateTimePicker, end_dateTimePicker, ZHDTC_time_radioButton1, null, ZHDTC_time_radioButton2);
        }
        
       
        //选择评价结果图层
        private void PJTC_all_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PJTC_choice_listBox.Items.Count; i++)
            {
                PJTC_choosed_listBox.Items.Add(PJTC_choice_listBox.Items[i]);
            }
            PJTC_choice_listBox.Items.Clear();

        }

        private void PJTC_yes_button_Click(object sender, EventArgs e)
        {
            if (PJTC_choice_listBox.SelectedItem != null)
            {
                PJTC_choosed_listBox.Items.Add(PJTC_choice_listBox.SelectedItem);
                PJTC_choice_listBox.Items.Remove(PJTC_choice_listBox.SelectedItem);
            }
        }

        private void PJTC_no_button_Click(object sender, EventArgs e)
        {
            if (PJTC_choosed_listBox.SelectedItem != null)
            {
                PJTC_choice_listBox.Items.Add(PJTC_choosed_listBox.SelectedItem);
                PJTC_choosed_listBox.Items.Remove(PJTC_choosed_listBox.SelectedItem);
            }

        }

        private void PJTC_none_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PJTC_choosed_listBox.Items.Count; i++)
            {
                PJTC_choice_listBox.Items.Add(PJTC_choosed_listBox.Items[i]);
            }
            PJTC_choosed_listBox.Items.Clear();
        }


        //评价结果文件保存地址
        private void AUC_filerouteliulan_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog pjjgfiledialog;
            pjjgfiledialog = new SaveFileDialog();
            pjjgfiledialog.Filter = "Text Files | *.txt";
            pjjgfiledialog.DefaultExt = "txt";
            pjjgfiledialog.ShowDialog();
            AUC_fileroute_textBox.Text = pjjgfiledialog.FileName;

            this.AUC_startcompute_button.Focus();//使“开始计算”按钮获得焦点
        }


        //"开始计算"按钮点击响应事件
        private void AUC_startcompute_button_Click(object sender, EventArgs e)
        {
            //检查灾害点图层
            if (ZHDTC_comboBox.SelectedItem == null)
            {
                MessageBox.Show("未选择灾害点图层！");
                return;
            }
            else if (ZHDTC_time_radioButton1.Checked == false)
            {
                if (ZHDTC_time_radioButton2.Checked == false)
                {
                    MessageBox.Show("未选择获取灾害点范围的方式！");
                    return;
                }
            }
            //检查“选中评价结果图层”
            if (PJTC_choosed_listBox.Items.Count <= 0)
            {
                MessageBox.Show("没有评价结果图层！");
                return;
            }
            //检查AUC评价结果保存文件路径
            if (AUC_fileroute_textBox.Text == null)
            {
                MessageBox.Show("未设置AUC评价结果保存文件路径！");
                return;
            }

            //调用AUC评价函数
            string[] jgtcname;
            string saveroute;
            //获取结果图层名
            List<string> jgtclist = new List<string>();
            for (int i = 0; i < PJTC_choosed_listBox.Items.Count; i++)
            {
                jgtclist.Add(PJTC_choosed_listBox.Items[i].ToString());
            }
            jgtcname = jgtclist.ToArray();

            //获取保存文件路径
            saveroute = AUC_fileroute_textBox.Text;
            //若用户手动输入保存路径，而且不是以.txt结尾,则为其加上后缀
            if (!saveroute.EndsWith(".txt") && !saveroute.EndsWith(".TXT"))
            {
                saveroute = saveroute + ".txt";
            }
            //获取灾害点数据集
            layer = null;
            layer = layeroperator.GetLayerByName(ZHDTC_comboBox.SelectedItem.ToString());
            IFeatureLayer fealayer = layer as IFeatureLayer;
            if (fealayer != null)
            {
                IFeatureClass featureclass = fealayer.FeatureClass;
                IFeatureCursor featurecursor;
                try
                {
                    if (ZHDTC_time_radioButton2.Checked == true)
                    {
                        DateTime starttime = start_dateTimePicker.Value;
                        DateTime endtime = end_dateTimePicker.Value;
                        string sWhere = "发生时间>=date'" + starttime + "'AND 发生时间<=date'" + endtime + "'";
                        IQueryFilter queryfilter = new QueryFilter();
                        queryfilter.WhereClause = sWhere;
                        featurecursor = featureclass.Search(queryfilter, false);
                    }
                    else
                    {
                        featurecursor = featureclass.Search(null, false);
                    }
                    //获取所有的点坐标
                    List<IPoint> points = new List<IPoint>();
                    IFeature feature = featurecursor.NextFeature();
                    while (feature != null)
                    {
                        points.Add((IPoint)feature.Shape);
                        feature = featurecursor.NextFeature();
                    }
                    //调用AUC评价函数
                    auc.AUCpingjiafun(points, jgtcname, saveroute);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("灾害点图层不存在！");
            }

        }


        /// <summary>
        /// 取消按钮点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AUC_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// “使用全部”radiobutton点击事件响应函数，判断是否灰化输入随机数及选择时间的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZHDTC_time_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //根据“按发生时间选取”radiobutton是否被选择，决定是否灰化时间选择控件
            if (ZHDTC_time_radioButton2.Checked == true)
            {
                start_dateTimePicker.Enabled = true;
                end_dateTimePicker.Enabled = true;
            }
            else
            {
                start_dateTimePicker.Enabled = false;
                end_dateTimePicker.Enabled = false;
            }
        }


        /// <summary>
        /// “按发生时间选取”radiobutton点击事件响应函数，判断是否灰化输入随机数及选择时间的控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZHDTC_time_radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //根据“按发生时间选取”radiobutton是否被选择，决定是否灰化时间选择控件
            if (ZHDTC_time_radioButton2.Checked == true)
            {
                start_dateTimePicker.Enabled = true;
                end_dateTimePicker.Enabled = true;
            }
            else
            {
                start_dateTimePicker.Enabled = false;
                end_dateTimePicker.Enabled = false;
            }
        }

     
    }
}
