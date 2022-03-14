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
    }

    public enum e_write_cmd
    {
        E_CMD_READ = 0,
        E_CMD_WRITE,
        E_CMD_ERASE
    }

}
