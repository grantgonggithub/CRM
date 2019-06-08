/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reader
{
    public interface IReader
    {
        /// <summary>
        /// 同步调用，直接返回卡号
        /// </summary>
        /// <param name="sing"></param>
        /// <returns></returns>
        uint GetCode(byte sing);
        /// <summary>
        /// 异步调用，需要传入回调,单次
        /// </summary>
        /// <param name="sing"></param>
        /// <param name="callBack">回调方法，传回操作异常（如果有），卡号，上下文参数传递</param>
        void GetCode(byte sing,object context, Action<Exception, uint, object> callBack);

        /// <summary>
        /// 读写器发声
        /// </summary>
        /// <param name="time">时长</param>
        void Beep(int time);

        /// <summary>
        /// 停止读卡
        /// </summary>
        void Halt();
        /// <summary>
        /// 轮询读卡，多次
        /// </summary>
        void PollReadCard(byte sing,object context,Action<Exception,uint,object> callBack);

    }
}
