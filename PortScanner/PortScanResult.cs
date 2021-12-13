using System.Collections.Generic;

namespace PortScanner
{
    public class PortScanResult
    {
        public List<int> ActivePorts { get; }

        public List<int> InactivePorts { get; }

        public PortScanResult()
        {
            this.ActivePorts = new List<int>();
            this.InactivePorts = new List<int>();
        }
    }
}