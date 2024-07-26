using PNB.SAS.Data;
using System.Windows.Forms;

namespace PNB.SAS
{
    public class SApp
    {
        SystemApp sa;
        DAQ.DAQ daq;
        public SApp()
        {
            init();
        }
        void init()
        {
            sa = new SystemApp();
            daq = new DAQ.DAQ();
        }

        public void Start()
        {
            Protocol.frmLauncher f = new Protocol.frmLauncher();
            Application.Run(f);
        }
    }
}
