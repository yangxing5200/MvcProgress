#region
/*************************************************************************************
     * CLR 版本：       4.0.30319.18444
     * 类 名 称：       MessageFactory
     * 机器名称：       PC-JASON
     * 命名空间：       Protal.Common
     * 文 件 名：       MessageFactory
     * 创建时间：       2015/4/25 14:42:42
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
using System.Threading;
using System.Web;

namespace Protal.Common
{
    public class MessageFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static void GenMsg(string cookieId)
        {
            ProgressMsg msg = new ProgressMsg();
            var begin = DateTime.Now;

            DateTime end = DateTime.Now.ToLocalTime();
            msg.CostTime = (long)(end - begin).TotalMilliseconds;
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(300);
                 msg = HttpContext.Current.Cache[cookieId] as ProgressMsg;
                string strMsg = string.Format("第{0}条消息", i);
                if (msg != null)
                {
                    msg.Msg = strMsg;
                    msg.Finish = i;
                    msg.CostTime = (long)(DateTime.Now.ToLocalTime() - begin).TotalMilliseconds;
                }
                else
                {
                    msg=new ProgressMsg {Msg = strMsg,Total = 100,Finish = i};
                }
                HttpContext.Current.Cache[cookieId] = msg;
               
            }
            if (msg != null)
            {
                msg.Abort = true;
                HttpContext.Current.Cache[cookieId] = msg;
            }
        }
    }
}