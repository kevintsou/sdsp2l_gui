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
        public string typeName;

        // test status
        public int ch;
        public int blk;
        public int page;
        public int plane;

        public int chBitNum;
        public int blkBitNum;
        public int pageBitNum;
        public int planeBitNum;

        public int chSftCnt;
        public int blkSftCnt;
        public int pageSftCnt;
        public int planeSftCnt;

        public int progress;

        // device info
        public int totalCmdCnt;
        public int totalWrCnt;
        public int totalRdCnt;

        public long bitChkCnt;
        public long bitHitCnt;
        public float hitRate;
        public long[] chBurstCnt;
        public int[] eraseCnt; // erase count of each die block (target)
        public int[] readCnt;  // read count of each die block (target)
    }

    public enum e_cmd
    {
        E_CMD_READ = 0,
        E_CMD_WRITE,
        E_CMD_ERASE,
        E_CMD_NONE,
        E_CMD_SEQ_RD,
        E_CMD_RD_RD,
    }

    public enum e_test_rslt
    { 
        E_RSLT_PASS = 0,
        E_RSLT_MISCMPARE,
        E_RSLT_TERMINATED
    }

    public enum e_state
    { 
        E_STS_IDLE = 0,     // ready to accept new cmd
        E_STS_RUNNING = 1,  // test on going
        E_STS_PAUSED = 2,   // test pause
        E_STS_STOPPED = 3   // thread stop , wait for join
    }
}
