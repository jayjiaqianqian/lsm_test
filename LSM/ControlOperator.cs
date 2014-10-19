using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace LSM
{
    /// <summary>
    /// 控件操作类，对一些控件进行操控
    /// </summary>
    class ControlOperator
    {
        public ControlOperator()
        { 
        }


        /// <summary>
        /// 判断该图层是否有时间字段属性，从而决定是否禁用与时间相关的控件
        /// </summary>
        /// <param name="layer">图层</param>
        /// <param name="starDateTimePicker">设置起始时间的控件</param>
        /// <param name="endDateTimePicker">设置结束时间的控件</param>
        /// <param name="allHazardPtRaBt">“使用全部”单选控件</param>
        /// <param name="partHazardPtRaBt">"随机取样”单选控件"</param>
        /// <param name="tmRaBt">“按时间选取”单选控件</param>
        public void EnOrDisableTmControl(ILayer layer, DateTimePicker starDateTimePicker, DateTimePicker endDateTimePicker, RadioButton allHazardPtRaBt, RadioButton partHazardPtRaBt,RadioButton tmRaBt)
        {
            try
            {

                if (layer == null)
                {
                    return;
                }
                else
                {
                    allHazardPtRaBt.Enabled = true;//“使用全部”控件可用
                    if (partHazardPtRaBt != null)
                    {
                        partHazardPtRaBt.Enabled = true;//“随机取样”控件可用
                    }


                    IFeatureLayer featLayer = layer as IFeatureLayer;
                    if (featLayer == null)
                    {
                        return;
                    }
                    else
                    {
                        //获取图层的第一个要素
                        IFeatureClass featClass = featLayer.FeatureClass;
                        IFeature feature = featClass.GetFeature(0);
                        //判断是否有时间字段
                        IField field;
                        int i;
                        for (i = 0; i < feature.Fields.FieldCount; i++)
                        {
                            field = feature.Fields.get_Field(i);
                            if (field.Type == esriFieldType.esriFieldTypeDate || field.Name == "发生时间")
                            {
                                break;
                            }
                        }

                        if (i == feature.Fields.FieldCount)//不存在时间字段，禁用与时间有关控件
                        {
                            tmRaBt.Enabled = false;
                            starDateTimePicker.Enabled = false;
                            endDateTimePicker.Enabled = false;
                            //使“使用全部”的radiobutton被选择
                            if (tmRaBt.Checked == true)
                            {
                                tmRaBt.Checked = false;
                                allHazardPtRaBt.Checked = true;
                            }
                        }
                        else//存在时间字段，使与时间有关控件可用
                        {
                            DateTime tmpDate, minDate, maxDate;
                            //第i个字段是时间字段 先用第一个要素的时间给minData,maxData赋值
                            minDate = Convert.ToDateTime(feature.get_Value(i));
                            maxDate = Convert.ToDateTime(feature.get_Value(i));

                            //遍历其余要素的时间，获取最大、最小的时间，从而限定起始时间选择器可选的时间范围
                            for (int j = 1; j < featClass.FeatureCount(null); j++)
                            {
                                feature = featClass.GetFeature(j);
                                tmpDate = Convert.ToDateTime(feature.get_Value(i));

                                if (DateTime.Compare(tmpDate, minDate) < 0)
                                {
                                    minDate = tmpDate;
                                }
                                if (DateTime.Compare(tmpDate, maxDate) > 0)
                                {
                                    maxDate = tmpDate;
                                }

                            }
                            //限定起始时间选择器可选的时间范围
                            starDateTimePicker.MinDate = minDate;
                            starDateTimePicker.MaxDate = maxDate;
                            endDateTimePicker.MaxDate = maxDate;
                            endDateTimePicker.MinDate = minDate;
                            //改变起始时间选择器的显示值
                            starDateTimePicker.Text = Convert.ToString(minDate);
                            endDateTimePicker.Text = Convert.ToString(maxDate);

                            //使“按发生时间选取”radiobutton可用
                            tmRaBt.Enabled = true;
                            //根据“按发生时间选取”radiobutton是否被选择，决定是否灰化时间选择控件
                            if (tmRaBt.Checked == true)
                            {
                                starDateTimePicker.Enabled = true;
                                endDateTimePicker.Enabled = true;
                            }
                            else
                            {
                                starDateTimePicker.Enabled = false;
                                endDateTimePicker.Enabled = false;
                            }
                        }

                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //若未找到，则返回空
            return;

        }


    }
}
