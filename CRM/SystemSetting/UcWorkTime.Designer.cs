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
    partial class UcWorkTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nupdStartHour1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nupdStartMinite1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nupdStartHour2 = new System.Windows.Forms.NumericUpDown();
            this.nupdStartMinite2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nupdGoOffHour1 = new System.Windows.Forms.NumericUpDown();
            this.nupdGoOffMinite1 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nupdGoOffHour2 = new System.Windows.Forms.NumericUpDown();
            this.nupdGoOffMinite2 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartHour1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartMinite1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartMinite2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffHour1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffMinite1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffMinite2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上班时间";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(471, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 57);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "下班时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "迟到时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "早退时间";
            // 
            // nupdStartHour1
            // 
            this.nupdStartHour1.Location = new System.Drawing.Point(82, 37);
            this.nupdStartHour1.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nupdStartHour1.Name = "nupdStartHour1";
            this.nupdStartHour1.Size = new System.Drawing.Size(51, 21);
            this.nupdStartHour1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "点";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "分";
            // 
            // nupdStartMinite1
            // 
            this.nupdStartMinite1.Location = new System.Drawing.Point(152, 37);
            this.nupdStartMinite1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nupdStartMinite1.Name = "nupdStartMinite1";
            this.nupdStartMinite1.Size = new System.Drawing.Size(51, 21);
            this.nupdStartMinite1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "点";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "分";
            // 
            // nupdStartHour2
            // 
            this.nupdStartHour2.Location = new System.Drawing.Point(309, 36);
            this.nupdStartHour2.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nupdStartHour2.Name = "nupdStartHour2";
            this.nupdStartHour2.Size = new System.Drawing.Size(51, 21);
            this.nupdStartHour2.TabIndex = 3;
            // 
            // nupdStartMinite2
            // 
            this.nupdStartMinite2.Location = new System.Drawing.Point(379, 36);
            this.nupdStartMinite2.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nupdStartMinite2.Name = "nupdStartMinite2";
            this.nupdStartMinite2.Size = new System.Drawing.Size(51, 21);
            this.nupdStartMinite2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "点";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "分";
            // 
            // nupdGoOffHour1
            // 
            this.nupdGoOffHour1.Location = new System.Drawing.Point(82, 82);
            this.nupdGoOffHour1.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nupdGoOffHour1.Name = "nupdGoOffHour1";
            this.nupdGoOffHour1.Size = new System.Drawing.Size(51, 21);
            this.nupdGoOffHour1.TabIndex = 3;
            // 
            // nupdGoOffMinite1
            // 
            this.nupdGoOffMinite1.Location = new System.Drawing.Point(152, 82);
            this.nupdGoOffMinite1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nupdGoOffMinite1.Name = "nupdGoOffMinite1";
            this.nupdGoOffMinite1.Size = new System.Drawing.Size(51, 21);
            this.nupdGoOffMinite1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "点";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(432, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "分";
            // 
            // nupdGoOffHour2
            // 
            this.nupdGoOffHour2.Location = new System.Drawing.Point(309, 80);
            this.nupdGoOffHour2.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nupdGoOffHour2.Name = "nupdGoOffHour2";
            this.nupdGoOffHour2.Size = new System.Drawing.Size(51, 21);
            this.nupdGoOffHour2.TabIndex = 3;
            // 
            // nupdGoOffMinite2
            // 
            this.nupdGoOffMinite2.Location = new System.Drawing.Point(379, 80);
            this.nupdGoOffMinite2.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nupdGoOffMinite2.Name = "nupdGoOffMinite2";
            this.nupdGoOffMinite2.Size = new System.Drawing.Size(51, 21);
            this.nupdGoOffMinite2.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(491, 60);
            this.label13.TabIndex = 4;
            this.label13.Text = "说明：\r\n\r\n1、迟到时间表示过了这个时间就算迟到，如果必须按点上班可以和上班时间设置成一样\r\n\r\n3、早退时间表示在这个时间之前下班算早退，如果必须按点下班可以" +
                "和下班时间设置成一样\r\n";
            // 
            // UcWorkTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nupdStartMinite2);
            this.Controls.Add(this.nupdStartHour2);
            this.Controls.Add(this.nupdGoOffMinite2);
            this.Controls.Add(this.nupdGoOffHour2);
            this.Controls.Add(this.nupdGoOffMinite1);
            this.Controls.Add(this.nupdGoOffHour1);
            this.Controls.Add(this.nupdStartMinite1);
            this.Controls.Add(this.nupdStartHour1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "UcWorkTime";
            this.Size = new System.Drawing.Size(576, 198);
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartHour1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartMinite1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdStartMinite2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffHour1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffMinite1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdGoOffMinite2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupdStartHour1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nupdStartMinite1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nupdStartHour2;
        private System.Windows.Forms.NumericUpDown nupdStartMinite2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nupdGoOffHour1;
        private System.Windows.Forms.NumericUpDown nupdGoOffMinite1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nupdGoOffHour2;
        private System.Windows.Forms.NumericUpDown nupdGoOffMinite2;
        private System.Windows.Forms.Label label13;
    }
}
