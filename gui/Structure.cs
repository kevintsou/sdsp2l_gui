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
        public int elapsedTime;
        public int testType;
        public int outputRslt;
        public int testRslt;
        public int testSts;

        // test status
        public int ch;
        public int blk;
        public int page;
        public int plane;
        public int lun;
        public int progress;

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

    public enum e_test_rslt
    { 
        E_RSLT_PASS = 0,
        E_RSLT_MISCMPARE,
        E_RSLT_TERMINATED
    }

    public enum e_state
    { 
        E_STS_IDLE = 0,
        E_STS_RUNNING = 1,
        E_STS_PAUSED = 2,
        E_STS_STOPPED = 3
    }
}
