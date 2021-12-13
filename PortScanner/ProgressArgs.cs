using System;

namespace PortScanner
{
    public class ProgressArgs : EventArgs
    {
        public int ScannedPorts { get; }

        public ProgressArgs(int scannedPorts)
        {
            this.ScannedPorts = scannedPorts;
        }
    }
}