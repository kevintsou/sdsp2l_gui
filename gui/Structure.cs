using System.Runtime.InteropServices;

namespace gui
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct s_dev_config
    {
        public int dev_size;
        public int ddr_size;

        public int chCnt;
        public int blkCnt;
        public int pageCnt;
        public int planeCnt;

        public int chBitNum;
        public int blkBitNum;
        public int pageBitNum;
        public int planeBitNum;

        public int chSftCnt;
        public int blkSftCnt;
        public int pageSftCnt;
        public int planeSftCnt;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct s_sript_mgr
    {
        // test config
        public int testTime;
        public int testType;
        public int outputRslt;

        // device info
        public int totalCmdCnt;
        public int totalWrCnt;
        public int totalRdCnt;
        public int totalErsCnt;
        public int bitChkCnt;
        public int bitHitCnt;
        public int hitRate;
        public int[][] eraseCnt; // erase count of each die block (target)
        public int[][] readCnt;  // read count of each die block (target)
    }

    public enum e_cmd
    {
        E_CMD_READ = 0,
        E_CMD_WRITE,
        E_CMD_ERASE
    }

}
