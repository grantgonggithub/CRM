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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Tools;

namespace CRM
{
    public partial class UCOtherSetting : UserControl
    {
        public UCOtherSetting()
        {
            InitializeComponent();
            chboxAutoStart.Checked = IsRegeditExit();
        }


        #region 将程序添加到启动项
        //private static RegistryKey HKLM = Registry.LocalMachine;
        private static RegistryKey HKCU = Registry.CurrentUser;
        private static string name = "HTCRM";
        private static string path = Application.ExecutablePath;
        /// <summary>
        /// 注册表操作，将程序添加到启动项
        /// </summary>
        public static void SetRegistryKey(bool Started)
        {
            try
            {
                RegistryKey Run = HKCU.CreateSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\");
                if (Started == true)
                {
                    try
                    {
                        Run.SetValue(name, path);
                        Run.Close();
                        HKCU.Close();
                    }
                    catch (Exception ex)
                    {
                        TracingHelper.Error(ex, typeof(UCOtherSetting), "注册表修改失败(开机自启未实现)");
                    }
                }
                else
                {
                    if (Run.GetValue(name) != null)
                    {
                        Run.DeleteValue(name);
                        Run.Close();
                        HKCU.Close();
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCOtherSetting), "将程序添加到启动项错误");
            }
        }

        /// <summary>
        /// 获取是否开机启动
        /// </summary>
        /// <returns></returns>
        public static bool IsRegeditExit()
        {
            try
            {
                RegistryKey software = HKCU.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey(@"Microsoft\Windows\CurrentVersion\Run\", true);
                object runObj = aimdir.GetValue(name);
                if (runObj == null || !path.Equals(runObj.ToString()))
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCOtherSetting), "获取是否开机启动错误");
            }
            return false;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chboxAutoStart.Checked)
            {
                if (!IsRegeditExit())
                    SetRegistryKey(true);
            }
            else
            {
                if (IsRegeditExit())
                    SetRegistryKey(false);
            }
        }
    }
}
