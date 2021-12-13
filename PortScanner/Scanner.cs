using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PortScanner
{
    public class Scanner
    {
        public List<int> ActivePorts { get; }

        public List<int> InactivePorts { get; }

        public Scanner()
        {
            this.ActivePorts = new List<int>();
            this.InactivePorts = new List<int>();
        }

        public void ScanPorts(int portScopeStart, int portScopeEnd, string hostname = "127.0.0.1")
        {
            ResetScanner();

            var tasks = new Task[portScopeEnd - portScopeStart + 1];
            var port = portScopeStart;

            for (var i = 0; i < (portScopeEnd - portScopeStart + 1); i++)
            {
                tasks[i] = Task.Run(() => CheckPort(hostname, port++));
            }

            var CheckPortsFromScope = Task.WhenAll(tasks);
            CheckPortsFromScope.Wait();
        }

        private void CheckPort(string hostname, int port)
        {
            try
            {
                TcpClient scanner = new TcpClient();
                scanner.Connect(hostname, port);
                this.ActivePorts.Add(port);
                this.ActivePorts.Sort();
            }
            catch
            {
                InactivePorts.Add(port);
            }
        }

        private void ResetScanner()
        {
            this.ActivePorts.Clear();
            this.InactivePorts.Clear();
        }
    }
}
