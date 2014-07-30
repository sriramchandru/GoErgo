using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;

namespace GoErgoUI
{
    /*
[event_receiver(managed)]   // optional for native C++ and managed classes
__gc class CReceiver {
    public:
   void BlinkHandler(int nValue) {
   }
   void hookEvent(CSource* pSource) {
      __hook(&CSource::BlinkEvent, pSource, &CReceiver::BlinkHandler);
   }
   void unhookEvent(CSource* pSource) {
      __unhook(&CSource::BlinkEvent, pSource, &CReceiver::BlinkHandler);
   }
}*/

    unsafe public class WebCamWorker
    {
        [DllImport("GoErgo.dll")]
        static extern int webCamMain();
        [DllImport("GoErgo.dll")]
        static extern int get_stats(int* blink, int* ambient_alarm, int* posture_alarm, float* percent_ambient, int use_buf);
        public void DoWork()
        {
            webCamMain();
        }

        public int[] GetStats()
        {
            while (true)
            {

            Thread.Sleep(1000);
            int blink, ambient_alarm, posture_alarm;
            float percent_ambient;
            get_stats(&blink, &ambient_alarm, &posture_alarm, &percent_ambient, 1);
                int[] data = new int[3];
                data[0] = blink;
                data[1] = ambient_alarm;
                data[2] = posture_alarm;
            }
        }
    }
}
