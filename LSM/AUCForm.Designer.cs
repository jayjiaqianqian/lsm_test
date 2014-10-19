namespace LSM
{
    partial class AUCForm
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
            this.end_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.start_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PJTC_none_button = new System.Windows.Forms.Button();
            this.PJTC_no_button = new System.Windows.Forms.Button();
            this.PJTC_yes_button = new System.Windows.Forms.Button();
            this.PJTC_all_button = new System.Windows.Forms.Button();
            this.PJTC_choosed_listBox = new System.Windows.Forms.ListBox();
            this.PJTC_choice_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ZHDTC_time_radioButton2 = new System.Windows.Forms.RadioButton();
            this.ZHDTC_time_radioButton1 = new System.Windows.Forms.RadioButton();
            this.ZHDTC_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AUC_cancel_button = new System.Windows.Forms.Button();
            this.AUC_startcompute_button = new System.Windows.Forms.Button();
            this.AUC_filerouteliulan_button = new System.Windows.Forms.Button();
            this.AUC_fileroute_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.end_dateTimePicker);
            this.groupBox1.Controls.Add(this.start_dateTimePicker);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PJTC_none_button);
            this.groupBox1.Controls.Add(this.PJTC_no_button);
            this.groupBox1.Controls.Add(this.PJTC_yes_button);
            this.groupBox1.Controls.Add(this.PJTC_all_button);
            this.groupBox1.Controls.Add(this.PJTC_choosed_listBox);
            this.groupBox1.Controls.Add(this.PJTC_choice_listBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ZHDTC_time_radioButton2);
            this.groupBox1.Controls.Add(this.ZHDTC_time_radioButton1);
            this.groupBox1.Controls.Add(this.ZHDTC_comboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 427);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图层设置：";
            // 
            // end_dateTimePicker
            // 
            this.end_dateTimePicker.Location = new System.Drawing.Point(210, 153);
            this.end_dateTimePicker.Name = "end_dateTimePicker";
            this.end_dateTimePicker.Size = new System.Drawing.Size(139, 21);
            this.end_dateTimePicker.TabIndex = 80;
            // 
            // start_dateTimePicker
            // 
            this.start_dateTimePicker.Location = new System.Drawing.Point(210, 122);
            this.start_dateTimePicker.Name = "start_dateTimePicker";
            this.start_dateTimePicker.Size = new System.Drawing.Size(139, 21);
            this.start_dateTimePicker.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(298, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 78;
            this.label5.Text = "选中评价结果图层：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(20, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "可选评价结果图层：";
            // 
            // PJTC_none_button
            // 
            this.PJTC_none_button.Location = new System.Drawing.Point(200, 360);
            this.PJTC_none_button.Name = "PJTC_none_button";
            this.PJTC_none_button.Size = new System.Drawing.Size(64, 23);
            this.PJTC_none_button.TabIndex = 76;
            this.PJTC_none_button.Text = "<<";
            this.PJTC_none_button.UseVisualStyleBackColor = true;
            this.PJTC_none_button.Click += new System.EventHandler(this.PJTC_none_button_Click);
            // 
            // PJTC_no_button
            // 
            this.PJTC_no_button.Location = new System.Drawing.Point(200, 319);
            this.PJTC_no_button.Name = "PJTC_no_button";
            this.PJTC_no_button.Size = new System.Drawing.Size(64, 23);
            this.PJTC_no_button.TabIndex = 75;
            this.PJTC_no_button.Text = "<";
            this.PJTC_no_button.UseVisualStyleBackColor = true;
            this.PJTC_no_button.Click += new System.EventHandler(this.PJTC_no_button_Click);
            // 
            // PJTC_yes_button
            // 
            this.PJTC_yes_button.Location = new System.Drawing.Point(200, 279);
            this.PJTC_yes_button.Name = "PJTC_yes_button";
            this.PJTC_yes_button.Size = new System.Drawing.Size(64, 23);
            this.PJTC_yes_button.TabIndex = 74;
            this.PJTC_yes_button.Text = ">";
            this.PJTC_yes_button.UseVisualStyleBackColor = true;
            this.PJTC_yes_button.Click += new System.EventHandler(this.PJTC_yes_button_Click);
            // 
            // PJTC_all_button
            // 
            this.PJTC_all_button.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PJTC_all_button.Location = new System.Drawing.Point(200, 238);
            this.PJTC_all_button.Name = "PJTC_all_button";
            this.PJTC_all_button.Size = new System.Drawing.Size(64, 23);
            this.PJTC_all_button.TabIndex = 73;
            this.PJTC_all_button.Text = ">>";
            this.PJTC_all_button.UseVisualStyleBackColor = true;
            this.PJTC_all_button.Click += new System.EventHandler(this.PJTC_all_button_Click);
            // 
            // PJTC_choosed_listBox
            // 
            this.PJTC_choosed_listBox.FormattingEnabled = true;
            this.PJTC_choosed_listBox.ItemHeight = 12;
            this.PJTC_choosed_listBox.Location = new System.Drawing.Point(300, 221);
            this.PJTC_choosed_listBox.Name = "PJTC_choosed_listBox";
            this.PJTC_choosed_listBox.Size = new System.Drawing.Size(139, 184);
            this.PJTC_choosed_listBox.TabIndex = 72;
            // 
            // PJTC_choice_listBox
            // 
            this.PJTC_choice_listBox.FormattingEnabled = true;
            this.PJTC_choice_listBox.ItemHeight = 12;
            this.PJTC_choice_listBox.Location = new System.Drawing.Point(22, 221);
            this.PJTC_choice_listBox.Name = "PJTC_choice_listBox";
            this.PJTC_choice_listBox.Size = new System.Drawing.Size(139, 184);
            this.PJTC_choice_listBox.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(137, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 70;
            this.label3.Text = "终止时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(137, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 69;
            this.label2.Text = "起始时间";
            // 
            // ZHDTC_time_radioButton2
            // 
            this.ZHDTC_time_radioButton2.AutoSize = true;
            this.ZHDTC_time_radioButton2.Font = new System.Drawing.Font("宋体", 9F);
            this.ZHDTC_time_radioButton2.Location = new System.Drawing.Point(119, 93);
            this.ZHDTC_time_radioButton2.Name = "ZHDTC_time_radioButton2";
            this.ZHDTC_time_radioButton2.Size = new System.Drawing.Size(107, 16);
            this.ZHDTC_time_radioButton2.TabIndex = 68;
            this.ZHDTC_time_radioButton2.TabStop = true;
            this.ZHDTC_time_radioButton2.Text = "按发生时间选取";
            this.ZHDTC_time_radioButton2.UseVisualStyleBackColor = true;
            this.ZHDTC_time_radioButton2.CheckedChanged += new System.EventHandler(this.ZHDTC_time_radioButton2_CheckedChanged);
            // 
            // ZHDTC_time_radioButton1
            // 
            this.ZHDTC_time_radioButton1.AutoSize = true;
            this.ZHDTC_time_radioButton1.Checked = true;
            this.ZHDTC_time_radioButton1.Font = new System.Drawing.Font("宋体", 9F);
            this.ZHDTC_time_radioButton1.Location = new System.Drawing.Point(119, 60);
            this.ZHDTC_time_radioButton1.Name = "ZHDTC_time_radioButton1";
            this.ZHDTC_time_radioButton1.Size = new System.Drawing.Size(71, 16);
            this.ZHDTC_time_radioButton1.TabIndex = 67;
            this.ZHDTC_time_radioButton1.TabStop = true;
            this.ZHDTC_time_radioButton1.Text = "使用全部";
            this.ZHDTC_time_radioButton1.UseVisualStyleBackColor = true;
            this.ZHDTC_time_radioButton1.CheckedChanged += new System.EventHandler(this.ZHDTC_time_radioButton1_CheckedChanged);
            // 
            // ZHDTC_comboBox
            // 
            this.ZHDTC_comboBox.FormattingEnabled = true;
            this.ZHDTC_comboBox.Location = new System.Drawing.Point(119, 24);
            this.ZHDTC_comboBox.Name = "ZHDTC_comboBox";
            this.ZHDTC_comboBox.Size = new System.Drawing.Size(230, 20);
            this.ZHDTC_comboBox.TabIndex = 66;
            this.ZHDTC_comboBox.SelectedIndexChanged += new System.EventHandler(this.ZHDTC_comboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 65;
            this.label1.Text = "灾害点图层：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AUC_cancel_button);
            this.groupBox2.Controls.Add(this.AUC_startcompute_button);
            this.groupBox2.Controls.Add(this.AUC_filerouteliulan_button);
            this.groupBox2.Controls.Add(this.AUC_fileroute_textBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(25, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 110);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AUC结果文件生成：";
            // 
            // AUC_cancel_button
            // 
            this.AUC_cancel_button.Font = new System.Drawing.Font("宋体", 9F);
            this.AUC_cancel_button.Location = new System.Drawing.Point(372, 79);
            this.AUC_cancel_button.Name = "AUC_cancel_button";
            this.AUC_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.AUC_cancel_button.TabIndex = 67;
            this.AUC_cancel_button.Text = "取消";
            this.AUC_cancel_button.UseVisualStyleBackColor = true;
            this.AUC_cancel_button.Click += new System.EventHandler(this.AUC_cancel_button_Click);
            // 
            // AUC_startcompute_button
            // 
            this.AUC_startcompute_button.Font = new System.Drawing.Font("宋体", 9F);
            this.AUC_startcompute_button.Location = new System.Drawing.Point(264, 79);
            this.AUC_startcompute_button.Name = "AUC_startcompute_button";
            this.AUC_startcompute_button.Size = new System.Drawing.Size(75, 23);
            this.AUC_startcompute_button.TabIndex = 66;
            this.AUC_startcompute_button.Text = "开始计算";
            this.AUC_startcompute_button.UseVisualStyleBackColor = true;
            this.AUC_startcompute_button.Click += new System.EventHandler(this.AUC_startcompute_button_Click);
            // 
            // AUC_filerouteliulan_button
            // 
            this.AUC_filerouteliulan_button.Font = new System.Drawing.Font("宋体", 9F);
            this.AUC_filerouteliulan_button.Location = new System.Drawing.Point(372, 42);
            this.AUC_filerouteliulan_button.Name = "AUC_filerouteliulan_button";
            this.AUC_filerouteliulan_button.Size = new System.Drawing.Size(75, 23);
            this.AUC_filerouteliulan_button.TabIndex = 65;
            this.AUC_filerouteliulan_button.Text = "浏览…";
            this.AUC_filerouteliulan_button.UseVisualStyleBackColor = true;
            this.AUC_filerouteliulan_button.Click += new System.EventHandler(this.AUC_filerouteliulan_button_Click);
            // 
            // AUC_fileroute_textBox
            // 
            this.AUC_fileroute_textBox.Location = new System.Drawing.Point(11, 44);
            this.AUC_fileroute_textBox.Name = "AUC_fileroute_textBox";
            this.AUC_fileroute_textBox.Size = new System.Drawing.Size(328, 21);
            this.AUC_fileroute_textBox.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(8, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "保存路径：";
            // 
            // AUCForm
            // 
            this.AcceptButton = this.AUC_startcompute_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 596);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AUCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUC结果评价";
            this.Load += new System.EventHandler(this.AUCForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker end_dateTimePicker;
        private System.Windows.Forms.DateTimePicker start_dateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PJTC_none_button;
        private System.Windows.Forms.Button PJTC_no_button;
        private System.Windows.Forms.Button PJTC_yes_button;
        private System.Windows.Forms.Button PJTC_all_button;
        private System.Windows.Forms.ListBox PJTC_choosed_listBox;
        private System.Windows.Forms.ListBox PJTC_choice_listBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton ZHDTC_time_radioButton2;
        private System.Windows.Forms.RadioButton ZHDTC_time_radioButton1;
        private System.Windows.Forms.ComboBox ZHDTC_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AUC_cancel_button;
        private System.Windows.Forms.Button AUC_startcompute_button;
        private System.Windows.Forms.Button AUC_filerouteliulan_button;
        private System.Windows.Forms.TextBox AUC_fileroute_textBox;
        private System.Windows.Forms.Label label6;
    }
}