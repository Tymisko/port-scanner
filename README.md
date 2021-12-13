# Port Scanner

This is a simple multithread port scanner implemented using the `TcpClient` class.
It was my college exercise.

## How to use?

There is a static `Scanner` class that has:

- `Scan(int portScopeStart, int portScopeEnd, string hostname)` method that scan ports in selected portScope and has by default hostname as localhost (127.0.0.1).
