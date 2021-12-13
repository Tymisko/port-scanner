using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PortScanner
{
    public class Scanner
    {
        public event EventHandler<ProgressArgs> ScanProgress;
        private PortScanResult _scanResult;
        private int _scannedPortsCounter;

        public Scanner()
        {
            this._scanResult = new PortScanResult();
            this._scannedPortsCounter = 0;
        }

        public PortScanResult ScanPorts(int portScopeStart, int portScopeEnd, string hostname = "127.0.0.1")
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

            return _scanResult;
        }

        protected virtual void OnScanProgress(int portCounter)
        {
            ScanProgress?.Invoke(this, new ProgressArgs(_scannedPortsCounter));
        }

        private void CheckPort(string hostname, int port)
        {
            try
            {
                TcpClient scanner = new TcpClient();
                scanner.Connect(hostname, port);
                this._scanResult.ActivePorts.Add(port);
                this._scanResult.ActivePorts.Sort();
            }
            catch
            {
                this._scanResult.InactivePorts.Add(port);
                this._scanResult.InactivePorts.Sort();
            }
            finally
            {
                OnScanProgress(++_scannedPortsCounter);
            }
        }

        private void ResetScanner()
        {
            this._scanResult = new PortScanResult();
            this._scannedPortsCounter = 0;
        } 
    }
}

