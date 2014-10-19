namespace LSM
{
    partial class GenEvalSamplesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveBt = new System.Windows.Forms.Button();
            this.browseBt = new System.Windows.Forms.Button();
            this.savePathTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setLayerGBox = new System.Windows.Forms.GroupBox();
            this.resampleMethodCmBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AllToLeftBt = new System.Windows.Forms.Button();
            this.ToLeftBt = new System.Windows.Forms.Button();
            this.ToRightBt = new System.Windows.Forms.Button();
            this.AllToRightBt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.baseLayerCmBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.setLayerGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveBt);
            this.groupBox1.Controls.Add(this.browseBt);
            this.groupBox1.Controls.Add(this.savePathTxtBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 85);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待评估样本保存";
            // 
            // saveBt
            // 
            this.saveBt.Location = new System.Drawing.Point(344, 44);
            this.saveBt.Name = "saveBt";
            this.saveBt.Size = new System.Drawing.Size(67, 23);
            this.saveBt.TabIndex = 4;
            this.saveBt.Text = "保存";
            this.saveBt.UseVisualStyleBackColor = true;
            this.saveBt.Click += new System.EventHandler(this.saveBt_Click);
            // 
            // browseBt
            // 
            this.browseBt.Location = new System.Drawing.Point(271, 44);
            this.browseBt.Name = "browseBt";
            this.browseBt.Size = new System.Drawing.Size(67, 23);
            this.browseBt.TabIndex = 2;
            this.browseBt.Text = "浏览...";
            this.browseBt.UseVisualStyleBackColor = true;
            this.browseBt.Click += new System.EventHandler(this.browseBt_Click);
            // 
            // savePathTxtBox
            // 
            this.savePathTxtBox.Location = new System.Drawing.Point(14, 44);
            this.savePathTxtBox.Name = "savePathTxtBox";
            this.savePathTxtBox.Size = new System.Drawing.Size(251, 21);
            this.savePathTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存路径：";
            this.label1.UseWaitCursor = true;
            // 
            // setLayerGBox
            // 
            this.setLayerGBox.Controls.Add(this.resampleMethodCmBox);
            this.setLayerGBox.Controls.Add(this.label2);
            this.setLayerGBox.Controls.Add(this.AllToLeftBt);
            this.setLayerGBox.Controls.Add(this.ToLeftBt);
            this.setLayerGBox.Controls.Add(this.ToRightBt);
            this.setLayerGBox.Controls.Add(this.AllToRightBt);
            this.setLayerGBox.Controls.Add(this.label8);
            this.setLayerGBox.Controls.Add(this.listBox2);
            this.setLayerGBox.Controls.Add(this.listBox1);
            this.setLayerGBox.Controls.Add(this.label7);
            this.setLayerGBox.Controls.Add(this.baseLayerCmBox);
            this.setLayerGBox.Controls.Add(this.label6);
            this.setLayerGBox.Location = new System.Drawing.Point(24, 16);
            this.setLayerGBox.Name = "setLayerGBox";
            this.setLayerGBox.Size = new System.Drawing.Size(423, 346);
            this.setLayerGBox.TabIndex = 6;
            this.setLayerGBox.TabStop = false;
            this.setLayerGBox.Text = "图层设置";
            // 
            // resampleMethodCmBox
            // 
            this.resampleMethodCmBox.FormattingEnabled = true;
            this.resampleMethodCmBox.Items.AddRange(new object[] {
            "最邻近法",
            "双线性内插法",
            "三次卷积插值法"});
            this.resampleMethodCmBox.Location = new System.Drawing.Point(118, 62);
            this.resampleMethodCmBox.Name = "resampleMethodCmBox";
            this.resampleMethodCmBox.Size = new System.Drawing.Size(215, 20);
            this.resampleMethodCmBox.TabIndex = 27;
            this.resampleMethodCmBox.Text = "无";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "重采样方法：";
            // 
            // AllToLeftBt
            // 
            this.AllToLeftBt.Location = new System.Drawing.Point(187, 245);
            this.AllToLeftBt.Name = "AllToLeftBt";
            this.AllToLeftBt.Size = new System.Drawing.Size(52, 23);
            this.AllToLeftBt.TabIndex = 25;
            this.AllToLeftBt.Tag = "AllToLeft";
            this.AllToLeftBt.Text = "<<";
            this.AllToLeftBt.UseVisualStyleBackColor = true;
            this.AllToLeftBt.Click += new System.EventHandler(this.AllToLeftBt_Click);
            // 
            // ToLeftBt
            // 
            this.ToLeftBt.Location = new System.Drawing.Point(187, 215);
            this.ToLeftBt.Name = "ToLeftBt";
            this.ToLeftBt.Size = new System.Drawing.Size(52, 23);
            this.ToLeftBt.TabIndex = 24;
            this.ToLeftBt.Tag = "ToLeft";
            this.ToLeftBt.Text = "<";
            this.ToLeftBt.UseVisualStyleBackColor = true;
            this.ToLeftBt.Click += new System.EventHandler(this.ToLeftBt_Click);
            // 
            // ToRightBt
            // 
            this.ToRightBt.Location = new System.Drawing.Point(187, 185);
            this.ToRightBt.Name = "ToRightBt";
            this.ToRightBt.Size = new System.Drawing.Size(52, 23);
            this.ToRightBt.TabIndex = 23;
            this.ToRightBt.Tag = "ToRight";
            this.ToRightBt.Text = ">";
            this.ToRightBt.UseVisualStyleBackColor = true;
            this.ToRightBt.Click += new System.EventHandler(this.ToRightBt_Click);
            // 
            // AllToRightBt
            // 
            this.AllToRightBt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AllToRightBt.Location = new System.Drawing.Point(187, 155);
            this.AllToRightBt.Name = "AllToRightBt";
            this.AllToRightBt.Size = new System.Drawing.Size(52, 23);
            this.AllToRightBt.TabIndex = 22;
            this.AllToRightBt.Tag = "AllToRight";
            this.AllToRightBt.Text = ">>";
            this.AllToRightBt.UseVisualStyleBackColor = true;
            this.AllToRightBt.Click += new System.EventHandler(this.AllToRightBt_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "选中影响因子图层：";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(245, 125);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(141, 196);
            this.listBox2.TabIndex = 20;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(40, 126);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(140, 196);
            this.listBox1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "可选影响因子图层：";
            // 
            // baseLayerCmBox
            // 
            this.baseLayerCmBox.FormattingEnabled = true;
            this.baseLayerCmBox.Location = new System.Drawing.Point(118, 25);
            this.baseLayerCmBox.Name = "baseLayerCmBox";
            this.baseLayerCmBox.Size = new System.Drawing.Size(215, 20);
            this.baseLayerCmBox.TabIndex = 14;
            this.baseLayerCmBox.SelectedIndexChanged += new System.EventHandler(this.baseLayerCmBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "基准图层：";
            // 
            // GenEvalSamplesForm
            // 
            this.AcceptButton = this.saveBt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.setLayerGBox);
            this.Name = "GenEvalSamplesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地质灾害危险性评估：待评估样本生成";
            this.Load += new System.EventHandler(this.GenEvalSamplesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.setLayerGBox.ResumeLayout(false);
            this.setLayerGBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseBt;
        private System.Windows.Forms.TextBox savePathTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox setLayerGBox;
        private System.Windows.Forms.Button AllToLeftBt;
        private System.Windows.Forms.Button ToLeftBt;
        private System.Windows.Forms.Button ToRightBt;
        private System.Windows.Forms.Button AllToRightBt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox baseLayerCmBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveBt;
        private System.Windows.Forms.ComboBox resampleMethodCmBox;
        private System.Windows.Forms.Label label2;
    }
}