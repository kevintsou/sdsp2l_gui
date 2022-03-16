using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;

namespace gui
{
    public partial class Form1 : Form
    {
        private int i;
        int[] inBuffer = new int[512];

        private s_dev_config s_dev;
        public Form1()
        {
            InitializeComponent();

            s_dev = new s_dev_config();
            s_dev.ddr_size = 32;
            s_dev.dev_size = 128;

            vInitDevConfig(s_dev.dev_size, s_dev.ddr_size);

            devCapBox.SelectedIndex = 2;    // 128GB
            dramSizeList.SelectedIndex = 2; // 32MB

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

        }


        private void testTypeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void timer_300mis_Tick(object sender, EventArgs e)
        {
          
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
            s_dev.testMin = int.Parse(timeTxBox.Text);
            s_dev.hitCnt = 0;
            s_dev.hitRate = 0;
            s_dev.chkCnt = 0;

            textBoxStatus.AppendText("    Start test, script idx:" + Environment.NewLine);
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
    }
}
