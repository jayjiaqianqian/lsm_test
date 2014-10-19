namespace LSM
{
    partial class GenTrainSamplesForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.setLayerGBox = new System.Windows.Forms.GroupBox();
            this.AllToLeftBt = new System.Windows.Forms.Button();
            this.ToLeftBt = new System.Windows.Forms.Button();
            this.ToRightBt = new System.Windows.Forms.Button();
            this.AllToRightBt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.nohazardCmBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmRaBt = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.samPercentTxtBox = new System.Windows.Forms.TextBox();
            this.partHazardPtRaBt = new System.Windows.Forms.RadioButton();
            this.allHazardPtRaBt = new System.Windows.Forms.RadioButton();
            this.hazardCmBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.setLayerGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveBt);
            this.groupBox1.Controls.Add(this.browseBt);
            this.groupBox1.Controls.Add(this.savePathTxtBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(21, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "训练样本保存";
            // 
            // saveBt
            // 
            this.saveBt.Location = new System.Drawing.Point(578, 40);
            this.saveBt.Name = "saveBt";
            this.saveBt.Size = new System.Drawing.Size(67, 23);
            this.saveBt.TabIndex = 3;
            this.saveBt.Text = "保存";
            this.saveBt.UseVisualStyleBackColor = true;
            this.saveBt.Click += new System.EventHandler(this.saveBt_Click);
            // 
            // browseBt
            // 
            this.browseBt.Location = new System.Drawing.Point(490, 40);
            this.browseBt.Name = "browseBt";
            this.browseBt.Size = new System.Drawing.Size(67, 23);
            this.browseBt.TabIndex = 2;
            this.browseBt.Text = "浏览...";
            this.browseBt.UseVisualStyleBackColor = true;
            this.browseBt.Click += new System.EventHandler(this.browseBt_Click);
            // 
            // savePathTxtBox
            // 
            this.savePathTxtBox.Location = new System.Drawing.Point(106, 42);
            this.savePathTxtBox.Name = "savePathTxtBox";
            this.savePathTxtBox.Size = new System.Drawing.Size(357, 21);
            this.savePathTxtBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "保存路径：";
            // 
            // setLayerGBox
            // 
            this.setLayerGBox.Controls.Add(this.AllToLeftBt);
            this.setLayerGBox.Controls.Add(this.ToLeftBt);
            this.setLayerGBox.Controls.Add(this.ToRightBt);
            this.setLayerGBox.Controls.Add(this.AllToRightBt);
            this.setLayerGBox.Controls.Add(this.label8);
            this.setLayerGBox.Controls.Add(this.listBox2);
            this.setLayerGBox.Controls.Add(this.endDateTimePicker);
            this.setLayerGBox.Controls.Add(this.listBox1);
            this.setLayerGBox.Controls.Add(this.startDateTimePicker);
            this.setLayerGBox.Controls.Add(this.label7);
            this.setLayerGBox.Controls.Add(this.nohazardCmBox);
            this.setLayerGBox.Controls.Add(this.label5);
            this.setLayerGBox.Controls.Add(this.label4);
            this.setLayerGBox.Controls.Add(this.label3);
            this.setLayerGBox.Controls.Add(this.tmRaBt);
            this.setLayerGBox.Controls.Add(this.label2);
            this.setLayerGBox.Controls.Add(this.samPercentTxtBox);
            this.setLayerGBox.Controls.Add(this.partHazardPtRaBt);
            this.setLayerGBox.Controls.Add(this.allHazardPtRaBt);
            this.setLayerGBox.Controls.Add(this.hazardCmBox);
            this.setLayerGBox.Controls.Add(this.label1);
            this.setLayerGBox.Location = new System.Drawing.Point(21, 20);
            this.setLayerGBox.Name = "setLayerGBox";
            this.setLayerGBox.Size = new System.Drawing.Size(670, 288);
            this.setLayerGBox.TabIndex = 5;
            this.setLayerGBox.TabStop = false;
            this.setLayerGBox.Text = "图层设置";
            // 
            // AllToLeftBt
            // 
            this.AllToLeftBt.Location = new System.Drawing.Point(471, 183);
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
            this.ToLeftBt.Location = new System.Drawing.Point(471, 153);
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
            this.ToRightBt.Location = new System.Drawing.Point(471, 123);
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
            this.AllToRightBt.Location = new System.Drawing.Point(471, 93);
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
            this.label8.Location = new System.Drawing.Point(532, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "选中影响因子图层：";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(534, 52);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(123, 208);
            this.listBox2.TabIndex = 20;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Enabled = false;
            this.endDateTimePicker.Location = new System.Drawing.Point(181, 178);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(126, 21);
            this.endDateTimePicker.TabIndex = 19;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(338, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(123, 208);
            this.listBox1.TabIndex = 18;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Enabled = false;
            this.startDateTimePicker.Location = new System.Drawing.Point(181, 146);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(126, 21);
            this.startDateTimePicker.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "可选影响因子图层：";
            // 
            // nohazardCmBox
            // 
            this.nohazardCmBox.FormattingEnabled = true;
            this.nohazardCmBox.Location = new System.Drawing.Point(106, 240);
            this.nohazardCmBox.Name = "nohazardCmBox";
            this.nohazardCmBox.Size = new System.Drawing.Size(203, 20);
            this.nohazardCmBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "非灾害点图层：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "终止时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "起始时间";
            // 
            // tmRaBt
            // 
            this.tmRaBt.AutoSize = true;
            this.tmRaBt.Enabled = false;
            this.tmRaBt.Location = new System.Drawing.Point(104, 124);
            this.tmRaBt.Name = "tmRaBt";
            this.tmRaBt.Size = new System.Drawing.Size(107, 16);
            this.tmRaBt.TabIndex = 6;
            this.tmRaBt.Text = "按发生时间选取";
            this.tmRaBt.UseVisualStyleBackColor = true;
            this.tmRaBt.CheckedChanged += new System.EventHandler(this.tmRaBt_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "%样本数";
            // 
            // samPercentTxtBox
            // 
            this.samPercentTxtBox.Enabled = false;
            this.samPercentTxtBox.Location = new System.Drawing.Point(181, 91);
            this.samPercentTxtBox.Name = "samPercentTxtBox";
            this.samPercentTxtBox.Size = new System.Drawing.Size(53, 21);
            this.samPercentTxtBox.TabIndex = 4;
            // 
            // partHazardPtRaBt
            // 
            this.partHazardPtRaBt.AutoSize = true;
            this.partHazardPtRaBt.Enabled = false;
            this.partHazardPtRaBt.Location = new System.Drawing.Point(104, 95);
            this.partHazardPtRaBt.Name = "partHazardPtRaBt";
            this.partHazardPtRaBt.Size = new System.Drawing.Size(71, 16);
            this.partHazardPtRaBt.TabIndex = 3;
            this.partHazardPtRaBt.Text = "随机取样";
            this.partHazardPtRaBt.UseVisualStyleBackColor = true;
            this.partHazardPtRaBt.CheckedChanged += new System.EventHandler(this.partHazardPtRaBt_CheckedChanged);
            // 
            // allHazardPtRaBt
            // 
            this.allHazardPtRaBt.AutoSize = true;
            this.allHazardPtRaBt.Checked = true;
            this.allHazardPtRaBt.Enabled = false;
            this.allHazardPtRaBt.Location = new System.Drawing.Point(104, 65);
            this.allHazardPtRaBt.Name = "allHazardPtRaBt";
            this.allHazardPtRaBt.Size = new System.Drawing.Size(71, 16);
            this.allHazardPtRaBt.TabIndex = 2;
            this.allHazardPtRaBt.TabStop = true;
            this.allHazardPtRaBt.Text = "使用全部";
            this.allHazardPtRaBt.UseVisualStyleBackColor = true;
            this.allHazardPtRaBt.CheckedChanged += new System.EventHandler(this.allHazardPtRaBt_CheckedChanged);
            // 
            // hazardCmBox
            // 
            this.hazardCmBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.hazardCmBox.FormattingEnabled = true;
            this.hazardCmBox.Location = new System.Drawing.Point(104, 29);
            this.hazardCmBox.Name = "hazardCmBox";
            this.hazardCmBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hazardCmBox.Size = new System.Drawing.Size(203, 20);
            this.hazardCmBox.TabIndex = 1;
            this.hazardCmBox.SelectedIndexChanged += new System.EventHandler(this.hazardCmBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "灾害点图层：";
            // 
            // GenTrainSamplesForm
            // 
            this.AcceptButton = this.saveBt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.setLayerGBox);
            this.Name = "GenTrainSamplesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地质灾害危险性评估：训练样本生成";
            this.Load += new System.EventHandler(this.GenTrainSamplesForm_Load);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox setLayerGBox;
        private System.Windows.Forms.Button AllToLeftBt;
        private System.Windows.Forms.Button ToLeftBt;
        private System.Windows.Forms.Button ToRightBt;
        private System.Windows.Forms.Button AllToRightBt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox nohazardCmBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton tmRaBt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox samPercentTxtBox;
        private System.Windows.Forms.RadioButton partHazardPtRaBt;
        private System.Windows.Forms.RadioButton allHazardPtRaBt;
        private System.Windows.Forms.ComboBox hazardCmBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBt;
    }
}