#region
/*************************************************************************************
     * CLR 版本：       4.0.30319.18444
     * 类 名 称：       ProgressMsg
     * 机器名称：       PC-JASON
     * 命名空间：       Protal.Common
     * 文 件 名：       ProgressMsg
     * 创建时间：       2015/4/25 14:56:04
     * 计算机名：       Administrator
     * 作    者：       Jason.Yang(yangxing1002@gmail.com)
     * 说    明： 
     * 修改时间：
     * 修 改 人：
**************************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protal.Common
{
    public class ProgressMsg
    {
        public ProgressMsg()
        {
            
        }
        public ProgressMsg(string fileName, Int64 fileSize, string fileType)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
            this.Status = "开始上传";
        }

        public ProgressMsg(string msg,Int64 total,string fileSize, string fileType)
        {
           //this.FileName = fileName;
           // this.FileSize = fileSize;
            this.Status = "开始上传";
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public double FileSize { get; set; }


        /// <summary>
        /// 上传速度
        /// </summary>
        public double Speed
        {
            get
            {
                return CostTime <= 0 ? 0 : Finish / CostTime;
            }
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        private string _status;
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get
            {
                if (Finish <= 0)
                {
                    _status = "preparing";
                }
                if (Finish > 0 && Finish < FileSize)
                {
                    _status = "uploading";
                }
                _status = "finished";
                return _status;
            }
            set { _status = value; }
        }

        public int Total { get; set; }
        /// <summary>
        /// 当前进度
        /// </summary>
        public double Percent
        {
            get { return Finish / Total; }
        }
        /// <summary>
        /// 当前耗时
        /// </summary>
        public double CostTime { get; set; }

        public double Finish { get; set; }

    }
}