using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSM
{
    /// <summary>
    /// 存储栅格数据参数信息
    /// </summary>
    struct RasterProperties
    {
        public double dX; //网格的宽度
        public double dY; //网格的高度
        public int dHeight;//栅格数据的行数
        public int dWidth;//栅格数据的列数
        public string NoDataValue;//用于标识无效数据的数值
        //数据所在范围的xMin、yMin、xMax和yMax
        public double xMin;
        public double yMin;
        public double xMax;
        public double yMax;

    }
}
