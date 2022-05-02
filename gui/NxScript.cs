using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace gui
{
    partial class Form1
    {
        
        public Thread scriptThread;
        public int scriptNum = 0;
        private static nxs_dev_config nxsDev;
        public int nxsStatus = (int)n_state.N_STS_IDLE;

        private void initDevConfig()
        {
            nxsDev.chCnt = int.Parse(nxsChNum.Text.ToString());
            nxsDev.planeCnt = int.Parse(nxsPlaneNum.Text.ToString());
            nxsDev.blockCnt = int.Parse(nxsBlockNum.Text.ToString());
            nxsDev.pageCnt = int.Parse(nxsPageNum.Text.ToString());
        }
        public void scriptDispatch()
        {
            initDevConfig();
            switch (scriptNum)
            {
                case 0:
                    nrcCase1();
                    break;
            }
        }

        private void getNxStatus() //get NxS c model status
        {

        }

        private void writeVB()
        {
            for (int writePage = 0; writePage < nxsDev.pageCnt; writePage++)
            {
                for (int writeCh = 0; writeCh < nxsDev.chCnt; writeCh++)
                {
                    for (int writePlane = 0; writePlane < nxsDev.planeCnt; writePlane++)
                    {
                        IntPtr pPayload = Marshal.AllocHGlobal(4);
                        iIssueFlashCmd((int)e_cmd.E_CMD_WRITE, writeCh, writePlane, writePlane, writePage, pPayload);
                        Marshal.FreeHGlobal(pPayload);
                    }
                }
            }
        }

        private int calcBitNum(int value)
        {
            int bitNum = 0;
            if (value == 0 || value == 1)
                bitNum = 1;
            else
                bitNum = (int)Math.Log2(value);

            return bitNum;
        }

        private int pickOneRandomAddr()
        {
            int ch = 0, plane = 0, block = 0, page = 0;
            int chBitNum = 0, planeBitNum = 0, blockBitNum = 0, pageBitNum = 0;
            int chSftCnt = 0, planeSftCnt = 0, blockSftCnt = 0, pageSftCnt = 0;
            int pAddr = 0;

            Random rand = new Random();
            ch = rand.Next(nxsDev.chCnt);
            block = rand.Next(nxsDev.blockCnt);
            plane = rand.Next(nxsDev.planeCnt);
            page = rand.Next(nxsDev.pageCnt);


            chBitNum = calcBitNum(ch);
            planeBitNum = calcBitNum(plane);
            blockBitNum = calcBitNum(block);
            pageBitNum = calcBitNum(page);

            planeSftCnt = pageSftCnt + pageBitNum;
            blockSftCnt = planeSftCnt + planeBitNum;
            chSftCnt = blockSftCnt + blockBitNum;

            pAddr = (ch << chSftCnt) | (block << blockSftCnt) | (plane << planeSftCnt) | page;

            /*ch = (pAddr >> chSftCnt) & ch;
            plane = (pAddr >> planeSftCnt) & plane;
            block = (pAddr >> blockSftCnt) & block;
            page = (pAddr >> pageSftCnt) & page;*/

            return pAddr;
        }


        private void nrcCase1()
        {
            int pAddr = 0;
            nxsStatus = (int)n_state.N_STS_RUNNING;
            writeVB();
            nxsStatus = (int)n_state.N_STS_VBFULL; //get NxS c model status.
            pAddr = pickOneRandomAddr();

            // if(triggerNxS(pAddr))
            //
            // if(GetErrorInjectFinishStatus())
            //      data = GetErrorInjectData();
            // RecoveredData = RaidECCEngine(data);
            // compare data
            // if(RecoveredData != goldenData)
            //      fail
            // else
            //      pass

        }
    }
}
