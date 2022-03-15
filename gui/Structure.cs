using System.Runtime.InteropServices;

namespace gui
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct s_dev_config
    {
        public int chCnt;
        public int blkCnt;
        public int pageCnt;
        public int planeCnt;

        public int dev_size;
        public int ddr_size;

        // test parameters
        public int testMin;
        public int chkCnt;
        public int hitCnt;
        public int hitRate;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct s_dev_mgr
    {
        int dev_cap;
        int ddr_size;

        int chCnt;
        int blkCnt; // die block count
        int pageCnt;
        int planeCnt;

        int chBitNum;
        int blkBitNum;
        int pageBitNum;
        int planeBitNum;

        int chSftCnt;
        int blkSftCnt;
        int pageSftCnt;
        int planeSftCnt;
    }

    public enum e_cmd
    {
        E_CMD_READ = 0,
        E_CMD_WRITE,
        E_CMD_ERASE
    }

}
