# Port Scanner

This is a simple multithread port scanner implemented using the `TcpClient` class.
It was my college exercise.

## How to use?

Initialize new Scanner class object and use .ScanPorts() method that takes three arguemnts (portScopeStart, portScopeEnd, hostname - localhost by default)
ActivePorts property contains active ports. InactivePorts work the same way.

- `ScanPorts(int portScopeStart, int portScopeEnd, string hostname)` method that scan ports in selected portScope and has by default hostname as localhost (127.0.0.1).

This library has two events publishers.

- ScanStarted
- ScanEnd
