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
    partial class frmProductsMgr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductsMgr));
            this.panelRightContent = new System.Windows.Forms.Panel();
            this.panelRightTv = new System.Windows.Forms.Panel();
            this.tvList = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelRightTv.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRightContent
            // 
            this.panelRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightContent.Location = new System.Drawing.Point(261, 0);
            this.panelRightContent.Name = "panelRightContent";
            this.panelRightContent.Padding = new System.Windows.Forms.Padding(5);
            this.panelRightContent.Size = new System.Drawing.Size(826, 669);
            this.panelRightContent.TabIndex = 1;
            // 
            // panelRightTv
            // 
            this.panelRightTv.Controls.Add(this.tvList);
            this.panelRightTv.Controls.Add(this.toolStrip1);
            this.panelRightTv.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelRightTv.Location = new System.Drawing.Point(0, 0);
            this.panelRightTv.Name = "panelRightTv";
            this.panelRightTv.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panelRightTv.Size = new System.Drawing.Size(261, 669);
            this.panelRightTv.TabIndex = 0;
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.FullRowSelect = true;
            this.tvList.HideSelection = false;
            this.tvList.ItemHeight = 28;
            this.tvList.Location = new System.Drawing.Point(0, 25);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(261, 639);
            this.tvList.TabIndex = 1;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddNew,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(261, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddNew
            // 
            this.toolStripButtonAddNew.Image = global::CRM.Properties.Resources.png_0084;
            this.toolStripButtonAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddNew.Name = "toolStripButtonAddNew";
            this.toolStripButtonAddNew.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonAddNew.Text = "新增产品";
            this.toolStripButtonAddNew.Click += new System.EventHandler(this.toolStripButtonAddNew_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.Image = global::CRM.Properties.Resources.png_0535;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonEdit.Text = "编辑";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::CRM.Properties.Resources.png_0652;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonDelete.Text = "删除";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MainNode.png");
            this.imageList1.Images.SetKeyName(1, "RootNode1.png");
            this.imageList1.Images.SetKeyName(2, "RootNode2.png");
            // 
            // frmProductsMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 669);
            this.Controls.Add(this.panelRightContent);
            this.Controls.Add(this.panelRightTv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductsMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品服务管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductsMgr_FormClosing);
            this.panelRightTv.ResumeLayout(false);
            this.panelRightTv.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRightTv;
        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.Panel panelRightContent;
        private System.Windows.Forms.ImageList imageList1;




    }
}