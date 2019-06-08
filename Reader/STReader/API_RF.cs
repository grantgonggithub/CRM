using System;
using System.Text;
using System.Runtime.InteropServices;


namespace Reader
/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
{
    /// <summary>
    /// API_RF 的摘要说明。
    /// </summary>

    //
    //************************************操作RF读写器*************************
    //
    public class API_RF
    {

        [DllImport(@"STReader\iccrf.dll")]
        public static extern int rf_beep(int _Msec);//读写器发声
        [DllImport(@"STReader\iccrf.dll")]
        public static extern int rf_card(byte _Mode, ref uint snr);//MODE：寻卡模式:0一次只对一张卡操作; 1一次对多张卡操作
        [DllImport(@"STReader\iccrf.dll")]
        public static extern int rf_halt();//停止卡操作

    }


}
