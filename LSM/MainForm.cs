using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;

namespace LSM
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        private ILayer TOCRightLayer;     //用于存储TOC右键选中图层
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;

        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        /// <summary>
        /// “训练样本生成”菜单点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genTrainSamplesMI_Click(object sender, EventArgs e)
        {   
            //显示相应的窗体
            GenTrainSamplesForm genTrainSamplesForm = new GenTrainSamplesForm(axMapControl1.Map);
           // genTrainSamplesForm.Show();
            genTrainSamplesForm.ShowDialog();
        }

        /// <summary>
        /// “待评估样本生成”菜单点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genEvalSamplesMI_Click(object sender, EventArgs e)
        {
            //显示相应的窗体
            GenEvalSamplesForm genEvalSamplesForm = new GenEvalSamplesForm(axMapControl1.Map);
            genEvalSamplesForm.ShowDialog();

        }

        /// <summary>
        /// “AUC结果评价”菜单点击事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AUCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AUCForm aucForm = new AUCForm(axMapControl1.Map);
            aucForm.ShowDialog();
        }


        /// <summary>
        /// TOCControl的鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //获取当前鼠标点击位置的相关信息
            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null;
            object data = null;
            this.axTOCControl1.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref unk, ref data);

            //如若是鼠标右击且点击位置为图层，则弹出右击功能框
            if (e.button == 2)
            {
                if (itemType == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    //设置TOC选择图层
                    this.TOCRightLayer = layer;
                    this.ctMenuTOC.Show(axTOCControl1, e.x, e.y);
                }
            }

        }


        /// <summary>
        ///  删除当前图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteLayerToolStripMI_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.DeleteLayer(TOCRightLayer);
            axMapControl1.ActiveView.Refresh();
        }


        /// <summary>
        /// 缩放到当前图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomToLayerToolStripMI_Click(object sender, EventArgs e)
        {

            //设置MapControl显示范围至数据的全局范围
            axMapControl1.Extent = this.axMapControl1.FullExtent;
            // 刷新ActiveView
            axMapControl1.ActiveView.Refresh();
          
        }



      
    }
}