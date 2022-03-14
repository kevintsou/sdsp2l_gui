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

        public Form1()
        {

            InitializeComponent();
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

        // 限制只能輸入數字
        private void testLoop_keypress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void powerOfint_keypress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void powerOff_keypress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void trackBar_writeSize_Scroll(object sender, EventArgs e)
        {

        }

        private void testTypeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void workload_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startTestBtn_Click(object sender, EventArgs e)
        {

        }


        private void timer_300mis_Tick(object sender, EventArgs e)
        {
          
        }

        private void textBox_powerOffTime_TextChanged(object sender, EventArgs e)
        {
            if (textBox_powerOffTime.Text != "")
            {
            }
        }

        private void tabSMART_Enter(object sender, EventArgs e)
        {
        }

        private void tabSMART_Click(object sender, EventArgs e)
        {

        }


        private void textBoxSEL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & ((int)e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBoxDW11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & 
                ((int)e.KeyChar < 65 | (int)e.KeyChar > 70) & 
                ((int)e.KeyChar < 97 | (int)e.KeyChar > 102) & 
                ((int)e.KeyChar != 8) & ((int)e.KeyChar != 120))
            {
                e.Handled = true;
            }
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            textBoxStatus.Clear();
        }

        private void textBox_powerOnTime_TextChanged(object sender, EventArgs e)
        {
            if (textBox_powerOnTime.Text != "")
            {
            }
        }

        private void textBox_rebuildTimeout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox_rebuildTimeout_TextChanged(object sender, EventArgs e)
        {
            if (textBox_rebuildTimeout.Text != "")
            {
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            startTestBtn.Text = "START";
            startTestBtn.Image = Properties.Resources.power_64;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            startTestBtn.Text = "STOP";
            startTestBtn.Image = Properties.Resources.power_off_64;
        }

        private void powerCycleTab_Click(object sender, EventArgs e)
        {

        }
    }
}
