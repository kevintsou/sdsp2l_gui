﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace gui
{
    public partial class Form1 : Form
    {
        private int i;
        int[] inBuffer = new int[512];

        private static s_dev_config s_dev;
        private static s_sript_mgr s_test;
        public Form1()
        {
            InitializeComponent();

            s_dev = new s_dev_config();
            s_dev.ddr_size = 32;
            s_dev.dev_size = 128;

            s_test = new s_sript_mgr();


            //vInitDevConfig(s_dev.dev_size, s_dev.ddr_size);

            devCapBox.SelectedIndex = 2;    // 128GB
            dramSizeList.SelectedIndex = 2; // 32MB

            testTypeBox1.SelectedIndex = 0;

            testCmdBtn.Text = "Start test";

        }

        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBoxStatus.AppendText(DateTime.Now + " : tabControl1_SelectedIndexChanged" + Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Timer 1 sec callback
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s_test.testSts == (int)e_state.E_STS_RUNNING)
            {
                // update test status
                switch (s_test.progress)
                {
                    case (int)e_cmd.E_CMD_SEQ_RD:
                        testStsBx.Text = "Seq Read Chk..";
                        break;
                    case (int)e_cmd.E_CMD_RD_RD:
                        testStsBx.Text = "Random Read Chk..";
                        break;
                    case (int)e_cmd.E_CMD_WRITE:
                        testStsBx.Text = "Writing data..";
                        break;
                    case (int)e_cmd.E_CMD_ERASE:
                        testStsBx.Text = "Erasing data..";
                        break;
                    case (int)e_cmd.E_CMD_NONE:
                        testStsBx.Text = "Idle..";
                        break;
                    default:
                        break;
                }

                TimeSpan time = TimeSpan.FromSeconds(s_test.elapsedTime);
                s_test.elapsedTime++;

                //here backslash is must to tell that colon is
                //not the part of format, it just a character that we want in output
                string str = time.ToString(@"hh\:mm\:ss");
                timeElapsedTxBox.Text = str;

                if (s_test.elapsedTime == s_test.testTime)
                {
                    s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;     // script test result
                    s_test.testSts = (int)e_state.E_STS_STOPPED;
                    testThread.Join();
                    vStopTestHandler();
                }
            }
            else if (s_test.testSts == (int)e_state.E_STS_STOPPED) {
                testThread.Join();
                vStopTestHandler();
            }
            else if (s_test.testSts == (int)e_state.E_STS_IDLE)
            {
                testStsBx.Text = " ";   // clear test state
            }
        }

        private void vListViewHandle() {

            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
            listView1.Clear();

            listView1.Columns.Add("CH", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("IO Burst Cnt", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Read Cnt", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Write Cnt", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Erase Cnt", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Chk Cnt", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Hit Cnt", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Hit Rate", 80, HorizontalAlignment.Center);

            for (int i = 0; i < s_dev.chCnt; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.Text = i.ToString();
                item.SubItems.Add(s_test.chBurstCnt[i].ToString());

                if (i == 0)
                {
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(s_test.bitChkCnt.ToString());
                    item.SubItems.Add(s_test.bitHitCnt.ToString());
                    item.SubItems.Add(s_test.hitRate.ToString());
                }

                listView1.Items.Add(item);
            }
        }

        private void vStopTestHandler() {
            string str;

            switch (s_test.testRslt) { 
                case (int)e_test_rslt.E_RSLT_PASS:
                    str = new string("PASS TEST");

                    // show the test result in the next sheet
                    s_test.bitChkCnt = lpl2ChkCnt();
                    s_test.bitHitCnt = lp2lHitCnt();
                    s_test.hitRate = (float) s_test.bitHitCnt / s_test.bitChkCnt;

                    for (int i = 0; i < s_dev.chCnt; i++)
                    {
                        s_test.chBurstCnt[i] = iGetIoBurstCnt(i);
                    }

                    vListViewHandle();
                    // TBD , read count table, erase count table
                    tabControl.SelectedTab = tabControl.TabPages[1];       // switch to result page
                    break;
                case (int)e_test_rslt.E_RSLT_MISCMPARE:
                    str = new string("DATA MISCOMPARE");
                    chTxBox.Text = s_test.ch.ToString();
                    blkTxBox.Text = s_test.blk.ToString();
                    planeTxBox.Text = s_test.plane.ToString();
                    pageTxBox.Text = s_test.page.ToString();
                    break;
                case (int)e_test_rslt.E_RSLT_TERMINATED:
                    str = new string("TEST TERMINATED");
                    break;
                default:
                    str = new string("");
                    break;
            }


            // end, set the state to idle
            s_test.ch = 0;
            s_test.blk = 0;
            s_test.plane = 0;
            s_test.page = 0;
            s_test.elapsedTime = 0;
            s_test.testSts = (int)e_state.E_STS_IDLE;

            testCmdBtn.Text = "Start test";
            textBoxStatus.AppendText("    Stop test, script: " + s_test.typeName + ", time(min): " + (s_test.testTime/60) + ", " + str + Environment.NewLine);
        }


        private void testTypeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void timer_300mis_Tick(object sender, EventArgs e)
        {
            if (s_test.testSts == (int)e_state.E_STS_RUNNING) {
                chTxBox.Text = s_test.ch.ToString();
                blkTxBox.Text = s_test.blk.ToString();
                planeTxBox.Text = s_test.plane.ToString();
                pageTxBox.Text = s_test.page.ToString();
            }
        }

        private void timeTxBox_TextChanged(object sender, EventArgs e)
        {
            if (timeTxBox.Text != "")
            {

            }
        }

        private void tabSMART_Enter(object sender, EventArgs e)
        {
        }

        private void tabSMART_Click(object sender, EventArgs e)
        {

        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            textBoxStatus.Clear();
        }

        private void dev_cap_btn_Click(object sender, EventArgs e)
        {
            int cap = iGetDevCap();
            textBoxStatus.AppendText("    Device Capacity: " + cap.ToString() + "GB" + Environment.NewLine);
        }

        private void ddr_size_btn_Click(object sender, EventArgs e)
        {
            int ddr_size = iGetDdrSize();
            textBoxStatus.AppendText("    Dram Size: " + ddr_size.ToString() + "MB" + Environment.NewLine);
        }

        private void read_cmd_btn_Click(object sender, EventArgs e)
        {
            int ch = int.Parse(chTxBox.Text);
            int blk = int.Parse(blkTxBox.Text);
            int plane = int.Parse(planeTxBox.Text);
            int page = int.Parse(pageTxBox.Text);

            // error
            if (ch >= 8)
            {
                textBoxStatus.AppendText("    [Err] Channel index error !!" + Environment.NewLine);
                return;
            }

            IntPtr pPayload = Marshal.AllocHGlobal(4);
            // issue flash cmd to backend
            int lbn = iIssueFlashCmd((int)e_cmd.E_CMD_READ, ch, blk, plane, page, pPayload);
            //int lbn = iFlashCmdHandler((int)e_cmd.E_CMD_READ, ch, blk, plane, page, pPayload);
            int dataLbn  = 0;
            Marshal.Copy(pPayload, inBuffer, 0, 4);
            dataLbn = inBuffer[0];

            textBoxStatus.AppendText("    Issue read cmd: ch: " + ch + ", blk: " + blk + ", plane: " + plane + ", page: " + page + Environment.NewLine);
            textBoxStatus.AppendText("    Read cmd done, lbn: 0x" + lbn.ToString("X4") + " , data lbn: 0x" + dataLbn.ToString("X4") + Environment.NewLine);

            Marshal.FreeHGlobal(pPayload);
        }

        private void write_cmd_btn_Click(object sender, EventArgs e)
        {
            int ch = int.Parse(chTxBox.Text);
            int blk = int.Parse(blkTxBox.Text);
            int plane = int.Parse(planeTxBox.Text);
            int page = int.Parse(pageTxBox.Text);

            // error
            if (ch >= 8) {
                textBoxStatus.AppendText("    [Err] Channel index error !!" + Environment.NewLine);
                return;
            }

            IntPtr pPayload = Marshal.AllocHGlobal(4);
            // issue flash cmd to backend
            int lbn = iIssueFlashCmd((int)e_cmd.E_CMD_WRITE, ch, blk, plane, page, pPayload);
            //int lbn = iFlashCmdHandler((int)e_cmd.E_CMD_WRITE, ch, blk, plane, page, pPayload);
            Marshal.FreeHGlobal(pPayload);

            textBoxStatus.AppendText("    Issue write cmd: ch: " + ch + ", blk: " + blk + ", plane: " + plane + ", page: " + page + Environment.NewLine);
            textBoxStatus.AppendText("    Write cmd done, lbn: 0x" + lbn.ToString("X4") + Environment.NewLine);
        }

        private void checkBx_rslt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void devCapBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (devCapBox.SelectedIndex) { 
                case 0:
                    s_dev.dev_size = 32;
                    break;
                case 1:
                    s_dev.dev_size = 64;
                    break;
                case 2:
                    s_dev.dev_size = 128;
                    break;
                case 3:
                    s_dev.dev_size = 256;
                    break;
                default:
                    break;
            }
            vInitDevConfig(s_dev.dev_size, s_dev.ddr_size);
        }

        private void dramSizeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (dramSizeList.SelectedIndex)
            {
                case 0:
                    s_dev.ddr_size = 8;
                    break;
                case 1:
                    s_dev.ddr_size = 16;
                    break;
                case 2:
                    s_dev.ddr_size = 32;
                    break;
                case 3:
                    s_dev.ddr_size = 64;
                    break;
                default:
                    break;
            }
            vInitDevConfig(s_dev.dev_size, s_dev.ddr_size);
        }

        private void chTxBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void chTxBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void testCmdBtn_Click(object sender, EventArgs e)
        {
            if (s_test.testSts == (int)e_state.E_STS_RUNNING)
            {
                s_test.testSts = (int)e_state.E_STS_STOPPED;
                s_test.testRslt = (int)e_test_rslt.E_RSLT_TERMINATED;
            }
            else
            {
                s_test.testTime = int.Parse((string)timeTxBox.Text) * 60; // sec
                s_test.testType = testTypeBox1.SelectedIndex;
                s_test.outputRslt = (int)checkBx_rslt.CheckState;
                s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;
                s_test.testSts = (int)e_state.E_STS_RUNNING;
                
                iClearChkHitCnt();

                switch (s_test.testType)
                {
                    case 0:
                        s_test.typeName = new string("0. Sequencial Rd(prefill)");
                        break;
                    case 1:
                        s_test.typeName = new string("1. Random Rd (prefill)");
                        break;
                    case 2:
                        s_test.typeName = new string("2. Seq/Random Rd mixed (prefill)");
                        break;
                    case 3:
                        s_test.typeName = new string("3. Rd/Wr/Erase mixed");
                        break;
                    default:

                        break;
                }

                testCmdBtn.Text = "Stop test";
                textBoxStatus.AppendText("    Start test, script: " + s_test.typeName + ", time(min): " + (s_test.testTime / 60) + Environment.NewLine);
                
                testThread = new Thread(iStartTestFunc);
                testThread.Start();
            }
        }

        private void initDevBtn_Click(object sender, EventArgs e)
        {
            vInitDevConfig(s_dev.dev_size, s_dev.ddr_size);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void erase_cmd_btn_Click(object sender, EventArgs e)
        {
            int ch = int.Parse(chTxBox.Text);
            int blk = int.Parse(blkTxBox.Text);
            int plane = int.Parse(planeTxBox.Text);
            int page = int.Parse(pageTxBox.Text);

            // error
            if (ch >= 8)
            {
                textBoxStatus.AppendText("    [Err] Channel index error !!" + Environment.NewLine);
                return;
            }

            IntPtr pPayload = Marshal.AllocHGlobal(4);
            // issue flash cmd to backend
            int lbn = iIssueFlashCmd((int)e_cmd.E_CMD_ERASE, ch, blk, plane, page, pPayload);
            //int lbn = iFlashCmdHandler((int)e_cmd.E_CMD_WRITE, ch, blk, plane, page, pPayload);
            Marshal.FreeHGlobal(pPayload);

            textBoxStatus.AppendText("    Issue erase cmd: ch: " + ch + ", blk: " + blk + ", plane: " + plane + Environment.NewLine);
            textBoxStatus.AppendText("    Erase cmd done, lbn: 0x" + lbn.ToString("X4") + Environment.NewLine);
        }

        private void tblSizeBtn_Click(object sender, EventArgs e)
        {
            int tblSize = iGetTableSize();
            tblSize = (tblSize / 1024) / 1024;
            textBoxStatus.AppendText("    Total table size (MB): " + tblSize.ToString() + Environment.NewLine);
        }

        private void pageNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;

            listView1.Columns.Add("CH", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("IO Burst Cnt", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Read Cnt", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Write Cnt", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Erase Cnt", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Cht Cnt", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Hit Rate", 100, HorizontalAlignment.Center);
            
            for (int i = 0; i < s_dev.chCnt; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.Text = i.ToString();
                item.SubItems.Add(i.ToString());

                if (i == 0) {
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(i.ToString());
                }

                listView1.Items.Add(item);
            }
        }


    }
}
