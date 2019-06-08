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
using System.Text;
using System.Threading;
using System.IO;

namespace Tools
{
    public class TracingHelper
    {
        #region static

        private static Queue<Trace> tracingQueue = new Queue<Trace>();
        private static object rootLock = new object();
        private static bool running = false;
        private static bool _openInfoTrace = true;

        public static void SetTracingSwitch(bool openInfoTrace)
        {
            _openInfoTrace = openInfoTrace;
        }

        private static string info = "[{0}]\r\n[Time]={1}\r\n[className]={2}\r\n[ExceptionMessage]={3}\r\n[ExceptionStackTrace]={4}\r\n{5}\r\n-------------------------------------------------------------\r\n\r\n";

        #endregion

        #region Error 不可以关闭，只要系统出现错误必须记录下来

        /// <summary>
        /// 在catch中使用，记录系统未知异常
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="classType">所在的类的类型，如typeof(frmlogin)</param>
        /// <param name="message">附加的信息</param>
        public static void Error(Exception ex, Type classType, string message)
        {
            Trace trace = new Trace() { ex = ex, classType = classType, message = message, traceType = TraceType.Error };
            add(trace);
        }
        /// <summary>
        /// 记录可以打印对象所有属性值得Error日志
        /// </summary>
        /// <typeparam name="T">要打印的对象的实例的类型</typeparam>
        /// <param name="ex">异常</param>
        /// <param name="classType">异常发生的所在的类的类型，便于定位发生异常的日志位置</param>
        /// <param name="objValue">要打印的对象的实例</param>
        public static void Error<T>(Exception ex, Type classType, T objValue)
        {
            Trace trace = new Trace() { ex = ex, classType = classType, traceType = TraceType.Error, message = dumpObject<T>(objValue) };
            add(trace);
        }
        /// <summary>
        /// 在catch中使用，记录系统未知异常
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="classType">所在的类的类型，如typeof(frmlogin)</param>
        public static void Error(Exception ex, Type classType)
        {
            Error(ex, classType, null);
        }
        /// <summary>
        /// 在catch中使用，记录系统未知异常
        /// </summary>
        /// <param name="classType">所在的类的类型，如typeof(frmlogin)</param>
        /// <param name="message">附加的信息</param>
        public static void Error(Type classType, string message)
        {
            Error(null, classType, message);
        }

        /// <summary>
        /// 在catch中使用，记录系统未知异常
        /// </summary>
        /// <param name="message">附加的信息</param>
        public static void Error(string message)
        {
            Error(null, null, message);
        }

        #endregion

        #region Info 可以设置开启或者关闭

        /// <summary>
        /// 记录非异常的日志，主要为了检查关键流程是否走到
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            if (!_openInfoTrace) return;
            Info(null, message);
        }
        /// <summary>
        /// 记录非异常的日志，主要为了检查关键流程是否走到
        /// </summary>
        /// <param name="typeName">所在的类的类型，如typeof(frmlogin)</param>
        /// <param name="message">日志内容</param>
        public static void Info(Type typeName, string message)
        {
            if (!_openInfoTrace) return;
            Trace trace = new Trace() { ex = null, traceType = TraceType.Info, classType = typeName, message = message };
            add(trace);
        }
        /// <summary>
        /// 记录可以打印对象所有属性值得Info日志
        /// </summary>
        /// <typeparam name="T">需要打印的对象实例类型</typeparam>
        /// <param name="typeName">当前Trece记录所在的类，便于定位日志发生的地点</param>
        /// <param name="message">日志附加内容</param>
        /// <param name="objValue">需要打印的对象实例类</param>
        public static void Info<T>(Type typeName, string message, T objValue)
        {
            if (!_openInfoTrace) return;
            Trace trace = new Trace() { ex = null, traceType = TraceType.Info, classType = typeName, message = message + "\n\r" + dumpObject<T>(objValue) };
            add(trace);
        }

        #endregion

        #region private

        private static void add(Trace message)
        {
            lock (rootLock)
            {
                tracingQueue.Enqueue(message);
                if (!running)
                    start();
            }
        }

        private static void start()
        {
            Thread th = new Thread(new ThreadStart(get));
            th.Name = "LogThread";
            th.IsBackground = true;
            th.Start();
            running = true;
        }

        private static void get()
        {
            int i = 50;//批量写，提高IO效率
            List<Trace> traceArry = new List<Trace>();
            lock (rootLock)
            {
                while (i > 0)
                {
                    if (tracingQueue.Count == 0)
                    {
                        running = false;
                        break;
                    }
                    Trace trace = tracingQueue.Dequeue();
                    traceArry.Add(trace);
                    i -= 1;
                }
            }
            if (traceArry.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Trace t in traceArry)
                {
                    if (t != null)
                    {
                        string temp = buildTrace(t);
                        if (!string.IsNullOrEmpty(temp))
                            sb.Append(temp);
                    }
                }
                if (sb != null && sb.ToString() != "")
                    WriteLog(sb);
                else running = false;
            }
            else
                running = false;
        }


        private static string logFolder = System.AppDomain.CurrentDomain.BaseDirectory + "log";
        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="message"></param>
        private static void WriteLog(StringBuilder message)
        {
            int i = 0;
            if (message == null || message.ToString() == "") return;
        goHere:
            try
            {
                if (!Directory.Exists(logFolder + "\\" + DateTime.Now.ToString("yyyyMMdd")))
                {
                    Directory.CreateDirectory(logFolder + "\\" + DateTime.Now.ToString("yyyyMMdd"));
                }
                String logFilePath = Path.Combine(logFolder + "\\" + DateTime.Now.ToString("yyyyMMdd"), "log" + DateTime.Now.ToString("yyyyMMddHH") + ".txt");//一天一个文件发现日志太大，还是一个小时一个文件
                using (StreamWriter writer = new StreamWriter(logFilePath, true, Encoding.Default))
                {
                    writer.Write(message.ToString());
                }
            }
            catch
            {
                Thread.Sleep(800);//失败往往是文件占用，可以停800毫秒
                if (i < 3)//做3次尝试，如果失败将会扔掉
                {
                    i += 1;
                    goto goHere;
                }
            }
            finally
            {
                get();
            }
        }

        private static string buildTrace(Trace trace)
        {
            //"{0}\r\n[Time]={1}\r\n[className]={2}\r\n[ExceptionMessage]={3}\r\n[ExceptionStackTrace]={4}\r\n{5}
            if (trace == null) return null;
            return string.Format(info, trace.traceType.ToString(),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"),
                trace.classType == null ? "" : trace.classType.FullName,
                trace.ex == null ? "" : trace.ex.Message,
                trace.ex == null ? "" : trace.ex.StackTrace,
                string.IsNullOrEmpty(trace.message) ? "" : "[Message]=" + trace.message);
        }

        private static string dumpObject<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tStr += string.Format("{0}={1},", name, value);
                }
                else
                {
                    dumpObject(value);
                }
            }
            return tStr;
        }

        #endregion
    }

    #region 内部类

    enum TraceType
    {
        Error,
        Info
    }

    class Trace
    {
        public Exception ex;

        public Type classType;

        public TraceType traceType;

        public string message;
    }

    #endregion

}
