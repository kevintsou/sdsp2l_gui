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
        static extern int iIssueFlashCmd(int cmd, int ch, int blk, int plane, int page, IntPtr pPayload);
        [DllImport("sdsp2l_algo.dll")]
        static extern int iInitDeviceConfig(int devCap, int ddrSize, int chCnt, int planeCnt, int pageCnt, IntPtr bufPtr);


        [DllImport("nvmeio.dll")]
        static extern int iGetNVMeDevIdentifyData(int idx, IntPtr ptr);

        IntPtr bufPtr;

        public void GetDeviceIdentifyData(int idx)
        {
            bufPtr = Marshal.AllocHGlobal(4096);
            int result = iGetNVMeDevIdentifyData(idx, bufPtr);
            //idContData = (sIdentifyControllerData)Marshal.PtrToStructure(ptr, typeof(sIdentifyControllerData));
        }

        public void vInitDevConfig(int dev_size, int ddr_size)
        {
            //IntPtr ptr = Marshal.AllocHGlobal(0x06208400); // 128GB dev , full dram, max memory required
            if (bufPtr.ToInt32() == 0) {
                bufPtr = Marshal.AllocHGlobal(0x06300000);
            }
            
            iInitDeviceConfig(dev_size, ddr_size, int.Parse(chNum.Text.ToString()), int.Parse(plnNum.Text.ToString()), int.Parse(pageNum.Text.ToString()), bufPtr);
            int cap = iGetDevCap();
            ddr_size = iGetDdrSize();
            textBoxStatus.AppendText("    Dev Cap: " + cap.ToString() + "GB,    Dram: " + ddr_size.ToString() + "MB" + Environment.NewLine);
        }

        public void vIssueFlashCmd(int cmd, int ch, int blk, int plane, int page, IntPtr ptr) {
            int lbn = iIssueFlashCmd(cmd, ch, blk, plane, page, ptr);
        }

        public int vCalculateHitRatio() {
            long chkCnt = lpl2ChkCnt();
            long hitCnt = lp2lHitCnt();
            int hitRatio = (int)(hitCnt / chkCnt);

            return hitRatio;
        }

    }
}
