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
        static extern int lp2lHitCnt();
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
        [DllImport("sdsp2l_algo.dll")]
        static extern IntPtr iGetEraseCntTable(int ch);
        [DllImport("sdsp2l_algo.dll")]
        static extern IntPtr iGetReadCntTable(int ch);
        [DllImport("sdsp2l_algo.dll")]
        static extern long iGetIoBurstCnt(int ch);
        [DllImport("sdsp2l_algo.dll")]
        static extern int iClearChkHitCnt();


        IntPtr bufPtr;
        Thread testThread;


        public void vInitDevConfig(int dev_size, int ddr_size)
        {
            //IntPtr ptr = Marshal.AllocHGlobal(0x06208400); // 128GB dev , full dram, max memory required
            if (bufPtr.ToInt32() == 0) {
                bufPtr = Marshal.AllocHGlobal(0x06300000*4);
            }

            s_dev.chCnt = int.Parse(chNum.Text.ToString());
            s_dev.pageCnt = int.Parse(pageNum.Text.ToString());
            s_dev.planeCnt = int.Parse(plnNum.Text.ToString());
            s_dev.blkCnt = ((s_dev.dev_size * 1024 * 1024) / 16) / (s_dev.chCnt * s_dev.pageCnt * s_dev.planeCnt);

            s_dev.chBitNum = (int)Math.Log(s_dev.chCnt, 2.0); 
            s_dev.blkBitNum = (int)Math.Log(s_dev.blkCnt, 2.0);
            s_dev.pageBitNum = (int)Math.Log(s_dev.pageCnt, 2.0);
            s_dev.planeBitNum = (int)Math.Log(s_dev.planeCnt, 2.0);

            s_dev.pageSftCnt = 0;
            s_dev.planeSftCnt = s_dev.pageSftCnt + s_dev.pageBitNum;
            s_dev.blkSftCnt = s_dev.planeSftCnt + s_dev.planeBitNum;
            s_dev.chSftCnt = s_dev.blkSftCnt + s_dev.blkBitNum;

            iInitDeviceConfig(dev_size, ddr_size, s_dev.chCnt, s_dev.planeCnt, s_dev.pageCnt, bufPtr);
            int cap = iGetDevCap();
            ddr_size = iGetDdrSize();
            textBoxStatus.AppendText("    Initailize device config, Dev Cap: " + cap.ToString() + "GB,    Dram: " + ddr_size.ToString() + "MB" + Environment.NewLine);

            // enduration evaluation variable
            s_test.chBurstCnt = new long[s_dev.chCnt];
            s_test.eraseCnt = new int[s_dev.chCnt * s_dev.blkCnt];
            s_test.readCnt = new int[s_dev.chCnt * s_dev.blkCnt];

        }

        public int iGetCh(int pAddr) {
            return ((pAddr >> s_dev.chSftCnt) & (s_dev.chCnt - 1));
        }

        public int iGetBlk(int pAddr)
        {
            return ((pAddr >> s_dev.blkSftCnt) & (s_dev.blkCnt - 1));
        }

        public int iGetPlane(int pAddr)
        {
            return ((pAddr >> s_dev.planeSftCnt) & (s_dev.planeCnt - 1));
        }

        public int iGetPage(int pAddr)
        {
            return ((pAddr >> s_dev.pageSftCnt) & (s_dev.pageCnt - 1));
        }


        public int iPrefillData() {
            IntPtr pPayload = Marshal.AllocHGlobal(4);
            s_test.progress = (int)e_cmd.E_CMD_WRITE;

            // prefill data
            for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
            {
                // stop test button press
                if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                {
                    break;
                }

                s_test.ch = iGetCh(i);
                s_test.blk = iGetBlk(i);
                s_test.plane = iGetPlane(i);
                s_test.page = iGetPage(i);

                iIssueFlashCmdEn((int)e_cmd.E_CMD_WRITE, i, pPayload);
            }

            Marshal.FreeHGlobal(pPayload);
            return 0;
        }


        // 0. Sequencial Rd (prefill)
        public int iScript_0() {

            IntPtr pPayload = Marshal.AllocHGlobal(4);
            int lbn = 0, dataLbn = 0, loop = 5000;

            iPrefillData();

            // seq read test
            s_test.progress = (int)e_cmd.E_CMD_SEQ_RD;
            while (loop != 0)
            {
                for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
                {

                    s_test.ch = iGetCh(i);
                    s_test.blk = iGetBlk(i);
                    s_test.plane = iGetPlane(i);
                    s_test.page = iGetPage(i);

                    // stop test button press
                    if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                    {
                        return 0;
                    }
                    lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, i, pPayload);
                    Marshal.Copy(pPayload, inBuffer, 0, 4);
                    dataLbn = inBuffer[0];

                    if (lbn != dataLbn)
                    {
                        s_test.testSts = (int)e_state.E_STS_STOPPED;
                        s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                        Marshal.FreeHGlobal(pPayload);
                        return 1;
                    }
                }
                loop--;
            }

            s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;     // script test result
            s_test.progress = (int)e_cmd.E_CMD_NONE;    // sript current progress
            s_test.testSts = (int)e_state.E_STS_STOPPED;   // test finished, wait for join

            Marshal.FreeHGlobal(pPayload);
            return 0;
        }

        // 1. Random Rd (prefill)
        public int iScript_1()
        {
            IntPtr pPayload = Marshal.AllocHGlobal(4);
            int lbn = 0, dataLbn = 0, loop = 5000;
            int idx = 0;

            iPrefillData();

            Random rnd = new Random(10);
            // seq read test
            s_test.progress = (int)e_cmd.E_CMD_RD_RD;
            while (loop != 0)
            {
                for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
                {
                    idx = rnd.Next() % ((s_dev.dev_size * 1024 * 1024) / 16);

                    s_test.ch = iGetCh(idx);
                    s_test.blk = iGetBlk(idx);
                    s_test.plane = iGetPlane(idx);
                    s_test.page = iGetPage(idx);

                    // stop test button press
                    if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                    {
                        return 0;
                    }
                    lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, idx, pPayload);
                    Marshal.Copy(pPayload, inBuffer, 0, 4);
                    dataLbn = inBuffer[0];

                    if (lbn != dataLbn)
                    {
                        s_test.testSts = (int)e_state.E_STS_STOPPED;
                        s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                        Marshal.FreeHGlobal(pPayload);
                        return 1;
                    }
                }
                loop--;
            }

            s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;     // script test result
            s_test.progress = (int)e_cmd.E_CMD_NONE;    // sript current progress
            s_test.testSts = (int)e_state.E_STS_STOPPED;   // test finished, wait for join

            Marshal.FreeHGlobal(pPayload);
            return 0;
        }

        // 2. Seq/Random Rd mixed(prefill)
        public int iScript_2()
        {
            IntPtr pPayload = Marshal.AllocHGlobal(4);
            int lbn = 0, dataLbn = 0, loop = 5000;
            int idx = 0;

            iPrefillData();

            Random rnd = new Random(10);

            while (loop != 0)
            {
                s_test.progress = (int)e_cmd.E_CMD_RD_RD;
                for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
                {
                    idx = rnd.Next() % ((s_dev.dev_size * 1024 * 1024) / 16);

                    s_test.ch = iGetCh(idx);
                    s_test.blk = iGetBlk(idx);
                    s_test.plane = iGetPlane(idx);
                    s_test.page = iGetPage(idx);

                    // stop test button press
                    if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                    {
                        return 0;
                    }
                    lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, idx, pPayload);
                    Marshal.Copy(pPayload, inBuffer, 0, 4);
                    dataLbn = inBuffer[0];

                    if (lbn != dataLbn)
                    {
                        s_test.testSts = (int)e_state.E_STS_STOPPED;
                        s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                        Marshal.FreeHGlobal(pPayload);
                        return 1;
                    }
                }
                s_test.progress = (int)e_cmd.E_CMD_SEQ_RD;
                for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
                {

                    s_test.ch = iGetCh(i);
                    s_test.blk = iGetBlk(i);
                    s_test.plane = iGetPlane(i);
                    s_test.page = iGetPage(i);

                    if (s_test.blk > 100) {
                        continue;                   
                    }

                    // stop test button press
                    if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                    {
                        return 0;
                    }
                    lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, i, pPayload);
                    Marshal.Copy(pPayload, inBuffer, 0, 4);
                    dataLbn = inBuffer[0];

                    if (lbn != dataLbn)
                    {
                        s_test.testSts = (int)e_state.E_STS_STOPPED;
                        s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                        Marshal.FreeHGlobal(pPayload);
                        return 1;
                    }
                }
                loop--;
            }

            s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;     // script test result
            s_test.progress = (int)e_cmd.E_CMD_NONE;    // sript current progress
            s_test.testSts = (int)e_state.E_STS_STOPPED;   // test finished, wait for join

            Marshal.FreeHGlobal(pPayload);
            return 0;
        }

        // 3. Rd/Wr/Erase mixed
        public int iScript_3()
        {
            IntPtr pPayload = Marshal.AllocHGlobal(4);
            int lbn = 0, dataLbn = 0, loop = 5000;

            while (loop != 0)
            {
                iPrefillData();

                s_test.progress = (int)e_cmd.E_CMD_SEQ_RD;
                for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
                {

                    s_test.ch = iGetCh(i);
                    s_test.blk = iGetBlk(i);
                    s_test.plane = iGetPlane(i);
                    s_test.page = iGetPage(i);

                    // stop test button press
                    if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                    {
                        return 0;
                    }
                    lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, i, pPayload);
                    Marshal.Copy(pPayload, inBuffer, 0, 4);
                    dataLbn = inBuffer[0];

                    if (lbn != dataLbn)
                    {
                        s_test.testSts = (int)e_state.E_STS_STOPPED;
                        s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                        Marshal.FreeHGlobal(pPayload);
                        return 1;
                    }
                }

                s_test.progress = (int)e_cmd.E_CMD_ERASE;
                for (int j = 0; j < s_dev.chCnt; j++)
                {
                    for (int i = 0; i < (s_dev.blkCnt); i++)
                    {
                        s_test.ch = j;
                        s_test.blk = i;
                        s_test.plane = 0;
                        s_test.page = 0;

                        // stop test button press
                        if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                        {
                            return 0;
                        }
                        lbn = iIssueFlashCmd((int)e_cmd.E_CMD_ERASE, j, i, 0, 0, pPayload);
                    }
                }

                s_test.progress = (int)e_cmd.E_CMD_SEQ_RD;
                for (int i = 0; i < ((s_dev.dev_size * 1024 * 1024) / 16); i++)
                {

                    s_test.ch = iGetCh(i);
                    s_test.blk = iGetBlk(i);
                    s_test.plane = iGetPlane(i);
                    s_test.page = iGetPage(i);

                    // stop test button press
                    if (s_test.testSts == (int)e_state.E_STS_STOPPED)
                    {
                        return 0;
                    }
                    lbn = iIssueFlashCmdEn((int)e_cmd.E_CMD_READ, i, pPayload);
                    Marshal.Copy(pPayload, inBuffer, 0, 4);
                    dataLbn = inBuffer[0];

                    if (lbn != dataLbn)
                    {
                        s_test.testSts = (int)e_state.E_STS_STOPPED;
                        s_test.testRslt = (int)e_test_rslt.E_RSLT_MISCMPARE;
                        Marshal.FreeHGlobal(pPayload);
                        return 1;
                    }
                }

                loop--;
            }

            s_test.testRslt = (int)e_test_rslt.E_RSLT_PASS;     // script test result
            s_test.progress = (int)e_cmd.E_CMD_NONE;    // sript current progress
            s_test.testSts = (int)e_state.E_STS_STOPPED;   // test finished, wait for join

            Marshal.FreeHGlobal(pPayload);
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
