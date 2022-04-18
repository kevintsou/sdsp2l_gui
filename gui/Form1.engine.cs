using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace gui
{
    partial class Form1
    {
        int[] payloadBuffer = new int[18 * 256];    // 18K payload buffer

        // encode data to generate the ecc parity
        // 4KB DATA + 16Bytes P4K + 4Bytes parity
        public int iEccEncode(IntPtr pPayload) {
            int parity = 0;
            int idx = 0;
            
            for (int eccIdx = 0; eccIdx < 4; eccIdx++)
            {
                Marshal.Copy(pPayload, inBuffer, eccIdx*(4096+512), (4096+512));
                // encode 4K
                for (idx = 0; idx < (1024 + 4); idx++)
                {
                    parity = parity ^ inBuffer[idx + eccIdx*(4096+512)];
                }
                inBuffer[idx] = parity; // parity field
            }

            return 0;
        }

        // detect if the page occur ecc error
        public int iEccDetect(int[] pPayload) { 
            return -1;
        }

        // raid encode main function
        public int iRaidEncode() { 
            return 0;
        }

        // use this function to get the raid encode parity
        public int iRaidChkoutParity()
        {
            return 0;
        }

        // use this funciton to decode the error page
        public int iRaidDecode() { 
            return -1;
        }
    }
}
