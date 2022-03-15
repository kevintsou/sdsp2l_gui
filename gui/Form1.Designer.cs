﻿
namespace gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.initDevBtn = new System.Windows.Forms.Button();
            this.pageTxBox = new System.Windows.Forms.TextBox();
            this.planeTxBox = new System.Windows.Forms.TextBox();
            this.blkTxBox = new System.Windows.Forms.TextBox();
            this.chTxBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_ch = new System.Windows.Forms.Label();
            this.erase_cmd_btn = new System.Windows.Forms.Button();
            this.ddr_size_btn = new System.Windows.Forms.Button();
            this.read_cmd_btn = new System.Windows.Forms.Button();
            this.dev_cap_btn = new System.Windows.Forms.Button();
            this.write_cmd_btn = new System.Windows.Forms.Button();
            this.testGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timeElapsedTxBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBx_rslt = new System.Windows.Forms.CheckBox();
            this.testTypeBox1 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pageNum = new System.Windows.Forms.Label();
            this.testCmdBtn = new System.Windows.Forms.Button();
            this.planeNum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dramSizeList = new System.Windows.Forms.ComboBox();
            this.chNum = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeTxBox = new System.Windows.Forms.TextBox();
            this.devCapBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSMART = new System.Windows.Forms.TabPage();
            this.btn_clearSmart = new System.Windows.Forms.Button();
            this.listViewSmart = new System.Windows.Forms.ListView();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.timer_1sec = new System.Windows.Forms.Timer(this.components);
            this.timer_300MS = new System.Windows.Forms.Timer(this.components);
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.testGroup.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabSMART.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.mainTab);
            this.tabControl.Controls.Add(this.tabSMART);
            this.tabControl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.ItemSize = new System.Drawing.Size(80, 30);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(757, 283);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.groupBox1);
            this.mainTab.Controls.Add(this.testGroup);
            this.mainTab.Location = new System.Drawing.Point(4, 34);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(749, 245);
            this.mainTab.TabIndex = 1;
            this.mainTab.Text = "Main";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.initDevBtn);
            this.groupBox1.Controls.Add(this.pageTxBox);
            this.groupBox1.Controls.Add(this.planeTxBox);
            this.groupBox1.Controls.Add(this.blkTxBox);
            this.groupBox1.Controls.Add(this.chTxBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lab_ch);
            this.groupBox1.Controls.Add(this.erase_cmd_btn);
            this.groupBox1.Controls.Add(this.ddr_size_btn);
            this.groupBox1.Controls.Add(this.read_cmd_btn);
            this.groupBox1.Controls.Add(this.dev_cap_btn);
            this.groupBox1.Controls.Add(this.write_cmd_btn);
            this.groupBox1.Location = new System.Drawing.Point(373, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 217);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command";
            // 
            // initDevBtn
            // 
            this.initDevBtn.Location = new System.Drawing.Point(214, 168);
            this.initDevBtn.Name = "initDevBtn";
            this.initDevBtn.Size = new System.Drawing.Size(95, 23);
            this.initDevBtn.TabIndex = 43;
            this.initDevBtn.Text = "Init Device";
            this.initDevBtn.UseVisualStyleBackColor = true;
            this.initDevBtn.Click += new System.EventHandler(this.initDevBtn_Click);
            // 
            // pageTxBox
            // 
            this.pageTxBox.Location = new System.Drawing.Point(85, 112);
            this.pageTxBox.Name = "pageTxBox";
            this.pageTxBox.Size = new System.Drawing.Size(77, 23);
            this.pageTxBox.TabIndex = 42;
            this.pageTxBox.Text = "8";
            this.pageTxBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chTxBox_KeyPress);
            // 
            // planeTxBox
            // 
            this.planeTxBox.Location = new System.Drawing.Point(85, 83);
            this.planeTxBox.Name = "planeTxBox";
            this.planeTxBox.Size = new System.Drawing.Size(77, 23);
            this.planeTxBox.TabIndex = 41;
            this.planeTxBox.Text = "0";
            this.planeTxBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chTxBox_KeyPress);
            // 
            // blkTxBox
            // 
            this.blkTxBox.Location = new System.Drawing.Point(85, 54);
            this.blkTxBox.Name = "blkTxBox";
            this.blkTxBox.Size = new System.Drawing.Size(77, 23);
            this.blkTxBox.TabIndex = 40;
            this.blkTxBox.Text = "0";
            this.blkTxBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chTxBox_KeyPress);
            // 
            // chTxBox
            // 
            this.chTxBox.Location = new System.Drawing.Point(85, 25);
            this.chTxBox.Name = "chTxBox";
            this.chTxBox.Size = new System.Drawing.Size(77, 23);
            this.chTxBox.TabIndex = 39;
            this.chTxBox.Text = "0";
            this.chTxBox.TextChanged += new System.EventHandler(this.chTxBox_TextChanged);
            this.chTxBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chTxBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "Page:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Plane:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Block:";
            // 
            // lab_ch
            // 
            this.lab_ch.AutoSize = true;
            this.lab_ch.Location = new System.Drawing.Point(35, 28);
            this.lab_ch.Name = "lab_ch";
            this.lab_ch.Size = new System.Drawing.Size(27, 15);
            this.lab_ch.TabIndex = 35;
            this.lab_ch.Text = "CH:";
            // 
            // erase_cmd_btn
            // 
            this.erase_cmd_btn.Location = new System.Drawing.Point(214, 81);
            this.erase_cmd_btn.Name = "erase_cmd_btn";
            this.erase_cmd_btn.Size = new System.Drawing.Size(95, 23);
            this.erase_cmd_btn.TabIndex = 31;
            this.erase_cmd_btn.Text = "EraseCmd";
            this.erase_cmd_btn.UseVisualStyleBackColor = true;
            // 
            // ddr_size_btn
            // 
            this.ddr_size_btn.Location = new System.Drawing.Point(214, 140);
            this.ddr_size_btn.Name = "ddr_size_btn";
            this.ddr_size_btn.Size = new System.Drawing.Size(95, 23);
            this.ddr_size_btn.TabIndex = 28;
            this.ddr_size_btn.Text = "GetDdrSize";
            this.ddr_size_btn.UseVisualStyleBackColor = true;
            this.ddr_size_btn.Click += new System.EventHandler(this.ddr_size_btn_Click);
            // 
            // read_cmd_btn
            // 
            this.read_cmd_btn.Location = new System.Drawing.Point(214, 52);
            this.read_cmd_btn.Name = "read_cmd_btn";
            this.read_cmd_btn.Size = new System.Drawing.Size(95, 23);
            this.read_cmd_btn.TabIndex = 30;
            this.read_cmd_btn.Text = "ReadCmd";
            this.read_cmd_btn.UseVisualStyleBackColor = true;
            this.read_cmd_btn.Click += new System.EventHandler(this.read_cmd_btn_Click);
            // 
            // dev_cap_btn
            // 
            this.dev_cap_btn.Location = new System.Drawing.Point(214, 111);
            this.dev_cap_btn.Name = "dev_cap_btn";
            this.dev_cap_btn.Size = new System.Drawing.Size(95, 23);
            this.dev_cap_btn.TabIndex = 27;
            this.dev_cap_btn.Text = "GetDevCap";
            this.dev_cap_btn.UseVisualStyleBackColor = true;
            this.dev_cap_btn.Click += new System.EventHandler(this.dev_cap_btn_Click);
            // 
            // write_cmd_btn
            // 
            this.write_cmd_btn.Location = new System.Drawing.Point(214, 23);
            this.write_cmd_btn.Name = "write_cmd_btn";
            this.write_cmd_btn.Size = new System.Drawing.Size(95, 23);
            this.write_cmd_btn.TabIndex = 29;
            this.write_cmd_btn.Text = "WriteCmd";
            this.write_cmd_btn.UseVisualStyleBackColor = true;
            this.write_cmd_btn.Click += new System.EventHandler(this.write_cmd_btn_Click);
            // 
            // testGroup
            // 
            this.testGroup.Controls.Add(this.textBox1);
            this.testGroup.Controls.Add(this.groupBox3);
            this.testGroup.Controls.Add(this.textBox2);
            this.testGroup.Controls.Add(this.checkBx_rslt);
            this.testGroup.Controls.Add(this.testTypeBox1);
            this.testGroup.Controls.Add(this.textBox4);
            this.testGroup.Controls.Add(this.pageNum);
            this.testGroup.Controls.Add(this.testCmdBtn);
            this.testGroup.Controls.Add(this.planeNum);
            this.testGroup.Controls.Add(this.label7);
            this.testGroup.Controls.Add(this.dramSizeList);
            this.testGroup.Controls.Add(this.chNum);
            this.testGroup.Controls.Add(this.label8);
            this.testGroup.Controls.Add(this.label3);
            this.testGroup.Controls.Add(this.timeTxBox);
            this.testGroup.Controls.Add(this.devCapBox);
            this.testGroup.Controls.Add(this.label1);
            this.testGroup.Location = new System.Drawing.Point(15, 15);
            this.testGroup.Name = "testGroup";
            this.testGroup.Size = new System.Drawing.Size(341, 217);
            this.testGroup.TabIndex = 37;
            this.testGroup.TabStop = false;
            this.testGroup.Text = "Script test";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 23);
            this.textBox1.TabIndex = 51;
            this.textBox1.Text = "1024";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.timeElapsedTxBox);
            this.groupBox3.Location = new System.Drawing.Point(134, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 46);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time elapsed";
            // 
            // timeElapsedTxBox
            // 
            this.timeElapsedTxBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeElapsedTxBox.Location = new System.Drawing.Point(31, 17);
            this.timeElapsedTxBox.Name = "timeElapsedTxBox";
            this.timeElapsedTxBox.Size = new System.Drawing.Size(123, 16);
            this.timeElapsedTxBox.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 23);
            this.textBox2.TabIndex = 50;
            this.textBox2.Text = "4";
            // 
            // checkBx_rslt
            // 
            this.checkBx_rslt.AutoSize = true;
            this.checkBx_rslt.Location = new System.Drawing.Point(196, 128);
            this.checkBx_rslt.Name = "checkBx_rslt";
            this.checkBx_rslt.Size = new System.Drawing.Size(99, 19);
            this.checkBx_rslt.TabIndex = 37;
            this.checkBx_rslt.Text = "Output result";
            this.checkBx_rslt.UseVisualStyleBackColor = true;
            this.checkBx_rslt.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // testTypeBox1
            // 
            this.testTypeBox1.FormattingEnabled = true;
            this.testTypeBox1.Location = new System.Drawing.Point(69, 82);
            this.testTypeBox1.Name = "testTypeBox1";
            this.testTypeBox1.Size = new System.Drawing.Size(79, 23);
            this.testTypeBox1.TabIndex = 6;
            this.testTypeBox1.SelectedIndexChanged += new System.EventHandler(this.testTypeBox1_SelectedIndexChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(232, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(77, 23);
            this.textBox4.TabIndex = 47;
            this.textBox4.Text = "8";
            // 
            // pageNum
            // 
            this.pageNum.AutoSize = true;
            this.pageNum.Location = new System.Drawing.Point(182, 83);
            this.pageNum.Name = "pageNum";
            this.pageNum.Size = new System.Drawing.Size(47, 15);
            this.pageNum.TabIndex = 48;
            this.pageNum.Text = "Page#:";
            // 
            // testCmdBtn
            // 
            this.testCmdBtn.Location = new System.Drawing.Point(22, 165);
            this.testCmdBtn.Name = "testCmdBtn";
            this.testCmdBtn.Size = new System.Drawing.Size(95, 23);
            this.testCmdBtn.TabIndex = 36;
            this.testCmdBtn.Text = "Start Test";
            this.testCmdBtn.UseVisualStyleBackColor = true;
            this.testCmdBtn.Click += new System.EventHandler(this.testCmdBtn_Click);
            // 
            // planeNum
            // 
            this.planeNum.AutoSize = true;
            this.planeNum.Location = new System.Drawing.Point(182, 53);
            this.planeNum.Name = "planeNum";
            this.planeNum.Size = new System.Drawing.Size(49, 15);
            this.planeNum.TabIndex = 46;
            this.planeNum.Text = "Plane#:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Script:";
            // 
            // dramSizeList
            // 
            this.dramSizeList.FormattingEnabled = true;
            this.dramSizeList.Items.AddRange(new object[] {
            "8MB",
            "16MB",
            "32MB",
            "64MB"});
            this.dramSizeList.Location = new System.Drawing.Point(69, 53);
            this.dramSizeList.Name = "dramSizeList";
            this.dramSizeList.Size = new System.Drawing.Size(79, 23);
            this.dramSizeList.TabIndex = 34;
            this.dramSizeList.SelectedIndexChanged += new System.EventHandler(this.dramSizeList_SelectedIndexChanged);
            // 
            // chNum
            // 
            this.chNum.AutoSize = true;
            this.chNum.Location = new System.Drawing.Point(182, 27);
            this.chNum.Name = "chNum";
            this.chNum.Size = new System.Drawing.Size(35, 15);
            this.chNum.TabIndex = 45;
            this.chNum.Text = "CH#:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time (min):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Dram:";
            // 
            // timeTxBox
            // 
            this.timeTxBox.Location = new System.Drawing.Point(97, 125);
            this.timeTxBox.Name = "timeTxBox";
            this.timeTxBox.Size = new System.Drawing.Size(77, 23);
            this.timeTxBox.TabIndex = 12;
            this.timeTxBox.Text = "10";
            this.timeTxBox.TextChanged += new System.EventHandler(this.timeTxBox_TextChanged);
            this.timeTxBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chTxBox_KeyPress);
            // 
            // devCapBox
            // 
            this.devCapBox.FormattingEnabled = true;
            this.devCapBox.Items.AddRange(new object[] {
            "32GB",
            "64GB",
            "128GB",
            "256GB"});
            this.devCapBox.Location = new System.Drawing.Point(69, 24);
            this.devCapBox.Name = "devCapBox";
            this.devCapBox.Size = new System.Drawing.Size(79, 23);
            this.devCapBox.TabIndex = 32;
            this.devCapBox.SelectedIndexChanged += new System.EventHandler(this.devCapBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Cap:";
            // 
            // tabSMART
            // 
            this.tabSMART.Controls.Add(this.btn_clearSmart);
            this.tabSMART.Controls.Add(this.listViewSmart);
            this.tabSMART.Location = new System.Drawing.Point(4, 34);
            this.tabSMART.Name = "tabSMART";
            this.tabSMART.Padding = new System.Windows.Forms.Padding(3);
            this.tabSMART.Size = new System.Drawing.Size(749, 258);
            this.tabSMART.TabIndex = 2;
            this.tabSMART.Text = "Result";
            this.tabSMART.UseVisualStyleBackColor = true;
            this.tabSMART.Click += new System.EventHandler(this.tabSMART_Click);
            this.tabSMART.Enter += new System.EventHandler(this.tabSMART_Enter);
            // 
            // btn_clearSmart
            // 
            this.btn_clearSmart.Location = new System.Drawing.Point(689, 298);
            this.btn_clearSmart.Name = "btn_clearSmart";
            this.btn_clearSmart.Size = new System.Drawing.Size(113, 25);
            this.btn_clearSmart.TabIndex = 1;
            this.btn_clearSmart.Text = "Clear Smart";
            this.btn_clearSmart.UseVisualStyleBackColor = true;
            this.btn_clearSmart.Visible = false;
            // 
            // listViewSmart
            // 
            this.listViewSmart.HideSelection = false;
            this.listViewSmart.Location = new System.Drawing.Point(13, 17);
            this.listViewSmart.Name = "listViewSmart";
            this.listViewSmart.Size = new System.Drawing.Size(804, 318);
            this.listViewSmart.TabIndex = 0;
            this.listViewSmart.UseCompatibleStateImageBehavior = false;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.AllowDrop = true;
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStatus.Location = new System.Drawing.Point(9, 16);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(739, 185);
            this.textBoxStatus.TabIndex = 2;
            this.textBoxStatus.TextChanged += new System.EventHandler(this.textBoxStatus_TextChanged);
            // 
            // timer_1sec
            // 
            this.timer_1sec.Enabled = true;
            this.timer_1sec.Interval = 1000;
            this.timer_1sec.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_300MS
            // 
            this.timer_300MS.Enabled = true;
            this.timer_300MS.Interval = 300;
            this.timer_300MS.Tick += new System.EventHandler(this.timer_300mis_Tick);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.BackColor = System.Drawing.SystemColors.Window;
            this.btnClearOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOutput.Location = new System.Drawing.Point(631, 151);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(84, 38);
            this.btnClearOutput.TabIndex = 6;
            this.btnClearOutput.Text = "Clear ";
            this.btnClearOutput.UseVisualStyleBackColor = false;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearOutput);
            this.groupBox2.Controls.Add(this.textBoxStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 208);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDS P2L simulator v0.1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.testGroup.ResumeLayout(false);
            this.testGroup.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabSMART.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Timer timer_1sec;
        private System.Windows.Forms.Timer timer_300MS;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.TabPage tabSMART;
        private System.Windows.Forms.Button btn_clearSmart;
        private System.Windows.Forms.ListView listViewSmart;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.Button ddr_size_btn;
        private System.Windows.Forms.Button dev_cap_btn;
        private System.Windows.Forms.TextBox timeTxBox;
        private System.Windows.Forms.ComboBox testTypeBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button erase_cmd_btn;
        private System.Windows.Forms.Button read_cmd_btn;
        private System.Windows.Forms.Button write_cmd_btn;
        private System.Windows.Forms.ComboBox dramSizeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox devCapBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button testCmdBtn;
        private System.Windows.Forms.GroupBox testGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_ch;
        private System.Windows.Forms.CheckBox checkBx_rslt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox timeElapsedTxBox;
        private System.Windows.Forms.TextBox pageTxBox;
        private System.Windows.Forms.TextBox planeTxBox;
        private System.Windows.Forms.TextBox blkTxBox;
        private System.Windows.Forms.TextBox chTxBox;
        private System.Windows.Forms.Button initDevBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label pageNum;
        private System.Windows.Forms.Label planeNum;
        private System.Windows.Forms.Label chNum;
    }
}

