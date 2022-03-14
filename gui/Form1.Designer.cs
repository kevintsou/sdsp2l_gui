
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
            this.erase_cmd_btn = new System.Windows.Forms.Button();
            this.read_cmd_btn = new System.Windows.Forms.Button();
            this.write_cmd_btn = new System.Windows.Forms.Button();
            this.ddr_size_btn = new System.Windows.Forms.Button();
            this.dev_cap_btn = new System.Windows.Forms.Button();
            this.textBox_rebuildTimeout = new System.Windows.Forms.TextBox();
            this.textbox_qdepth = new System.Windows.Forms.TextBox();
            this.textBox_writeSize = new System.Windows.Forms.TextBox();
            this.textBox_powerOnTime = new System.Windows.Forms.TextBox();
            this.textBox_powerOffTime = new System.Windows.Forms.TextBox();
            this.textbox_testloop = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.queue_depth = new System.Windows.Forms.Label();
            this.workload_combobox = new System.Windows.Forms.ComboBox();
            this.testTypeBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_writeSize = new System.Windows.Forms.TrackBar();
            this.tabSMART = new System.Windows.Forms.TabPage();
            this.btn_clearSmart = new System.Windows.Forms.Button();
            this.listViewSmart = new System.Windows.Forms.ListView();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_1sec = new System.Windows.Forms.Timer(this.components);
            this.timer_300MS = new System.Windows.Forms.Timer(this.components);
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.mainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_writeSize)).BeginInit();
            this.tabSMART.SuspendLayout();
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
            this.tabControl.Size = new System.Drawing.Size(860, 420);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.erase_cmd_btn);
            this.mainTab.Controls.Add(this.read_cmd_btn);
            this.mainTab.Controls.Add(this.write_cmd_btn);
            this.mainTab.Controls.Add(this.ddr_size_btn);
            this.mainTab.Controls.Add(this.dev_cap_btn);
            this.mainTab.Controls.Add(this.textBox_rebuildTimeout);
            this.mainTab.Controls.Add(this.textbox_qdepth);
            this.mainTab.Controls.Add(this.textBox_writeSize);
            this.mainTab.Controls.Add(this.textBox_powerOnTime);
            this.mainTab.Controls.Add(this.textBox_powerOffTime);
            this.mainTab.Controls.Add(this.textbox_testloop);
            this.mainTab.Controls.Add(this.label14);
            this.mainTab.Controls.Add(this.queue_depth);
            this.mainTab.Controls.Add(this.workload_combobox);
            this.mainTab.Controls.Add(this.testTypeBox1);
            this.mainTab.Controls.Add(this.label9);
            this.mainTab.Controls.Add(this.label8);
            this.mainTab.Controls.Add(this.label7);
            this.mainTab.Controls.Add(this.label5);
            this.mainTab.Controls.Add(this.label4);
            this.mainTab.Controls.Add(this.label3);
            this.mainTab.Controls.Add(this.trackBar_writeSize);
            this.mainTab.Location = new System.Drawing.Point(4, 34);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(852, 382);
            this.mainTab.TabIndex = 1;
            this.mainTab.Text = "Power Cycle";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // erase_cmd_btn
            // 
            this.erase_cmd_btn.Location = new System.Drawing.Point(735, 131);
            this.erase_cmd_btn.Name = "erase_cmd_btn";
            this.erase_cmd_btn.Size = new System.Drawing.Size(95, 23);
            this.erase_cmd_btn.TabIndex = 31;
            this.erase_cmd_btn.Text = "EraseCmd";
            this.erase_cmd_btn.UseVisualStyleBackColor = true;
            // 
            // read_cmd_btn
            // 
            this.read_cmd_btn.Location = new System.Drawing.Point(735, 102);
            this.read_cmd_btn.Name = "read_cmd_btn";
            this.read_cmd_btn.Size = new System.Drawing.Size(95, 23);
            this.read_cmd_btn.TabIndex = 30;
            this.read_cmd_btn.Text = "ReadCmd";
            this.read_cmd_btn.UseVisualStyleBackColor = true;
            this.read_cmd_btn.Click += new System.EventHandler(this.read_cmd_btn_Click);
            // 
            // write_cmd_btn
            // 
            this.write_cmd_btn.Location = new System.Drawing.Point(735, 73);
            this.write_cmd_btn.Name = "write_cmd_btn";
            this.write_cmd_btn.Size = new System.Drawing.Size(95, 23);
            this.write_cmd_btn.TabIndex = 29;
            this.write_cmd_btn.Text = "WriteCmd";
            this.write_cmd_btn.UseVisualStyleBackColor = true;
            this.write_cmd_btn.Click += new System.EventHandler(this.write_cmd_btn_Click);
            // 
            // ddr_size_btn
            // 
            this.ddr_size_btn.Location = new System.Drawing.Point(735, 44);
            this.ddr_size_btn.Name = "ddr_size_btn";
            this.ddr_size_btn.Size = new System.Drawing.Size(95, 23);
            this.ddr_size_btn.TabIndex = 28;
            this.ddr_size_btn.Text = "GetDdrSize";
            this.ddr_size_btn.UseVisualStyleBackColor = true;
            this.ddr_size_btn.Click += new System.EventHandler(this.ddr_size_btn_Click);
            // 
            // dev_cap_btn
            // 
            this.dev_cap_btn.Location = new System.Drawing.Point(735, 15);
            this.dev_cap_btn.Name = "dev_cap_btn";
            this.dev_cap_btn.Size = new System.Drawing.Size(95, 23);
            this.dev_cap_btn.TabIndex = 27;
            this.dev_cap_btn.Text = "GetDevCap";
            this.dev_cap_btn.UseVisualStyleBackColor = true;
            this.dev_cap_btn.Click += new System.EventHandler(this.dev_cap_btn_Click);
            // 
            // textBox_rebuildTimeout
            // 
            this.textBox_rebuildTimeout.Location = new System.Drawing.Point(157, 166);
            this.textBox_rebuildTimeout.Name = "textBox_rebuildTimeout";
            this.textBox_rebuildTimeout.Size = new System.Drawing.Size(77, 23);
            this.textBox_rebuildTimeout.TabIndex = 23;
            this.textBox_rebuildTimeout.Text = "30";
            this.textBox_rebuildTimeout.TextChanged += new System.EventHandler(this.textBox_rebuildTimeout_TextChanged);
            this.textBox_rebuildTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_rebuildTimeout_KeyPress);
            // 
            // textbox_qdepth
            // 
            this.textbox_qdepth.Enabled = false;
            this.textbox_qdepth.Location = new System.Drawing.Point(101, 204);
            this.textbox_qdepth.MaxLength = 20;
            this.textbox_qdepth.Name = "textbox_qdepth";
            this.textbox_qdepth.Size = new System.Drawing.Size(74, 23);
            this.textbox_qdepth.TabIndex = 21;
            this.textbox_qdepth.Text = "64";
            // 
            // textBox_writeSize
            // 
            this.textBox_writeSize.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_writeSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_writeSize.Enabled = false;
            this.textBox_writeSize.Location = new System.Drawing.Point(169, 309);
            this.textBox_writeSize.MaxLength = 20;
            this.textBox_writeSize.Name = "textBox_writeSize";
            this.textBox_writeSize.Size = new System.Drawing.Size(65, 16);
            this.textBox_writeSize.TabIndex = 16;
            this.textBox_writeSize.Text = "512Byte";
            this.textBox_writeSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_powerOnTime
            // 
            this.textBox_powerOnTime.Location = new System.Drawing.Point(169, 126);
            this.textBox_powerOnTime.Name = "textBox_powerOnTime";
            this.textBox_powerOnTime.Size = new System.Drawing.Size(77, 23);
            this.textBox_powerOnTime.TabIndex = 13;
            this.textBox_powerOnTime.Text = "10";
            this.textBox_powerOnTime.TextChanged += new System.EventHandler(this.textBox_powerOnTime_TextChanged);
            this.textBox_powerOnTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.powerOff_keypress);
            // 
            // textBox_powerOffTime
            // 
            this.textBox_powerOffTime.Location = new System.Drawing.Point(191, 88);
            this.textBox_powerOffTime.Name = "textBox_powerOffTime";
            this.textBox_powerOffTime.Size = new System.Drawing.Size(77, 23);
            this.textBox_powerOffTime.TabIndex = 12;
            this.textBox_powerOffTime.Text = "10";
            this.textBox_powerOffTime.TextChanged += new System.EventHandler(this.textBox_powerOffTime_TextChanged);
            this.textBox_powerOffTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.powerOfint_keypress);
            // 
            // textbox_testloop
            // 
            this.textbox_testloop.Location = new System.Drawing.Point(66, 53);
            this.textbox_testloop.Margin = new System.Windows.Forms.Padding(50);
            this.textbox_testloop.MaxLength = 20;
            this.textbox_testloop.Name = "textbox_testloop";
            this.textbox_testloop.Size = new System.Drawing.Size(74, 23);
            this.textbox_testloop.TabIndex = 11;
            this.textbox_testloop.Text = "1024";
            this.textbox_testloop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.testLoop_keypress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 15);
            this.label14.TabIndex = 22;
            this.label14.Text = "Rebuild Timeout (sec):";
            // 
            // queue_depth
            // 
            this.queue_depth.AutoSize = true;
            this.queue_depth.Enabled = false;
            this.queue_depth.Location = new System.Drawing.Point(19, 207);
            this.queue_depth.Name = "queue_depth";
            this.queue_depth.Size = new System.Drawing.Size(55, 15);
            this.queue_depth.TabIndex = 20;
            this.queue_depth.Text = "QDepth:";
            // 
            // workload_combobox
            // 
            this.workload_combobox.Enabled = false;
            this.workload_combobox.FormattingEnabled = true;
            this.workload_combobox.Location = new System.Drawing.Point(101, 241);
            this.workload_combobox.Name = "workload_combobox";
            this.workload_combobox.Size = new System.Drawing.Size(129, 23);
            this.workload_combobox.TabIndex = 17;
            this.workload_combobox.SelectedIndexChanged += new System.EventHandler(this.workload_combobox_SelectedIndexChanged);
            // 
            // testTypeBox1
            // 
            this.testTypeBox1.FormattingEnabled = true;
            this.testTypeBox1.Location = new System.Drawing.Point(66, 15);
            this.testTypeBox1.Name = "testTypeBox1";
            this.testTypeBox1.Size = new System.Drawing.Size(638, 23);
            this.testTypeBox1.TabIndex = 6;
            this.testTypeBox1.SelectedIndexChanged += new System.EventHandler(this.testTypeBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Power off idle time (sec):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time to remove power (sec):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Script:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(19, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Workload:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Loops:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(19, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Write Size:";
            // 
            // trackBar_writeSize
            // 
            this.trackBar_writeSize.Enabled = false;
            this.trackBar_writeSize.Location = new System.Drawing.Point(101, 280);
            this.trackBar_writeSize.Maximum = 6;
            this.trackBar_writeSize.Name = "trackBar_writeSize";
            this.trackBar_writeSize.Size = new System.Drawing.Size(209, 45);
            this.trackBar_writeSize.TabIndex = 0;
            this.trackBar_writeSize.Value = 6;
            this.trackBar_writeSize.Scroll += new System.EventHandler(this.trackBar_writeSize_Scroll);
            // 
            // tabSMART
            // 
            this.tabSMART.Controls.Add(this.btn_clearSmart);
            this.tabSMART.Controls.Add(this.listViewSmart);
            this.tabSMART.Location = new System.Drawing.Point(4, 34);
            this.tabSMART.Name = "tabSMART";
            this.tabSMART.Padding = new System.Windows.Forms.Padding(3);
            this.tabSMART.Size = new System.Drawing.Size(852, 382);
            this.tabSMART.TabIndex = 2;
            this.tabSMART.Text = "Smart Info";
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
            this.textBoxStatus.Location = new System.Drawing.Point(12, 458);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(860, 241);
            this.textBoxStatus.TabIndex = 2;
            this.textBoxStatus.TextChanged += new System.EventHandler(this.textBoxStatus_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(12, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output";
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
            this.btnClearOutput.Location = new System.Drawing.Point(751, 661);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(95, 23);
            this.btnClearOutput.TabIndex = 6;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = false;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 711);
            this.Controls.Add(this.btnClearOutput);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStatus);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDS P2L simulator v0.1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_writeSize)).EndInit();
            this.tabSMART.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_1sec;
        private System.Windows.Forms.Timer timer_300MS;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.TabPage tabSMART;
        private System.Windows.Forms.Button btn_clearSmart;
        private System.Windows.Forms.ListView listViewSmart;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.Button ddr_size_btn;
        private System.Windows.Forms.Button dev_cap_btn;
        private System.Windows.Forms.TextBox textBox_rebuildTimeout;
        private System.Windows.Forms.TextBox textbox_qdepth;
        private System.Windows.Forms.TextBox textBox_writeSize;
        private System.Windows.Forms.TextBox textBox_powerOnTime;
        private System.Windows.Forms.TextBox textBox_powerOffTime;
        private System.Windows.Forms.TextBox textbox_testloop;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label queue_depth;
        private System.Windows.Forms.ComboBox workload_combobox;
        private System.Windows.Forms.ComboBox testTypeBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_writeSize;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button erase_cmd_btn;
        private System.Windows.Forms.Button read_cmd_btn;
        private System.Windows.Forms.Button write_cmd_btn;
    }
}

