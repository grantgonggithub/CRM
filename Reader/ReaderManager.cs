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
using System.Threading;

using Tools;

namespace Reader
{
   public class ReaderManager
    {
       private static IReader reader = null;
       private static int pollTimeSpan=500;
       private static Thread th=null;
       public static bool InitlizeReader(string readerType,int _pollTimeSpan)
       {
           if (string.IsNullOrEmpty(readerType))
           {
               Exception ex = new Exception("readerType InitlizeReader Error");
               TracingHelper.Error(ex, typeof(ReaderManager));
               throw ex;
           }
           pollTimeSpan = _pollTimeSpan;
           switch (readerType)
           { 
               case "ST":
                   reader = new STReader();
                   TracingHelper.Info("ST 初始化成功");
                   return true;
               default:
                   Exception ex = new Exception(string.Format("{0} is Not active reader,place check config",readerType));
                   TracingHelper.Error(ex, typeof(ReaderManager));
                   break;
           }
           return false;
       }

        public static uint GetCode(byte sing)
        {
           return reader.GetCode(sing);
        }

        public static void GetCode(byte sing, object context, Action<Exception, uint, object> callBack)
        {
            reader.GetCode(sing, context, callBack);
        }

        public static void Beep(int time)
        {
            reader.Beep(time);
        }

        public static void Halt()
        {
            reader.Halt();
        }

        public static void PollReadCard(byte sing, object context, Action<Exception, uint, object> callBack)
        {
            temp t=new temp(){ Sing=sing, Context=context, CallBack=callBack,reader=reader, pollTimeSpan=pollTimeSpan};
            Thread th = new Thread(new ThreadStart(t.StartPoll));
            th.Start();
        }

        public static void StopReadCard()
        {
            if(th!=null)
            th.Abort();
        }

    }

   public class temp
   {
       public byte Sing;

       public object Context;

       public Action<Exception, uint, object> CallBack;

       public IReader reader;

       public int pollTimeSpan;

       public void StartPoll()
       {
           TracingHelper.Info("start reader cardid");
           while (true)
           {
               reader.GetCode(Sing, Context, delegate(Exception ex, uint sn, object context) {
                   if(ex!=null)
                      TracingHelper.Error(ex,typeof(ReaderManager),"callBack return sn="+sn);
                   if (sn > 0)
                   {
                       CallBack(null, sn, context);
                       reader.Halt();
                       reader.Beep(80);
                   }
                   //else
                   //    CallBack(ex, sn, context);
               });
               Thread.Sleep(pollTimeSpan);
           }
       }
   }
}
