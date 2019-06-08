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
using System.Windows.Forms;

namespace CRM
{
   public class skinBase:Form
    {
       private Sunisoft.IrisSkin.SkinEngine skinEngine1;

       public skinBase()
       {
           InitializeComponent();
       }

       private void InitializeComponent()
       {
           this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
           this.SuspendLayout();
           // 
           // skinEngine1
           // 
           this.skinEngine1.SerialNumber = "";
           this.skinEngine1.SkinFile =@"MP10.ssk";
           this.skinEngine1.SkinAllForm = true;
           // 
           // skinBase
           // 
           this.ClientSize = new System.Drawing.Size(284, 262);
           this.Name = "skinBase";
           this.ResumeLayout(false);

       }
    }
}
