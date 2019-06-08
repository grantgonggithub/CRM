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
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tools;

namespace CRM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                bool canCreate;
                Mutex myMutex = new Mutex(true, "MutexCRMString", out canCreate);
                if (canCreate)
                {
                    using (frmLogin login = new frmLogin())
                    {
                        if (login.ShowDialog() == DialogResult.OK)
                            ;
                        else
                            Environment.Exit(0);
                    }
                    CommStatic.ConfigInitlize();

                    Application.Run(new frmMain());
                }
                else
                {
                    //ExistRunningInstance();
                    frmIsRun r = new frmIsRun();
                    r.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Tools.TracingHelper.Error(ex, typeof(Program));
                MessageBox.Show(ex.Message);
            }
        }

        // Uses to active the exist window
        [DllImport("User32.dll")]
        public static extern void SetForegroundWindow(IntPtr hwnd);

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        // 0-Hidden, 1-Centered, 2-Minimized, 3-Maximized
        private const int WS_SHOWNORMAL =3;

        private static bool ExistRunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] procList = Process.GetProcessesByName(currentProcess.ProcessName);

            foreach (Process proc in procList)
            {
                if (proc.Id != currentProcess.Id)
                {
                    ShowWindowAsync(proc.MainWindowHandle, WS_SHOWNORMAL);
                    SetForegroundWindow(proc.MainWindowHandle);

                    return true;
                }
            }
            return false;
        }
    }
}
