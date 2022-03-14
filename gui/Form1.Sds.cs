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
        

        // NVMe relative import
        [DllImport("sdsp2l_algo.dll")]
        static extern long lp2lHitCnt();
        [DllImport("sdsp2l_algo.dll")]
        static extern long lpl2ChkCnt();
        [DllImport("sdsp2l_algo.dll")]
        static extern int iIssueFlashCmd(int cmd, int pAddr, IntPtr pPayload);
        [DllImport("sdsp2l_algo.dll")]
        static extern int iInitDeviceConfig(int dev_size, int ddr_size);

        [DllImport("nvmeio.dll")]
        static extern int iGetNVMeDevIdentifyData(int idx, IntPtr ptr);
        [DllImport("nvmeio.dll")]
        static extern int iNVMeWrite(int idx, int lba, int sectorCount, IntPtr databuffer);
        [DllImport("nvmeio.dll")]
        static extern int iNVMeRead(int idx, int lba, int sectorCount, IntPtr databuffer);
        [DllImport("nvmeio.dll")]
        static extern int iRescanDevice();



        static private int iAvailDevCnt;    // total device count
        static private int iCurrentDevIdx;  // nvme device index
        static private string[] sDevName;   // nvme device name


        sIdentifyControllerData idContData;

        public void GetDeviceIdentifyData(int idx)
        {
            IntPtr ptr = Marshal.AllocHGlobal(4096);
            int result = iGetNVMeDevIdentifyData(idx, ptr);
            idContData = (sIdentifyControllerData)Marshal.PtrToStructure(ptr, typeof(sIdentifyControllerData));
        }

        public void vInitDevConfig(int dev_size, int ddr_size)
        {
            iInitDeviceConfig(dev_size, ddr_size);
        }

        public void vIssueFlashCmd(int cmd, int ch, int blk, int plane, int page, IntPtr ptr) {
            int pAddr = 0;

            iIssueFlashCmd(cmd, pAddr, ptr);
        }

        public int vCalculateHitRatio() {
            long chkCnt = lpl2ChkCnt();
            long hitCnt = lp2lHitCnt();
            int hitRatio = (int)(hitCnt / chkCnt);

            return hitRatio;
        }

    }
}
