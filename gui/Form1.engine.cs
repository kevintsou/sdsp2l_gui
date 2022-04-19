using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace gui
{
    partial class Form1
    {
        int iRaidFrameCnt;
        int[] iRaidParity;      // Raid encode parity
        int[] iRaidDecParity;   // Raid decode parity
        int[] iRaidDecRslt;     // Raid decode result

        public int iInitEngVal() {
            iRaidParity = new int[16384/4];
            iRaidDecParity = new int[(16384+2048)/4];
            iRaidDecRslt = new int[(16384+2048)/4];
            return 0;
        }

        // encode data to generate the ecc parity
        // 2KB DATA + 8Bytes P4K + 4Bytes parity
        // IntPtr pPayload : data payload
        // int iEccFraNum : encode ecc frame number
        public int iEccEncodeEng(IntPtr pPayload, int[][] p4k, int iEccFraNum) {
            int parity = 0;
            int idx = 0;
            IntPtr tmpPtr = pPayload;
            int intFullLeng = (2048+256)/4;
            int intRawLeng = 512;

            Array.Clear(inBuffer, 0, inBuffer.Length);

            // for each ecc frame
            for (int eccIdx = 0; eccIdx < iEccFraNum; eccIdx++)
            {
                tmpPtr = IntPtr.Add(pPayload, eccIdx*2048);
                Marshal.Copy(tmpPtr, inBuffer, eccIdx*intFullLeng, intRawLeng);

                // copy p4k content to inBuffer
                inBuffer[eccIdx*intFullLeng + 512] = p4k[eccIdx/2][(eccIdx%2)*2];
                inBuffer[eccIdx*intFullLeng + 513] = p4k[eccIdx/2][(eccIdx%2)*2+1];

                // encode 2K
                for (idx = 0; idx < (512 + 2); idx++)
                {
                    parity = parity ^ inBuffer[idx + eccIdx*intFullLeng];
                }
                inBuffer[idx + eccIdx*intFullLeng] = parity; // parity field
                parity = 0;
            }

            Marshal.Copy(inBuffer, 0, pPayload, (16384+2048)/4);
            return 0;
        }

        // detect if the page occur ecc error
        // 2KB DATA + 8Bytes P4K + 4Bytes parity
        // IntPtr pPayload : data payload
        // int iEccFraNum : decode ecc frame number
        public int iEccDetectEng(IntPtr pPayload, int iEccFraNum) {
            int parity = 0;
            int idx = 0;
            int intFullLeng = (2048+256)/4;

            Array.Clear(inBuffer, 0, inBuffer.Length);
            Marshal.Copy(pPayload, inBuffer, 0, (16384+2048)/4);
            // for each ecc frame
            for (int eccIdx = 0; eccIdx < iEccFraNum; eccIdx++)
            {
                // encode 2K
                for (idx = 0; idx < (512 + 2); idx++)
                {
                    parity = parity ^ inBuffer[idx + eccIdx*intFullLeng];
                }

                if(inBuffer[idx + eccIdx*intFullLeng] != parity)
                {
                    return -1;
                }
                parity = 0;
            }
            return 0;
        }

        // raid encode main function
        // IntPtr pPayload : data payload 
        // int iFraNum : Raid encode size, 4K base (ex. iFraNum = 4, raid encode unit is 16K)
        public int iRaidEncodeEng(IntPtr pPayload, int iFraNum) {
            int idx = 0;
            int intRawLeng = 512;

            iRaidFrameCnt = iFraNum;

            Array.Clear(inBuffer, 0, inBuffer.Length);
            Marshal.Copy(pPayload, inBuffer, 0, iFraNum*intRawLeng);

            for (int framIdx = 0; framIdx < iFraNum; framIdx++) {
                for (idx = 0; idx < 1024; idx++) {
                    iRaidParity[idx + framIdx*intRawLeng] = iRaidParity[idx + framIdx*intRawLeng] ^ inBuffer[idx + framIdx*intRawLeng];
                }
            }

            return 0;
        }

        // use this function to get the raid encode parity
        public int[] iRaidChkoutParity()
        {
            return iRaidParity;
        }

        public int iResetRaidParity() {
            Array.Clear(iRaidParity, 0, iRaidParity.Length);
            return 0;
        }

        public int iRaidChkinParity(int[] iParity) { 
            iRaidParity = iParity;
            return 0;
        }

        // use this funciton to decode the error page
        // IntPtr pPayload : data payload : (2KB DATA + 8Bytes P4K + 4Bytes parity)*2*iRaidFrameCnt
        // int iFinal : final page, output the decode result to iRaidDecRslt buffer
        public int iRaidDecodeEng(IntPtr pPayload, int iFinal)
        {
            int idx = 0;
            int intRawLeng = 512;
            int intFullLeng = (2048+256)/4;

            Array.Clear(inBuffer, 0, inBuffer.Length);
            Marshal.Copy(pPayload, inBuffer, 0, (16384+2048)/4);

            for (int framIdx = 0; framIdx < iRaidFrameCnt; framIdx++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (idx = 0; idx < 512; idx++)
                    {
                        iRaidDecParity[idx + i*512 + framIdx*intRawLeng] = 
                            iRaidDecParity[idx + i*512 + framIdx*intRawLeng] ^ inBuffer[idx + (i*intFullLeng) + framIdx*((4096+512)/4)];
                    }
                }
            }

            if (iFinal == 1) {
                iRaidDecRslt = iRaidDecParity;

            }

            return 0;
        }
    }
}
