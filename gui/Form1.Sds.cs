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
    partial class Form1
    {
        [DllImport("sdsp2l_algo.dll")]
        static extern long lp2lHitCnt();
        [DllImport("sdsp2l_algo.dll")]
        static extern long lpl2ChkCnt();
        [DllImport("sdsp2l_algo.dll")]
        static extern int iGetDevCap();
        [DllImport("sdsp2l_algo.dll")]
        static extern int iGetDdrSize();
        [DllImport("sdsp2l_algo.dll")]
        static extern int iGetTableSize();
        [DllImport("sdsp2l_algo.dll")]
        static extern int iIssueFlashCmd(int cmd, int ch, int blk, int plane, int page, IntPtr pPayload);
        [DllImport("sdsp2l_algo.dll")]
        static extern int iIssueFlashCmdEn(int cmd, int pAddr, IntPtr pPayload);
        [DllImport("sdsp2l_algo.dll")]
        static extern int iInitDeviceConfig(int devCap, int ddrSize, int chCnt, int planeCnt, int pageCnt, IntPtr bufPtr);

        IntPtr bufPtr;
        Thread testThread;


        public void vInitDevConfig(int dev_size, int ddr_size)
        {
            //IntPtr ptr = Marshal.AllocHGlobal(0x06208400); // 128GB dev , full dram, max memory required
            if (bufPtr.ToInt32() == 0) {
                bufPtr = Marshal.AllocHGlobal(0x06300000*2);
            }
            
            iInitDeviceConfig(dev_size, ddr_size, int.Parse(chNum.Text.ToString()), int.Parse(plnNum.Text.ToString()), int.Parse(pageNum.Text.ToString()), bufPtr);
            int cap = iGetDevCap();
            ddr_size = iGetDdrSize();
            textBoxStatus.AppendText("    Initailize device config, Dev Cap: " + cap.ToString() + "GB,    Dram: " + ddr_size.ToString() + "MB" + Environment.NewLine);
        }

        public int vCalculateHitRatio() {
            long chkCnt = lpl2ChkCnt();
            long hitCnt = lp2lHitCnt();
            int hitRatio = (int)(hitCnt / chkCnt);

            return hitRatio;
        }

        // 0. Random Rd (prefill)
        public int iScript_0() {

            IntPtr pPayload = Marshal.AllocHGlobal(4);
            s_test.progress = (int)e_cmd.E_CMD_WRITE;
            int lbn = 0, dataLbn = 0;

            // prefill data
            for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
            {
                // stop test button press
                if (s_test.testSts == (int)e_state.E_STS_STOPPED) {
                    break;
                }
                iIssueFlashCmdEn((int)e_cmd.E_CMD_WRITE, i, pPayload);
            }
       
            s_test.progress = (int)e_cmd.E_CMD_READ;
            for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
            {
                // stop test button press
                if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                {
                    break;
                }
                lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, i, pPayload);
                Marshal.Copy(pPayload, inBuffer, 0, 4);
                dataLbn = inBuffer[0];

                if (lbn != dataLbn) {
                    s_test.testSts = (int)e_state.E_STS_STOPPED;
                    s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                    Marshal.FreeHGlobal(pPayload);
                    vStopTestHandler();
                    return 1;
                }
            }

            s_test.progress = (int)e_cmd.E_CMD_NONE;
            s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;
            
            vStopTestHandler();
            
            Marshal.FreeHGlobal(pPayload);
            return 0;
        }

        // 1. Sequencial Rd (prefill)
        public int iScript_1()
        {

            return 0;
        }

        // 2. Seq/Random Rd mixed(prefill)
        public int iScript_2()
        {

            return 0;
        }

        // 3. Rd/Wr/Erase mixed
        public int iScript_3()
        {

            return 0;
        }

        private void iStartTestFunc() {
            switch (s_test.testType)
            {
                case 0:
                    iScript_0();
                    break;
                case 1:
                    iScript_1();
                    break;
                case 2:
                    iScript_2();
                    break;
                case 3:
                    iScript_3();
                    break;
                default:

                    break;
            }
        }

    }
}
