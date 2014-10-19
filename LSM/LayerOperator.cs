using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace LSM
{
    /// <summary>
    /// 图层操作类
    /// </summary>
    class LayerOperator
    {
        //保存当前地图对象
        private IMap mMap;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="map">当前地图对象</param>
        public LayerOperator(IMap map)
        {
            mMap = map;
        }


        /// <summary>
        /// 通过指定的图层名获取对应图层对象
        /// </summary>
        /// <param name="sLayerName">图层名</param>
        /// <returns></returns>
        public ILayer GetLayerByName(string sLayerName)
        {
            try
            {
                //判断图层名或者地图对象是否为空。若为空，函数返回空
                if (sLayerName == "" || mMap == null)
                {
                    return null;
                }
                //对地图对象中的所有图层进行遍历。若某一图层的名称与指定图层名相同，则返回该图层。
                for (int i = 0; i < mMap.LayerCount; i++)
                {
                    if (mMap.get_Layer(i).Name == sLayerName)
                    {
                        return mMap.get_Layer(i);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //若未找到，则返回空
            return null;

        }


        /// <summary>
        /// 判断geometry的具体类型，并将其用字符串表示，返回字符串
        /// </summary>
        /// <param name="geometryDef"></param>
        /// <returns></returns>
        public string getGeometryType(IGeometryDef geometryDef)
        {
            string value = "";
            switch (geometryDef.GeometryType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                    value = "Point";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint:
                    value = "Multipoint";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    value = "Polyline";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    value = "Polygon";
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultiPatch:
                    value = "MultiPatch";
                    break;
            }
            return value;
        }

    }
}
