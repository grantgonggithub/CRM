/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
namespace CRM
{
    partial class ucCommProductPrice
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCommProductPrice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveBasic = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBasicPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnVipSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonDiscountPrice = new System.Windows.Forms.RadioButton();
            this.radioButtonDiscountRate = new System.Windows.Forms.RadioButton();
            this.txtDiscountPrice = new System.Windows.Forms.TextBox();
            this.txtDiscountRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TvList = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveBasic);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBasicPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本价格";
            // 
            // btnSaveBasic
            // 
            this.btnSaveBasic.Location = new System.Drawing.Point(299, 29);
            this.btnSaveBasic.Name = "btnSaveBasic";
            this.btnSaveBasic.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBasic.TabIndex = 7;
            this.btnSaveBasic.Text = "保存";
            this.btnSaveBasic.UseVisualStyleBackColor = true;
            this.btnSaveBasic.Click += new System.EventHandler(this.btnSaveBasic_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(408, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "基本价格是指非会员没有任何折扣的价格，对应下面的会员价格。\r\n\r\n可以针对当前系统每种类型的会员单独设置折扣价格。";
            // 
            // txtBasicPrice
            // 
            this.txtBasicPrice.Location = new System.Drawing.Point(114, 30);
            this.txtBasicPrice.Name = "txtBasicPrice";
            this.txtBasicPrice.Size = new System.Drawing.Size(149, 21);
            this.txtBasicPrice.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "基本价格";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelRight);
            this.groupBox2.Controls.Add(this.TvList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 427);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会员价格";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnVipSave);
            this.panelRight.Controls.Add(this.label4);
            this.panelRight.Controls.Add(this.radioButtonDiscountPrice);
            this.panelRight.Controls.Add(this.radioButtonDiscountRate);
            this.panelRight.Controls.Add(this.txtDiscountPrice);
            this.panelRight.Controls.Add(this.txtDiscountRate);
            this.panelRight.Controls.Add(this.label3);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(223, 17);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(555, 407);
            this.panelRight.TabIndex = 2;
            // 
            // btnVipSave
            // 
            this.btnVipSave.Location = new System.Drawing.Point(418, 39);
            this.btnVipSave.Name = "btnVipSave";
            this.btnVipSave.Size = new System.Drawing.Size(75, 42);
            this.btnVipSave.TabIndex = 4;
            this.btnVipSave.Text = "保存";
            this.btnVipSave.UseVisualStyleBackColor = true;
            this.btnVipSave.Click += new System.EventHandler(this.btnVipSave_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(46, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(487, 74);
            this.label4.TabIndex = 3;
            this.label4.Text = "1、选择折扣点数，表示在基本价格基础上乘以相应的点数，如折扣点数设置为9 基本价格为100元，则此会员实际只需要支付100×0.9=90元；\r\n\r\n2、选择折扣现" +
                "金，表示当前会员只需要支付折扣现金对应的金额即可，如基本价格为100元，折扣价格为85元，则此会员实际只需要支付85元；\r\n";
            // 
            // radioButtonDiscountPrice
            // 
            this.radioButtonDiscountPrice.AutoSize = true;
            this.radioButtonDiscountPrice.Location = new System.Drawing.Point(115, 73);
            this.radioButtonDiscountPrice.Name = "radioButtonDiscountPrice";
            this.radioButtonDiscountPrice.Size = new System.Drawing.Size(71, 16);
            this.radioButtonDiscountPrice.TabIndex = 2;
            this.radioButtonDiscountPrice.Text = "折扣现金";
            this.radioButtonDiscountPrice.UseVisualStyleBackColor = true;
            this.radioButtonDiscountPrice.Click += new System.EventHandler(this.radioButtonDiscountRate_CheckedChanged);
            // 
            // radioButtonDiscountRate
            // 
            this.radioButtonDiscountRate.AutoSize = true;
            this.radioButtonDiscountRate.Checked = true;
            this.radioButtonDiscountRate.Location = new System.Drawing.Point(115, 31);
            this.radioButtonDiscountRate.Name = "radioButtonDiscountRate";
            this.radioButtonDiscountRate.Size = new System.Drawing.Size(71, 16);
            this.radioButtonDiscountRate.TabIndex = 2;
            this.radioButtonDiscountRate.TabStop = true;
            this.radioButtonDiscountRate.Text = "折扣点数";
            this.radioButtonDiscountRate.UseVisualStyleBackColor = true;
            this.radioButtonDiscountRate.Click += new System.EventHandler(this.radioButtonDiscountRate_CheckedChanged);
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Location = new System.Drawing.Point(214, 71);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Size = new System.Drawing.Size(149, 21);
            this.txtDiscountPrice.TabIndex = 1;
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.Location = new System.Drawing.Point(214, 29);
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.Size = new System.Drawing.Size(149, 21);
            this.txtDiscountRate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "折扣类型";
            // 
            // TvList
            // 
            this.TvList.Dock = System.Windows.Forms.DockStyle.Left;
            this.TvList.HideSelection = false;
            this.TvList.ItemHeight = 25;
            this.TvList.Location = new System.Drawing.Point(3, 17);
            this.TvList.Name = "TvList";
            this.TvList.Size = new System.Drawing.Size(220, 407);
            this.TvList.TabIndex = 1;
            this.TvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvList_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(781, 10);
            this.panel2.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "empleey.png");
            // 
            // ucCommProductPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucCommProductPrice";
            this.Size = new System.Drawing.Size(781, 512);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView TvList;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBasicPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonDiscountPrice;
        private System.Windows.Forms.RadioButton radioButtonDiscountRate;
        private System.Windows.Forms.TextBox txtDiscountRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveBasic;
        private System.Windows.Forms.Button btnVipSave;
        private System.Windows.Forms.ImageList imageList1;
    }
}
